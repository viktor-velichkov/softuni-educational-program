using _03.ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.ShoppingSpree.Core
{
    public class Engine
    {
        private List<Person> people = new List<Person>();
        private List<Product> products = new List<Product>();
        public Engine()
        {
            this.products = new List<Product>();
            this.people = new List<Person>();
        }
        public void Run()
        {
            AddPeople();
            AddProducts();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {

                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                try
                {
                    Person buyer = people.First(x => x.Name == cmdArgs[0]);
                    Product product = products.First(x => x.Name == cmdArgs[1]);
                    buyer.Buy(product);
                    Console.WriteLine($"{buyer.Name} bought {product.Name}");
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
            foreach (Person person in this.people)
            {
                Console.WriteLine(person.ToString());
            }
        }

        private void AddProducts()
        {
            string[] productsData = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (var productData in productsData)
            {
                string[] tokens = productData.Split("=");
                string productName = tokens[0];
                decimal productCost = decimal.Parse(tokens[1]);
                Product newProduct = new Product(productName, productCost);
                this.products.Add(newProduct);
            }
        }

        private void AddPeople()
        {
            string[] peopleData = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (var personData in peopleData)
            {
                string[] tokens = personData.Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string personName = tokens[0];
                decimal personMoney = decimal.Parse(tokens[1]);
                Person newPerson = new Person(personName, personMoney);
                this.people.Add(newPerson);
            }
        }
    }
}
