using System;
using System.Collections.Generic;
using System.Text;
using CSharp2SqlLibrary;

namespace ExtensionMethods {

    static class MyExtensionMethods {

        public static void PrintBrief(this Products product) {
            Console.WriteLine($"Product name is {product.Name}");
        }

        public static void Print(this List<Products> products) {

            foreach(var product in products) {
                Console.WriteLine(product);
            }

        }
    }
}
