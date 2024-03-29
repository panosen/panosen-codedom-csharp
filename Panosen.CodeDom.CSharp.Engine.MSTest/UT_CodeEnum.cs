﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Panosen.CodeDom.CSharp.Engine.MSTest
{
    [TestClass]
    public class UT_CodeEnum
    {
        [TestMethod]
        public void Test()
        {
            var code = PrepareCode();

            CSharpCodeEngine generator = new CSharpCodeEngine();

            StringBuilder builder = new StringBuilder();

            generator.GenerateEnum(new StringWriter(builder), code);

            var actual = builder.ToString();

            var expeced = PrepareExpected();

            Assert.AreEqual(expeced, actual);
        }

        protected string PrepareExpected()
        {
            return @"/// <summary>
/// 状态
/// </summary>
public enum Status
{

    A_0,

    A_1,

    A_2,

    /// <summary>
    /// of 0
    /// </summary>
    B_0,

    /// <summary>
    /// of 1
    /// </summary>
    B_1,

    /// <summary>
    /// of 2
    /// </summary>
    B_2,

    C_0 = 10,

    C_1 = 11,

    C_2 = 12
}
";
        }

        protected CodeEnum PrepareCode()
        {
            CodeEnum codeEnum = new CodeEnum();
            codeEnum.Name = "Status";
            codeEnum.Summary = "状态";
            codeEnum.AccessModifiers = AccessModifiers.Public;

            for (int i = 0; i < 3; i++)
            {
                codeEnum.AddValue($"A_{i}");
            }

            for (int i = 0; i < 3; i++)
            {
                codeEnum.AddValue($"B_{i}", summary: $"of {i}");
            }

            for (int i = 0; i < 3; i++)
            {
                codeEnum.AddValue($"C_{i}", value: (DataValue)(i + 10));
            }

            return codeEnum;
        }
    }
}
