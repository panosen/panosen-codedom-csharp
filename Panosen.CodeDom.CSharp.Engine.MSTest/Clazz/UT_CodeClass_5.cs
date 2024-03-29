﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Panosen.CodeDom.CSharp.Engine.MSTest
{
    [TestClass]
    public class UT_CodeClass_5: UTCodeClassBase
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

    [Newtonsoft.Json.JsonProperty(""name"")]
    public string Name { get; set; }

    [Newtonsoft.Json.JsonProperty(key = ""123"")]
    public string Remark { get; set; }
}
";
        }

        protected override CodeClass PrepareCode()
        {
            CodeClass codeClass = new CodeClass();
            codeClass.Name = "Student";
            codeClass.Summary = "学生";
            codeClass.AccessModifiers = AccessModifiers.Public;

            codeClass.AddProperty("int", "Age")
                .AddAttribute("Newtonsoft.Json.JsonProperty")
                .AddStringParam("age")
                .AddPlainParam("NullValueHandling", "Newtonsoft.Json.NullValueHandling.Ignore");

            codeClass.AddProperty("string", "Name")
                .AddAttribute("Newtonsoft.Json.JsonProperty")
                .AddStringParam("name");

            codeClass.AddProperty("string", "Remark")
                .AddAttribute("Newtonsoft.Json.JsonProperty")
                .AddStringParam("key", "123");

            return codeClass;
        }
    }
}
