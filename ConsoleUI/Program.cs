using Buisness.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EFProductDal());
            foreach (var prod in productManager.GetAllByCategoryId(2))
            {
                Console.WriteLine(prod.ProductName);
            } 
        }
    }
}
