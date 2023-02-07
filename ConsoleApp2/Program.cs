using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Product : IComparable
    {
        private string name;
        private int price;
        public int Price
        {
            get { return Price; }
        }
        public Product(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public int CompareTo(object obj) 
        {
            
            Product hp = (Product)obj;
             
            if (this.price > hp.price)
            {
                return 1;
            }
            else if (this.price < hp.price)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

    }
    public class Emp
    {
        public string Name { get; set; }
        public double Salary { get; set; }
    }


    public class Test : IComparer
    {
        public int Compare(object x, object y) 
        {
            if (typeof(Emp) == x.GetType()) 
            {
                Emp e1 = (Emp)x;
                Emp e2 = (Emp)y;
                if (e1.Salary > e2.Salary)
                    return 1;
                else if (e1.Salary < e2.Salary)
                    return -1;
                else
                    return 0;
            }
            else if (typeof(Product) == x.GetType()) 
            {
                Product p1 = (Product)x;
                Product p2 = (Product)y;
                if (p1.Price > p2.Price)
                    return 1;
                else if (p1.Price < p2.Price)
                    return -1;
                else
                    return 0;
            }
            else
            {
                return -2;
            }
        }
    }
    public class ComparePrice : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            if (x.Price > y.Price)
                return 1;
            else if (x.Price < y.Price)
                return -1;
            else
                return 0;
        }
    }
    public class CompareSalary : IComparer<Emp>
    {
        public int Compare(Emp x, Emp y)
        {
            if (x.Salary > y.Salary)
                return 1;
            else if (x.Salary < y.Salary)
                return -1;
            else
                return 0;
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                Product hp = new Product("HP laptop", 39000);
                Product dell = new Product("Dell laptop", 39000);

                Emp e1 = new Emp { Name = "Kishor", Salary = 67000 };
                Emp e2 = new Emp { Name = "Amol", Salary = 75000 };

                Test t1 = new Test();
                t1.Compare(dell, hp);

                t1.Compare(e1, e2);


                CompareSalary cs = new CompareSalary();
                cs.Compare(e1, e2);

                ComparePrice cp = new ComparePrice();
                int result = cp.Compare(dell, hp);
                 
                if (result == 1)
                {
                    Console.WriteLine("Dell laptop have more price than hp");
                }
                else if (result == -1)
                {
                    Console.WriteLine("Hp laptop have more price than dell");
                }
                else
                {
                    Console.WriteLine("Both laptops have same price");
                }
            }

        }
    }
    }

