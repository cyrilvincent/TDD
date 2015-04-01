using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.CustomEngine;
using TDD.IntegrationTests;
using TDD.Tests;

namespace TDD.TestConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing");
            PortableUnitTestCustomEngine<TestClassAttribute, TestMethodAttribute, TestInitializeAttribute> test = new PortableUnitTestCustomEngine<TestClassAttribute, TestMethodAttribute, TestInitializeAttribute>();
            test.MethodEvent += test_MethodEvent;
            test.Test(typeof(ServiceIntegrationTests).Assembly);
            Console.WriteLine(test.NbSuccess + "/" + test.NbMethod + " success");
            test.Test(typeof(ServiceTests).Assembly);
            Console.WriteLine(test.NbSuccess + "/" + test.NbMethod + " success");
            Console.ReadKey();
            

        }

        static void test_MethodEvent(System.Reflection.MethodInfo mi, string s, Exception ex)
        {
            Console.WriteLine(mi.Name + ": " + s);
        }
    }
}
