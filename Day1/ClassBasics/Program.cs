//using System;

namespace ClassBasics
{
    internal class Program
    {
        static void Main1()
        {
            //Payroll.Employee o = new Payroll.Employee();
            Console.WriteLine("Hello, World!");
            System.Console.WriteLine("Hello World");

        }
        static void Main()
        {
            //Class1 o; //reference
            //o = new Class1(); //object

            Class1 o = new Class1();
            o.Display();
            o.Display("hello");

            //positional parameter
            Console.WriteLine(o.Add(10, 5, 3));
            Console.WriteLine(o.Add(10, 5));
            Console.WriteLine(o.Add(10));
            Console.WriteLine(o.Add());

            //named parameters
            Console.WriteLine(o.Add(c: 10));
            Console.WriteLine(o.Add(b: 10));
            Console.WriteLine(o.Add(c:5, b: 10));

        }
    }
    public class Class1 //: Object
    {
        public void Display()
        {
            Console.WriteLine("Display");
        }
        public void Display(string s)  //overloading
        {
            Console.WriteLine("Display" + s);
        }
        //public int Add(int a, int b)
        //{
        //    return a + b;
        //}
        //public int Add(int a, int b, int c)
        //{
        //    return a + b+c;
        //}

        //default values
        //optional parameters
        public int Add(int a = 0, int b = 0, int c = 0)
        {
            return a + b + c;
        }

        //okay - def values given right to left
        //public int Add(int a, int b , int c = 0)
        //{
        //    return a + b + c;
        //}


        //error
        //public int Add(int a=0, int b, int c)
        //{
        //    return a + b + c;
        //}
       

        public void DoSomething()
        {
            int i = 100;
            DoSomething2();  //can only be called from outer function


            //local function - func defined within another function
            void DoSomething2()
            {
                //local functions can access local variables
                //declared in the outer function
                Console.WriteLine(i);
            }

            //TO DO - Try to overload a local function
        }

    }
}
namespace Payroll
{
    public class Employee { }
    public class Department { }
}

namespace MyNamespace
{
    public class Class1 { }
    namespace n1
    {
        public class Class2 { }
    }

}
