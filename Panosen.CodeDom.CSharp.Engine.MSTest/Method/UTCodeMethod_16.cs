using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.CSharp.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_16 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            var tryStep = codeMethod.StepTry();
            tryStep.StepStatement("var xx=0;");
            tryStep.StepStatement("var yy = 90;");
            var catch1 = tryStep.WithCatch("ok");
            catch1.StepStatement("//catch1");
            var catch2 = tryStep.WithCatch("catch2");
            catch2.StepStatement("okok2");
            catch2.StepStatement("okok22");
            var finally2 = tryStep.WithFinally();
            finally2.StepStatement("finaly");
        }

        protected override string PrepareExpected()
        {
            return @"public TestMethod()
{
    try
    {
        var xx=0;
        var yy = 90;
    }
    catch (ok)
    {
        //catch1
    }
    catch (catch2)
    {
        okok2
        okok22
    }
    finally
    {
        finaly
    }
}
";
        }
    }
}
