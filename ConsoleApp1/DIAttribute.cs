using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ResgisterTransientAttribute: Attribute
    {
        public ResgisterTransientAttribute(params Type[] registeredTypes)
        {
            RegisteredTypes = registeredTypes;
        }

        public Type[] RegisteredTypes { get; set; }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class RegisterScopedAttribute : Attribute
    {
        public RegisterScopedAttribute(params Type[] registeredTypes)
        {
            RegisteredTypes = registeredTypes;
        }

        public Type[] RegisteredTypes { get; set; }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class RegisterSingletonAttribute : Attribute
    {
        public RegisterSingletonAttribute(params Type[] registeredTypes)
        {
            RegisteredTypes = registeredTypes;
        }

        public Type[] RegisteredTypes { get; set; }
    }
}
