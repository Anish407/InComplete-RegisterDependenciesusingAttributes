// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;

Type scopedAttribute = typeof(RegisterScopedAttribute);
Type transientAttribute = typeof(ResgisterTransientAttribute);
Type singletonAttribute = typeof(RegisterSingletonAttribute);
Type[] types = new Type[] { scopedAttribute, transientAttribute, singletonAttribute };

var services = new ServiceCollection();

var typesInAssemble = Assembly.GetExecutingAssembly().GetTypes()
                        .Where(p => p.IsDefined(scopedAttribute)
                                   || p.IsDefined(transientAttribute)
                                   || p.IsDefined(singletonAttribute) && !p.IsInterface)
                        .Select(i => new
                        {
                            service = i,
                            //attributeCtor = i.CustomAttributes,
                            hasContructorArgs = i.CustomAttributes.Any(i=> i.ConstructorArguments.Any()),
                            interfaces = i.GetInterfaces()
                        }).ToList();


foreach (var item in typesInAssemble)
{

    if (item.hasContructorArgs)
    {
        Attribute[] attrs = Attribute.GetCustomAttributes(item.service);
        foreach (System.Attribute attr in attrs)
        {
            if (attr is ResgisterTransientAttribute)
            {
                ResgisterTransientAttribute attribute = (ResgisterTransientAttribute)attr;
                foreach (var a in attribute.RegisteredTypes)
                {
                    services.AddTransient(a,item.service);
                }
            }
            else if (attr is RegisterSingletonAttribute)
            {
                RegisterSingletonAttribute attribute = (RegisterSingletonAttribute)attr;
                foreach (var a in attribute.RegisteredTypes)
                {
                    services.AddSingleton(a, item.service);
                }
            }
            else
            {
                RegisterScopedAttribute attribute = (RegisterScopedAttribute)attr;
                foreach (var a in attribute.RegisteredTypes)
                {
                    services.AddScoped(a, item.service);
                }
            }
        }
    }

   
}


    //var typesInAssemble = Assembly.GetExecutingAssembly().GetTypes()
    //                        .Where(p => p.IsDefined(scopedAttribute)
    //                                   || p.IsDefined(transientAttribute)
    //                                   || p.IsDefined(singletonAttribute) && !p.IsInterface)
    //                        .Select(i => new
    //                        {
    //                            service = i,
    //                            attributeCtor = i.CustomAttributes.Select(i => i.NamedArguments).SelectMany(i => i.Select(x => x.TypedValue)).ToList(),
    //                            //attributeCtor1 = i.CustomAttributes.SelectMany(i=> i.ConstructorArguments).Select(i=> i.Value).ToList(),
    //                            interfaces = i.GetInterfaces()
    //                        }).ToList();

//.Select(i => new
//{
//    i,
//    attributeType = i.CustomAttributes.FirstOrDefault(i => types.Contains(i.AttributeType)).,
//    implementedInterfaces = i.GetInterfaces()
//});





//    }




Console.WriteLine("Hello, World!");
Console.ReadLine();
