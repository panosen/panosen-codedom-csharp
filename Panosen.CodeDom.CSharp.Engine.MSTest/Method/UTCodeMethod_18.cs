using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.CSharp.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_18 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            codeMethod.StepEmpty();

            var x1 = new StepCollection();
            x1.StepStatement("var x = 1;");

            var x2 = new StatementStep();
            x2.Statement = "var y = 2;";

            codeMethod.StepCollection = new StepCollection();

            codeMethod.StepCollection.AddStepCollection(x1);

            codeMethod.StepCollection.AddStep(x2);

            var x3 = codeMethod.AddStepCollection();
            x3.StepStatement("var x3;");

            var x4 = codeMethod.AddStepCollection("x4");
            x4.StepStatement("var x4;");

            var x5 = codeMethod.AddStepCollection("x5");
            x5.StepStatement("var x5;");

            var x5s = codeMethod.StepCollection["x5"] as StepCollection;
            x5s.StepStatement("x5 = 5;");

            var x4s = codeMethod.StepCollection["x4"] as StepCollection;
            x4s.StepStatement("x4 = 4;");
        }

        protected override string PrepareExpected()
        {
            return @"public TestMethod()
{
    var x = 1;
    var y = 2;
    var x3;
    var x4;
    x4 = 4;
    var x5;
    x5 = 5;
}
";
        }
    }
}
