using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();
            try
            {
                //////////////////////////////////////////////////////////////////////////////////////                                                                                 
                //persons = new List<Person>(Console.ReadLine()                                       
                //            .Split(new char[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries)   
                //            .Select(p => p.Split('='))
                //            .Select(p => new Person(p[0], decimal.Parse(p[1]))));
                ///////////////////////////////////////////////////////////////////////////////////////

                var firstLine = Console.ReadLine();
                if (firstLine.Contains(";"))
                {
                    //var splittetFirstLine = firstLine.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    var splittetFirstLine = firstLine.Split(new[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < splittetFirstLine.Length; i++)
                    {
                        //var currentSplit = splittetFirstLine[i].Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                        var currentSplit = splittetFirstLine[i].Split('=');
                        var name = currentSplit[0];
                        var money = decimal.Parse(currentSplit[1]);
                        var person = new Person(name, money);
                        persons.Add(person);
                        if (person.isValid == false)
                        {
                            return;

                        }
                    }
                }
                else
                {
                    //var currentSplit = firstLine.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    var splittetFirstLine = firstLine.Split(new[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < splittetFirstLine.Length; i++)
                    {
                        var currentSplit = splittetFirstLine[i].Split('=');
                        var name = currentSplit[0];
                        var money = decimal.Parse(currentSplit[1]);
                        var person = new Person(name, money);
                        persons.Add(person);
                        if (person.isValid == false)
                        {
                            return;
                        }
                    }
                }

                //var secondLine = Console.ReadLine().Split(new[] { ' ', ';', '=' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var secondLine = Console.ReadLine();
                if (secondLine.Contains(";"))
                {
                    //var splittedSecondLine = secondLine.Split(new[]{';'}, StringSplitOptions.RemoveEmptyEntries);
                    var splittedSecondLine = secondLine.Split(';');

                    for (int i = 0; i < splittedSecondLine.Length; i++)
                    {
                        //var currentSplit = splittedSecondLine[i].Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                        var currentSplit = splittedSecondLine[i].Split('=');
                        var name = currentSplit[0];
                        var price = decimal.Parse(currentSplit[1]);
                        var product = new Product(name, price);
                        products.Add(product);
                        if (product.isValid == false)
                        {
                            return;

                        }
                    }
                }
                else
                {
                    var currentSplit = secondLine.Split('=');
                    var name = currentSplit[0];
                    var price = decimal.Parse(currentSplit[1]);
                    var product = new Product(name, price);
                    products.Add(product);
                    if (product.isValid == false)
                    {
                        return;
                    }
                }

                var inp = Console.ReadLine();
                while (inp != "END")
                {
                    var indexOfFirstSpace = inp.IndexOf(' ');

                    if (indexOfFirstSpace <= 0)
                    {
                        throw new ArgumentException("Invalid order");
                    }
                    /////////////////////////////////////////////////////////////////
                    var data = inp.Split();
                    var name = data[0];
                    var product = data[1];

                    foreach (Person p in persons.Where(p => p.Name == name))
                    {
                        foreach (Product productList in products.Where(x => x.Name == product))
                        {
                            if (p.Name == name)
                            {
                                if (productList.Name == product)
                                {
                                    if (p.Money >= productList.Cost)
                                    {
                                        p.List.Add(new Product(product, productList.Cost));
                                        p.Money -= productList.Cost;
                                        Console.WriteLine($"{p.Name} bought {productList.Name}");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{p.Name} can't afford {product}");
                                    }
                                }
                            }
                        }
                    }


                    inp = Console.ReadLine();
                }

                foreach (Person person in persons)
                {
                    if (person.List.Count == 0)
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                    else
                    {
                        Console.Write($"{person.Name} - ");

                        int counter = person.List.Count;
                        foreach (Product product in person.List)
                        {
                            if (counter > 1)
                            {
                                Console.Write($"{product.Name}, ");
                                counter--;
                            }
                            else
                            {
                                Console.WriteLine($"{product.Name}");
                            }

                        }
                        // Console.WriteLine(string.Join(", ", person.List.));
                    }
                }
            }

            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Input have to consist of: Name and Money");
                return;
            }
            catch (FormatException)
            {
                Console.WriteLine("Money parameter have to be a digit");
                return;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
