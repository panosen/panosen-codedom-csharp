﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.CSharp.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_3 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            var usingStep = codeMethod.StepUsing();
            usingStep.Use("var conn = new SqlConnection(null)");
            usingStep.StepStatement("name = age.ToString();")
                .StepStatement("name = age.ToString();");
        }

        protected override string PrepareExpected()
        {
            return @"public TestMethod()
{
    using (var conn = new SqlConnection(null))
    {
        name = age.ToString();
        name = age.ToString();
    }
}
";
        }
    }
}
