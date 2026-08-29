using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ConsoleApp1
{

    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        // Func<Product, bool> is used because the filter receives a Product and returns true or false to decide whether it should be included.
        public List<Product> SearchProducts(List<Product> products,Func<Product, bool> filter)
        {
            var results = new List<Product>();
            foreach (var product in products)
            {
                if (filter != null && filter(product))
                {
                    results.Add(product);
                }
            }
            return results;
        }

        // Action<Product> is used because the method performs an action on each product without returning a value.
        public void PrintReport(List<Product> products,Action<Product> printAction) 
        {
            foreach (var product in products) 
            {
                printAction(product);
            }
        }

        // Func<Product, string> is used because each Product is transformed into a string and the transformed value is returned.
        public List<string> TransformProducts(List<Product> products, Func<Product, string> transform)
        {
            var results = new List<string>();
            foreach (var product in products)
            {
                if (transform != null)
                {
                    results.Add(transform(product));
                }
            }
            return results;
        }

        // Predicate<Product> is used because the condition checks each Product and returns true or false to determine whether it should be included.
        public List<Product> FilterProducts(List<Product> products, Predicate<Product> filter)
        {
            var results = new List<Product>();
            foreach (var product in products)
            {
                if (filter != null && filter(product))
                {
                    results.Add(product);
                }
            }
            return results;
        }

    }

}
