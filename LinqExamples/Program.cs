using System;
using System.Collections.Generic;
using System.Linq;
using CSharp2SqlLibrary;
using ExtensionMethods;

namespace LinqExamples {
    class State {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    class Program {

        void Run() {
            var Connection = new Connection(@"localhost\sqlexpress", "PrsDb7");
            Connection.Open();

            Products.Connection = Connection;

            var products = Products.GetAll();
            foreach(var product in products) {
                product.PrintBrief();
            }

            //Vendors.Connection = Connection;

            //var states = new State[] {
            //    new State() { Code = "WA", Name = "Washington" },
            //    new State() { Code = "XX", Name = "Outer Space" }
            //};

            //var vendorsWithState = (from v in Vendors.GetAll()
            //                        join s in states
            //                         on v.State equals s.Code
            //                        select new {
            //                            Vendor = v.Name, State = s.Name
            //                        }).ToList() ;

            //foreach(var v in vendorsWithState) {
            //    Console.WriteLine($"Vendor {v.Vendor} is in {v.State}");
            //}

            #region Product Join with Vendor
            //Products.Connection = Connection;

            //var products = from p in Products.GetAll()
            //               join v in Vendors.GetAll()
            //                on p.VendorId equals v.Id
            //               select new {
            //                   Product = p.Name, Price = p.Price, Vendor = v.Name
            //               };
            //foreach(var p in products) {
            //    Console.WriteLine($"{p.Product} priced at {p.Price} is from {p.Vendor}");
            //}
            #endregion

            #region Total all product prices
            //Products.Connection = Connection;

            //var totalAllProducts = (from p in Products.GetAll()
            //                        select p).Sum(p => p.Price);
            //Console.WriteLine($"Total all prices is {totalAllProducts}");

            //var priceTotal = Products.GetAll().Sum(p => p.Price);
            //Console.WriteLine($"Total all prices is {priceTotal}");
            #endregion

            #region Commented out code
            //Vendors.Connection = Connection;

            //var vendors = from v in Vendors.GetAll()
            //              orderby v.Name
            //              select v;

            //foreach(var v in vendors) { Console.WriteLine(v); }

            //var amazon = from v in Vendors.GetAll()
            //              where v.Code.Equals("AMAZ")
            //              select v;

            //foreach(var v in amazon) { Console.WriteLine(v); }

            //Users.Connection = Connection;

            //var users = from u in Users.GetAll()
            //             where u.IsReviewer
            //             select u;

            //foreach(var user in users) {
            //    Console.WriteLine($"{user}");
            //}
            #endregion

            Connection.Close();
        }

        static void Main(string[] args) {
            var pgm = new Program();
            pgm.Run();

            //int[] ints = { 2, 4, 6, 8, 7, 5, 3, 1 };

            //var ascInts = (from i in ints
            //              where i % 2 == 1 && i < 7
            //              orderby i descending
            //              select i);

            //var avg = ascInts.Average(i => i);

            //Console.WriteLine($"Average of odds LT 7 is {avg}");

            //foreach(var i in ascInts) {
            //    Console.Write($"{i} ");
            //}
        }
    }
}
