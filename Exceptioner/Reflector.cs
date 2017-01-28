using System;
using System.Collections.Generic;
using System.Reflection;

namespace Exceptioner
{
    public class Reflector
    {
        public List<Exceptioner.Exception> exceptionList = new List<Exceptioner.Exception>();

        public Reflector()
        {
            /*
             * Iterate through assemblies.
             * For each assembly, recursively check for assembly.BaseType
             * if .BaseType exists, check for .BaseType of .BaseType, recursively
             * If no .BaseType is found in .BaseType method, add to dictionary.
             * Dictionary key is FullName of type (e.g. System.Object)
             * dict.IsException = boolean whether exception class or not
             * dict.Children = Dictionary of child Dicts containing sub assemblies and exceptions.
             * 
             */
            OutputFile file = new Exceptioner.OutputFile("output.csv");
            int exceptionCount = 0;
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var domainAssembly in assemblies)
            {
                // iterate over all of the modules referenced by this assembly
                Assembly assembly = Assembly.Load(domainAssembly.FullName);
                Module[] modules = assembly.GetModules();
                foreach (Module module in modules)
                {
                    Type[] moduleTypes = module.GetTypes();
                    foreach (Type t in moduleTypes)
                    {
                        // If subclass is Exception type, continue
                        if (t.IsSubclassOf(typeof(Exception)) || t.IsSubclassOf(typeof(SystemException)))
                        {
                            // Create new Exception instance
                            Exceptioner.Exception exception = new Exceptioner.Exception
                            {
                                Id = exceptionCount,
                                Guid = t.GUID,
                                FullName = t.FullName,
                                Name = t.Name,
                                Parents = new TypeHierarchy(t),
                            };
                            // Check that list doesn't contain exception already
                            if (!exceptionList.Contains(exception))
                            {
                                // Iterate simple Id counter
                                exceptionCount++;
                                // Add to list
                                exceptionList.Add(exception);
                            }
                        }
                    }
                }
            }


            // Append exception list data to output file
            foreach (Exceptioner.Exception exception in exceptionList)
            {
                file.Append(exception.OutputToFile());
            }
        }
    }
}
