using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TDD.Entities.Library;
using TDD.Repositories.Library;
using TDD.Repositories.Library.Common;

namespace TDD.Services.Library.IoC
{
    public static class UnityHelper
    {
        private static IUnityContainer container;

        public static void Configure()
        {
            container = new UnityContainer();
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(container);
        }

        public static IUnityContainer Container
        {
            get
            {
                if (container == null) Configure();
                return container;
            }
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
        public static T Resolve<T>(string name)
        {
            return Container.Resolve<T>(name);
        }

        private static T Resolve<T, U>()
        {
            return Container.Resolve<T>(typeof(U).Name);
        }

        /// <summary>
        /// Debug
        /// </summary>
        /// <returns></returns>
        public static string Debug()
        {
            string s = "";
            foreach (ContainerRegistration cr in Container.Registrations)
            {
                s += "From " + cr.RegisteredType.ToString() + " to " + cr.MappedToType.ToString() + " [" + cr.Name + "] in " + cr.LifetimeManagerType.ToString() + Environment.NewLine;
            }
            return s;
        }
    }
}
