﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.CSharp.Engine.MSTest
{
    [TestClass]
    public class UT_CodeBinaryOperatorExpression
    {
        [TestMethod]
        public void Test()
        {
            var option = PrepareCode();

            CSharpCodeEngine generator = new CSharpCodeEngine();

            StringBuilder builder = new StringBuilder();

            generator.GenerateBinaryOperatorExpresion(option, builder, new GenerateOptions());

            var actual = builder.ToString();

            var expeced = PrepareExpected();

            Assert.AreEqual(expeced, actual);
        }

        protected BinaryOperatorExpression PrepareCode()
        {
            BinaryOperatorExpression codeExpression = new BinaryOperatorExpression();
            codeExpression.Operator = EnumBinaryOperator.Add;
            codeExpression.Left = "a";
            codeExpression.Right = "b";

            return codeExpression;
        }

        protected string PrepareExpected()
        {
            return @"a + b";
        }
    }
}
