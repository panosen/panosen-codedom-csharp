﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.CSharp.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_StepStatementChain_4 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            var chain = codeMethod.StepStatementChain("services");
            {
                chain.AddCallMethodExpression("AddAuth").AddParameter("Scheme");
            }
            {
                var exp = chain.AddCallMethodExpression("AddJwtBearer");
                exp.AddParameter("OK");
                var builders = exp.AddParameterOfLamdaStepCollection().SetParameter("options");
                builders.StepStatement("//ok");
                builders.StepStatement("x = 1;");
            }
        }

        protected override string PrepareExpected()
        {
            return @"public TestMethod()
{
    services.AddAuth(Scheme).AddJwtBearer(OK, options =>
    {
        //ok
        x = 1;
    });
}
";
        }
    }
}
