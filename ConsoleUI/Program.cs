using Buisness.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal());
            foreach (var prod in productManager.GetAll())
            {
                Console.WriteLine(prod.ProductName);
            } 
        }
    }
}
