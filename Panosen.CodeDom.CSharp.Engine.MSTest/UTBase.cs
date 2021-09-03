using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Panosen.CodeDom.CSharp.Engine.MSTest
{
    public abstract class UTBase
    {
        [TestMethod]
        public void Test()
        {
            var option = PrepareCode();

            CSharpCodeEngine generator = new CSharpCodeEngine();

            StringBuilder builder = new StringBuilder();

            generator.Generate(option, builder);

            var actual = builder.ToString();

            var expeced = PrepareExpected();

            Assert.AreEqual(expeced, actual);
        }

        protected abstract string PrepareExpected();

        protected abstract Code PrepareCode();
    }
}
