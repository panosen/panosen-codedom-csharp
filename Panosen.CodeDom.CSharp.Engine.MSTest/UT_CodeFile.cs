using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Panosen.CodeDom.CSharp.Engine.MSTest
{
    [TestClass]
    public class UT_CodeFile
    {
        [TestMethod]
        public void TestMethod1()
        {
            var option = GetData();

            CSharpCodeEngine generator = new CSharpCodeEngine();

            StringBuilder builder = new StringBuilder();

            generator.GenerateCodeFile(option, builder, new GenerateOptions { TabString = "\t" });

            var actual = builder.ToString();

            var expeced = @"using System;
using System.Linq;

using Newtonsoft.Json;

using Sample;

namespace TheNamespace
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
}
";

            Assert.AreEqual(expeced, actual);
        }

        private CodeFile GetData()
        {
            CodeFile codeFile = new CodeFile();

            codeFile.AddSystemUsing(SystemUsing.System);
            codeFile.AddSystemUsing(SystemUsing.SystemLinq);

            codeFile.AddNugetUsing("Newtonsoft.Json");

            codeFile.AddProjectUsing("Sample");

            CodeNamespace codeNamespace = codeFile.AddNamespace("TheNamespace");

            codeNamespace.ClassList = new List<CodeClass>();
            for (int i = 0; i < 2; i++)
            {
                CodeClass codeClass = codeNamespace.AddClass($"MyClass{i}", summary: $"Myclass {i}");
            }

            return codeFile;
        }
    }
}
