using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Panosen.CodeDom.CSharp.Engine.MSTest
{
    [TestClass]
    public class UT_CodeInterface
    {
        [TestMethod]
        public void Test()
        {
            var code = PrepareCode();

            CSharpCodeEngine generator = new CSharpCodeEngine();

            StringBuilder builder = new StringBuilder();

            generator.GenerateInterface(new StringWriter(builder), code);

            var actual = builder.ToString();

            var expeced = PrepareExpected();

            Assert.AreEqual(expeced, actual);
        }

        protected CodeInterface PrepareCode()
        {
            CodeInterface codeInterface = new CodeInterface();
            codeInterface.Name = "IStudentRepository";
            codeInterface.Summary = "Student";
            codeInterface.AccessModifiers = AccessModifiers.Public;
            codeInterface.IsPartial = true;

            codeInterface.AddParent("IStudent");
            codeInterface.AddParent("ITeacher");

            codeInterface.MethodList = new List<CodeMethod>();
            for (int i = 0; i < 2; i++)
            {
                var codeMethod = new CodeMethod();
                codeInterface.MethodList.Add(codeMethod);

                codeMethod.Name = $"Method{i}";
                codeMethod.Type = "int";
                codeMethod.Summary = $"Method {i}";

                codeMethod.Parameters = new List<CodeParameter>();
                for (int j = 0; j < 3; j++)
                {
                    var codeParameter = new CodeParameter();
                    codeMethod.Parameters.Add(codeParameter);

                    codeParameter.Name = $"p{j + 1}";
                    codeParameter.Type = "int";
                }
            }

            return codeInterface;
        }

        protected string PrepareExpected()
        {
            return @"/// <summary>
/// Student
/// </summary>
public partial interface IStudentRepository: IStudent, ITeacher
{

    /// <summary>
    /// Method 0
    /// </summary>
    int Method0(int p1, int p2, int p3);

    /// <summary>
    /// Method 1
    /// </summary>
    int Method1(int p1, int p2, int p3);
}
";
        }
    }
}
