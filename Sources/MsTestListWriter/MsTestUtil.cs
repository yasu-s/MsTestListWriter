namespace MsTestListWriter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public static class MsTestUtil
    {
        public static IList<MsTestData> GetMsTestData(string assemblyPath)
        {
            if (File.Exists(assemblyPath)) throw new FileNotFoundException();

            Assembly asm = GetAssembly(assemblyPath);
            IList<Type> classes = GetTestClasses(asm);

            IList<MsTestData> data = new List<MsTestData>();

            foreach (Type t in classes)
            {
                IList<MethodInfo> mi = GetTestMethods(t);

                foreach (MethodInfo m in mi)
                {
                    MsTestData d = new MsTestData();
                    d.TypeName = t.FullName;
                    d.MethodName = m.Name;
                    data.Add(d);
                }
            }

            return data;
        }

        private static Assembly GetAssembly(string assemblyPath)
        {
            return Assembly.LoadFrom(assemblyPath);
        }

        private static IList<Type> GetTestClasses(Assembly asm)
        {
            IList<Type> classes = new List<Type>();

            foreach (Type type in asm.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(TestClassAttribute), false).Length > 0)
                {
                    classes.Add(type);
                }
            }

            return classes;
        }

        private static IList<MethodInfo> GetTestMethods(Type type)
        {
            IList<MethodInfo> methods = new List<MethodInfo>();

            foreach (MethodInfo m in type.GetMethods())
            {
                if (m.GetCustomAttributes(typeof(TestMethodAttribute), false).Length > 0)
                {
                    methods.Add(m);
                }
            }

            return methods;
        }

    }
}
