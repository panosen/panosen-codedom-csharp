using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panosen.CodeDom.CSharp.Engine.MSTest
{
    [TestClass]
    public class UT_CodeAttribute
    {
        [TestMethod]
        public void Test()
        {
            var code = PrepareCode();

            CSharpCodeEngine generator = new CSharpCodeEngine();

            StringBuilder builder = new StringBuilder();

            generator.GenerateClass(new StringWriter(builder), code);

            var actual = builder.ToString();

            var expeced = PrepareExpected();

            Assert.AreEqual(expeced, actual);
        }

        protected string PrepareExpected()
        {
            return @"public class Student
{

    [Apple]
    [Banana(1)]
    [Candy(""2"")]
    [Dog(""3"", name = ""4"")]
    public int Property0 { get; set; }
}
";
        }

        protected CodeClass PrepareCode()
        {
            CodeClass codeClass = new CodeClass();
            codeClass.Name = "Student";
            codeClass.AccessModifiers = AccessModifiers.Public;

            {
                var codeProperty = codeClass.AddProperty("int", $"Property0");
                codeProperty.AddAttribute("Apple");
                codeProperty.AddAttribute("Banana").AddPlainParam("1");
                codeProperty.AddAttribute("Candy").AddStringParam("2");
                codeProperty.AddAttribute("Dog").AddStringParam("3").AddStringParam("name", "4");
            }

            return codeClass;
        }
    }
}
