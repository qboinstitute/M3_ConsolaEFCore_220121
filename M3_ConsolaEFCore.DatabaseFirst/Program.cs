using M3_ConsolaEFCore.DatabaseFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace M3_ConsolaEFCore.DatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SalesContext())
            {
                var supplier1 = new Supplier()
                {
                    CompanyName = "QBO Institute 1",
                    ContactName = "Luis Chang",
                    ContactTitle = "Sales Manager",
                    City = "Lima",
                    Country = "Perú",
                    Phone = "99282882",
                    Fax = "7828233"
                };

                //Add Supplier
                //context.Suppliers.Add(supplier1);
                //context.SaveChanges();

                var supplier2 = new Supplier()
                {
                    CompanyName = "QBO Institute 2",
                    ContactName = "Luis Chang",
                    ContactTitle = "Sales Manager",
                    City = "Lima",
                    Country = "Perú",
                    Phone = "99282882",
                    Fax = "7828233"
                };

                var supplier3 = new Supplier()
                {
                    CompanyName = "QBO Institute 3",
                    ContactName = "Luis Chang",
                    ContactTitle = "Sales Manager",
                    City = "Lima",
                    Country = "Perú",
                    Phone = "99282882",
                    Fax = "7828233"
                };
                var supplierList = new List<Supplier>();
                supplierList.Add(supplier2);
                supplierList.Add(supplier3);

                //Add Range Supplier
                //context.Suppliers.AddRange(supplierList);
                //context.SaveChanges();

                //Remove Supplier
                //-->Query by LINQ
                //var searchSupplierLQ = (from s in context.Suppliers
                //                        where s.Id == 35
                //                        select s).FirstOrDefault();

                //context.Suppliers.Remove(searchSupplierLQ);
                //context.SaveChanges();

                //-->Query by Lambda Expressions
                //var searchSupplierLE = context.Suppliers
                //    .Where(query => query.Id == 36).FirstOrDefault();
                //context.Suppliers.Remove(searchSupplierLE);
                //context.SaveChanges();

                //Update 
                //var searchSupplierUP = context.Suppliers
                //  .Where(query => query.Id == 37).FirstOrDefault();
                //searchSupplierUP.City = "Cusco";
                //context.SaveChanges();

                //Others

                var searchByParams = context.Suppliers.
                    Where(x => x.Country.Equals("USA")
                    && x.CompanyName.Contains("New")).ToList();

                Console.WriteLine("*****searchByParams******");
                foreach (var item in searchByParams)
                {
                    Console.WriteLine("CompanyName: " + item.CompanyName +
                                      " ContactName: " + item.ContactName);
                }

                //Joins
                var searchWithJoins = from p in context.Products
                                      join s in context.Suppliers
                                      on p.SupplierId equals s.Id
                                      where p.UnitPrice >= 25 && p.UnitPrice <= 30
                                      select new
                                      {
                                          p.ProductName
                                                  ,
                                          p.UnitPrice
                                                  ,
                                          s.CompanyName
                                      };
                Console.WriteLine("*****searchWithJoins******");
                foreach (var item in searchWithJoins)
                {
                    Console.WriteLine("CompanyName: " + item.CompanyName +
                                      " ProductName: " + item.ProductName +
                                      " UnitPrice: " + item.UnitPrice);
                }

                //Query new table(User)

                var users = context.Users.ToList();
                Console.WriteLine("*****USERS******");
                foreach (var item in users)
                {
                    Console.WriteLine("Id: " + item.Id +
                                      "| Username: " + item.Username);
                }

            }


            Console.ReadKey();
        }
    }
}
