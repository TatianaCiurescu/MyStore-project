using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Tests
{
    public static class Consts
    {

        //product consts
        
        public static int CategoryId=2; //use enums
        public static int TestProduct = 3;
        public static int TestSupplierId = 4;
        public static decimal TestUnitPrice = 100.23M;
        public const string ProductName = "Test Product name 1";

        public enum Categories
        {
            Condiments = 2,
            Confections = 3,
            Dairy = 4,
            Grains = 5,
            Meat = 6
        }

        //supplier Consts
        public static string Address = "Address under test";
        public static string City = "London";
        public static string Country = "UK";
        public static string Phone = "0771777211";
        public static string PostalCode = "123456";
        public static string Region = " ";
        public static string Fax = " ";
        public const string CompanyName = "Test Company name";
        public const string ContactName = "Adrian";
        public const string ContactTitle = "Owner";
        
        
    }
}
