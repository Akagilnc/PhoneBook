using System;
using ConsoleApp.ServiceReference1;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Begin========");
            var client = new Service1Client();
            var time = client.GetServerTime();
            var name = client.GetServerName();
            
            Console.WriteLine(time + "   " + name);
            Console.ReadKey();

        }
    }
}