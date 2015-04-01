using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TDD.CustomEngine
{
    public class PortableUnitTestCustomEngine<TestClass, TestMethod, TestInit>
    {
        public int NbMethod { get; set; }
        public int NbSuccess { get; set; }
        public void Test(Assembly assembly)
        {
            Type[] types = assembly.GetTypes();
            foreach (Type type in types.Where(t => t.GetCustomAttributes().Any(a => a.GetType().Name == typeof(TestClass).Name)).OrderBy(t => t.FullName))
                Test(type);
        }
        public void Test()
        {
            Test(typeof(PortableUnitTestCustomEngine<,,>).Assembly);
        }

        public delegate void MethodHandler(MethodInfo mi, string s, Exception ex);
        public event MethodHandler MethodEvent;
        public void Test(Type type)
        {
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            object instance = Activator.CreateInstance(type);
            MethodInfo met = methods.FirstOrDefault(m => m.GetCustomAttributes().Any(a => a.GetType().Name == typeof(TestInit).Name));
            if (met != null)
            {
                Exception ex = Test(instance, met);
                string s = type.Name + "." + met.Name + " ";
                s += ex == null ? "initialized" : ex.StackTrace;
                if (MethodEvent != null)
                    MethodEvent(met, s, ex);
            }
            foreach (MethodInfo method in methods.Where(m => m.GetCustomAttributes().Any(a => a.GetType().Name == typeof(TestMethod).Name)).OrderBy(m => m.Name))
            {
                NbMethod++;
                DateTime dt = DateTime.Now;
                Exception ex = Test(instance, method);
                if (ex == null) NbSuccess++;
                string s = type.Name + "." + method.Name + " ";
                s += ex == null ? "ok" : ex.StackTrace;
                s += String.Format(" ({0:N0} ms)", (DateTime.Now - dt).TotalMilliseconds);
                if (MethodEvent != null)
                    MethodEvent(method, s, ex);
            }
        }

        private Exception Test(object instance, MethodInfo method)
        {
            Exception result = null;
            try
            {
                method.Invoke(instance, null);
            }
            catch (Exception ex)
            {
                result = ex.InnerException;
            }
            return result;
        }
    }
}
