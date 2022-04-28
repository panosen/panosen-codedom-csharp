using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Panosen.CodeDom.CSharp.Engine.MSTest
{
    [TestClass]
    public class UT_CodeClass_5 : UTBase
    {
        protected override string PrepareExpected()
        {
            return @"/// <summary>
/// 学生
/// </summary>
public class Student
{

    [Newtonsoft.Json.JsonProperty(""age"", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int Age { get; set; }
}
";
        }

        protected override Code PrepareCode()
        {
            CodeClass codeClass = new CodeClass();
            codeClass.Name = "Student";
            codeClass.Summary = "学生";
            codeClass.AccessModifiers = AccessModifiers.Public;

            var codeProperty = codeClass.AddProperty("int", "Age");

            codeProperty.AddAttribute("Newtonsoft.Json.JsonProperty")
                .AddStringParam("age")
                .AddPlainParam("NullValueHandling", "Newtonsoft.Json.NullValueHandling.Ignore");

            return codeClass;
        }
    }
}
