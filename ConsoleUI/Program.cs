using Buisness.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //foreach (var prod in productManager.GetAll())
            //{
            //    Console.WriteLine(prod.ProductName);
            //}
      
            ProductManager productManager = new ProductManager(new EFProductDal());

            foreach (var prdUnit in productManager.GetByUnitInStock(1,2))
            {
                
                Console.WriteLine(prdUnit.UnitsInStock);
            }

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            //CustomerManager customerManager = new CustomerManager(new EFCustomerDal());
            //foreach (var customers in customerManager.GetCustomers())
            //{
            //    Console.WriteLine(customers.ContactName);
            //}
            
            


        }
    }
}
