using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.CSharp.Engine.MSTest
{
    [TestClass]
    public class UT_CodeNamespace : UTBase
    {
        protected override Code PrepareCode()
        {
            CodeNamespace codeNamespace = new CodeNamespace();
            codeNamespace.Name = "TheNamespace";

            codeNamespace.ClassList = new List<CodeClass>();
            for (int i = 0; i < 3; i++)
            {
                CodeClass codeClass = new CodeClass();
                codeNamespace.ClassList.Add(codeClass);


                codeClass.Name = $"MyClass{i}";
                codeClass.Summary = $"Myclass {i}";
            }

            return codeNamespace;
        }

        protected override string PrepareExpected()
        {
            return @"namespace TheNamespace
{

    /// <summary>
    /// Myclass 0
    /// </summary>
    class MyClass0
    {
    }

    /// <summary>
    /// Myclass 1
    /// </summary>
    class MyClass1
    {
    }

    /// <summary>
    /// Myclass 2
    /// </summary>
    class MyClass2
    {
    }
}
";
        }
    }
}
