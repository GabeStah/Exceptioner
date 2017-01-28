using System;
using System.Collections;
using System.Collections.Generic;

namespace Exceptioner
{
    public class TypeHierarchy : IEnumerable<string>
    {
        public List<Type> Hierarchy { get; }

        public TypeHierarchy(Type type)
        {
            this.Hierarchy = new List<Type>();
            this.IterateHierarchy(type);
        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach (Type type in this.Hierarchy)
            {
                yield return type.FullName;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void IterateHierarchy(Type type)
        {
            // If BaseType exists, iterate again
            if (type.BaseType != null)
            {
                // Recursively check for additional base type
                this.IterateHierarchy(type.BaseType);
            }
            // Add to hierarchy
            this.Hierarchy.Add(type);
        }
    }
}
