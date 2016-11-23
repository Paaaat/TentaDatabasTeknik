using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TentaDatabasTeknik.models;

namespace TentaDatabasTeknik
{
    class Program
    {
        static string cns = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NORTHWND;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static void Main(string[] args)
        {
            //ProductsByCategoryName("Confections");
                             SalesByTerritory();
           // EmployeesPerRegion();
            //OrdersPerEmployye();
            //CustomerWithNameLongerThen25Characters();
        }

        private static void CustomerWithNameLongerThen25Characters()
        {
            using (NorthwindContext cx = new NorthwindContext())
            {
                foreach (var kund in cx.Customers)
                {
                    if (kund.CompanyName.Length > 25)
                    {
                        Console.WriteLine(kund.CompanyName);
                    }
                }
            }
        }

        private static void OrdersPerEmployye()
        {
            using (NorthwindContext cx = new NorthwindContext())
            {
                foreach (var Person in cx.Employees)
                {
                    Console.WriteLine(Person.FirstName + " " + Person.Orders.Count);     

                }
            }
        }

        private static void EmployeesPerRegion()
        {
            SqlConnection cn = new SqlConnection(cns);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT Region.RegionDescription, COUNT(Employees.EmployeeID) AS Expr1 FROM Employees INNER JOIN EmployeeTerritories ON Employees.EmployeeID = EmployeeTerritories.EmployeeID INNER JOIN Territories ON EmployeeTerritories.TerritoryID = Territories.TerritoryID INNER JOIN Region ON Territories.RegionID = Region.RegionID GROUP BY Region.RegionDescription";
            //Vet inte om villken av territorys som ska visas såskrev båda
            //cmd.CommandText = "SELECT Employees.Region AS Region, COUNT(Employees.EmployeeID) AS TotalEmployees FROM Employees INNER JOIN EmployeeTerritories ON Employees.EmployeeID = EmployeeTerritories.EmployeeID INNER JOIN Territories ON EmployeeTerritories.TerritoryID = Territories.TerritoryID INNER JOIN Region ON Territories.RegionID = Region.RegionID GROUP BY Employees.Region";
            
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Console.WriteLine(rd.GetString(0)); //Ett värde i region är null
                Console.WriteLine(rd.GetInt32(1));                
            }
            rd.Close();
            cn.Close();
        }

        private static void SalesByTerritory()
        {
            SqlConnection cn = new SqlConnection(cns);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT top(5) SUM([Order Details].UnitPrice * [Order Details].Quantity) AS Expr1, Territories.TerritoryDescription FROM Employees INNER JOIN EmployeeTerritories ON Employees.EmployeeID = EmployeeTerritories.EmployeeID INNER JOIN Orders ON Employees.EmployeeID = Orders.EmployeeID INNER JOIN [Order Details] ON Orders.OrderID = [Order Details].OrderID INNER JOIN Territories ON EmployeeTerritories.TerritoryID = Territories.TerritoryID GROUP BY[Order Details].Discount, Territories.TerritoryDescription";
            
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Console.WriteLine(rd.GetValue(0) + " " + (rd.GetString(1)));
              
                
            }
            rd.Close();
            cn.Close();
        }

        private static void ProductsByCategoryName(string CategoryName)
        {
            SqlConnection cn = new SqlConnection(cns);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT Products.ProductName, Products.UnitPrice, Products.UnitsInStock FROM Categories INNER JOIN Products ON Categories.CategoryID = Products.CategoryID WHERE(Categories.CategoryName = @CategoryName)";           
            cmd.Parameters.AddWithValue("@CategoryName", CategoryName);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Console.WriteLine(rd.GetString(0));
                Console.WriteLine(rd.GetValue(1));
                Console.WriteLine(rd.GetValue(2));
            }
            rd.Close();
            cn.Close();
        }
    }
}
