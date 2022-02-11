using EntityFrameWorkCore_Tutorial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameWorkCore_Tutorial {
    
    class Program {

        static void Main(string[] args) {

            AppDbContext context = new AppDbContext();

            var items = context.Items.ToList();

            foreach(var i in items) {
                i.Price = i.Price * (1 + 0.1m);

            }
            context.SaveChanges();

            items = context.Items.ToList();

            foreach (var item in items) {
                Console.WriteLine($"{item.Id,-5} {item.Code,-10} {item.Name,-15} {item.Price,10:c}");
            }


            //add a new order for Kroger
            //var  Kroger = context.Customers.SingleOrDefault(c => c.Name.StartsWith("Kr"));
            //var order = new Order() {
            //    Id = 0, Description = "4th Order", Total = 2500, CustomerId = Kroger.Id

            //};

            //context.Orders.Add(order);
            //context.SaveChanges();

           
            //var orders = context.Orders.Include(x => x.Customer).ToList();

            //foreach(var o in orders) {
            //    Console.WriteLine($"{o.Id,-5}{o.Description,-10}"
            //                        + $"{o.Total,10:c} {o.Customer.Name}");
                                    
            //}

            ////delete a customer
            //var amazon = context.Customers.SingleOrDefault(c => c.Name == "Amazon");

            //if(amazon != null) {
            //    context.Customers.Remove(amazon);
            //    context.SaveChanges();
            //}

            //update - changing some data for a customer
            //var max = context.Customers.Find(1);
            // adds 5000 to sales in Max
            //max.Sales += 5000;

            //context.SaveChanges();



            // insert a new customer 
            //var newCustomer = new Customer() {
            //    Id = 0, Name = "Kroger", Active = true,
            //    Sales = 3000000, Updated = new DateTime(2022, 2, 11)
            //};
            //context.Customers.Add(newCustomer);
            //context.SaveChanges();

            // read by primary key
            //var customer = context.Customers.Find(2);
            //Console.WriteLine($"{customer.Name} {customer.Sales:c}");

            // read all customers           
            //var customers = from cust in context.Customers
            //                    //where cust.Sales < 100000
            //                select cust;


            ////List<Customer> customers = context.Customers
            ////                                    .Where(cust => cust.Sales < 100000)
            ////                                    .ToList();

            //foreach (var customer in customers) {
            //    Console.WriteLine($"{customer.Name,-20} {customer.Sales,10:c}");
                // added formatting with the -20 and 10
                //}
            //}
        }
    }
}
