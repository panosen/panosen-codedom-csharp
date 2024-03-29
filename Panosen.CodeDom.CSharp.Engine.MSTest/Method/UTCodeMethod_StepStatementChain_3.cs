﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.CSharp.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_StepStatementChain_3 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            var chain = codeMethod.StepStatementChain("services");
            chain.AddCallMethodExpression("AddAuth").AddParameter("Scheme");
            var exp = chain.AddCallMethodExpression("AddJwtBearer");
            exp.AddParameter("OK");
            var builders = exp.AddParameterOfLamdaStepCollection();
            builders.StepStatement("//ok");
            builders.StepStatement("x = 1;");
        }

        protected override string PrepareExpected()
        {
            return @"public TestMethod()
{
    services.AddAuth(Scheme).AddJwtBearer(OK,  =>
    {
        //ok
        x = 1;
    });
}
";
        }
    }
}
