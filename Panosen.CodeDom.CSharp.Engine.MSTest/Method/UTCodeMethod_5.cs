using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.CSharp.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_5 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            var ifStep = codeMethod.StepIf("1").StepStatement("ok");
            ifStep.WithElseIf("b").StepStatement("333");
            ifStep.WithElseIf("b2").StepStatement("3343");
            ifStep.WithElse().StepStatement("okok");
        }

        protected override string PrepareExpected()
        {
            return @"public TestMethod()
{
    if (1)
    {
        ok
    }
    else if (b)
    {
        333
    }
    else if (b2)
    {
        3343
    }
    else
    {
        okok
    }
}
";
        }
    }
}
