using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Panosen.CodeDom.CSharp.Engine.MSTest.Method
{
    public abstract class UTCodeMethodBase
    {
        [TestMethod]
        public void Test()
        {
            var code = PrepareCode();

            CSharpCodeEngine generator = new CSharpCodeEngine();

            StringBuilder builder = new StringBuilder();

            generator.GenerateMethod(new StringWriter(builder), code);

            var actual = builder.ToString();

            var expeced = PrepareExpected();

            Assert.AreEqual(expeced, actual);
        }

        protected abstract string PrepareExpected();

        protected abstract void PrepareCodeMethod(CodeMethod codeMethod);

        private CodeMethod PrepareCode()
        {
            CodeMethod codeMethod = new CodeMethod();
            codeMethod.AccessModifiers = AccessModifiers.Public;
            codeMethod.Name = "TestMethod";

            PrepareCodeMethod(codeMethod);

            return codeMethod;
        }
    }
}
