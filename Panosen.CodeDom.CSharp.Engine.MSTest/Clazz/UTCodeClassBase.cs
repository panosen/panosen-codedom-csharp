using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine.MSTest
{
    public abstract class UTCodeClassBase
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

        protected abstract string PrepareExpected();

        protected abstract CodeClass PrepareCode();
    }
}
