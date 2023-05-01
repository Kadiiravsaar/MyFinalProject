using Buisness.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();

            //ProductWithId();

            //ProductOrderBy();


            //CustomerContactName();


            //OrderShipCity();



            //    ProductManager productManager = new ProductManager(new EFProductDal());

            //    var result = productManager.GetProductDetails();
            //    if (result.Success)
            //    {
            //        foreach (var prod in result.Data)
            //        {
            //            Console.WriteLine(prod.ProductName + " " + prod.CategoryName);
            //        }

            //    }
            //    Console.WriteLine(result.Message);    
            //}

            //private static void OrderShipCity()
            //{
            //    int sayac = 1;
            //    OrderManager orderManager = new OrderManager(new EFOrderDal());
            //    foreach (var orders in orderManager.GetAll())
            //    {
            //        Console.WriteLine(sayac + " " + orders.ShipCity);
            //        sayac++;
            //    }
            //}

            //private static void CustomerContactName()
            //{
            //    CustomerManager customerManager = new CustomerManager(new EFCustomerDal());
            //    foreach (var customers in customerManager.GetCustomers())
            //    {
            //        Console.WriteLine(customers.ContactName);
            //    }
            //}

            //private static void ProductOrderBy()
            //{
            //    ProductManager productManager = new ProductManager(new EFProductDal());
            //    foreach (var prod in productManager.GetAllOrderBy().Data)
            //    {
            //        Console.WriteLine(prod.ProductName);
            //    }
            //}

            //private static void ProductWithId()
            //{
            //    ProductManager productManager = new ProductManager(new EFProductDal());
            //    Console.WriteLine(productManager.GetById(2).Data);
            //}

            //private static void ProductTest()
            //{
            //    ProductManager productManager = new ProductManager(new EFProductDal());
            //    foreach (var prod in productManager.GetAll().Data)
            //    {
            //        Console.WriteLine(prod.ProductName);
            //    }

            //}
        }
    }

}
