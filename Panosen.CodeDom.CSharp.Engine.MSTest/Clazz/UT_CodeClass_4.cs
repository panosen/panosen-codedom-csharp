﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Panosen.CodeDom.CSharp.Engine.MSTest
{
    [TestClass]
    public class UT_CodeClass_4: UTCodeClassBase
    {
        protected override string PrepareExpected()
        {
            return @"/// <summary>
/// 学生
/// </summary>
public class Student<TAdd, TMinus, TCalc>
    where TAdd : Add
    where TMinus : Minus, IMinus
{
}
";
        }

        protected override CodeClass PrepareCode()
        {
            CodeClass codeClass = new CodeClass();
            codeClass.Name = "Student";
            codeClass.Summary = "学生";
            codeClass.AccessModifiers = AccessModifiers.Public;

            codeClass.AddGenericParameter("TAdd").AddConstraint("Add");
            codeClass.AddGenericParameter("TMinus").AddConstraint("Minus", "IMinus");
            codeClass.AddGenericParameter("TCalc");

            return codeClass;
        }
    }
}
