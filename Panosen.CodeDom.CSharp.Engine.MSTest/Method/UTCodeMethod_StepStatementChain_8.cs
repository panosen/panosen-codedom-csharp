﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.CSharp.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_StepStatementChain_8 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            var xx = codeMethod.StepStatementChain().AddCallMethodExpression("list.Select");
            var lamda = xx.AddParameterOfLamdaNewInstance();
            lamda.SetClassName("Student");
            lamda.SetParameter("x");
            lamda.StepStatement("DataStatus = 1");
            lamda.StepStatement("LastTimeTime = DateTime.Now");
        }

        protected override string PrepareExpected()
        {
            return @"public TestMethod()
{
    list.Select(x => new Student
    {
        DataStatus = 1,
        LastTimeTime = DateTime.Now
    });
}
";
        }
    }
}
