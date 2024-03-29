﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine
{
    /// <summary>
    /// 生成表达式
    /// </summary>
    partial class CSharpCodeEngine
    {
        /// <summary>
        /// GenerateReferenceExpression
        /// </summary>
        public void GenerateReferenceExpression(ReferenceExpression codeExpression, CodeWriter codeWriter, GenerateOptions options)
        {
            if (codeExpression == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            if (codeExpression.Target == null) { return; }
            if (codeExpression.Reference == null) { return; }

            GenerateExpresion(codeWriter, codeExpression.Target, options);
            codeWriter.Write(".");

            GenerateExpresion(codeWriter, codeExpression.Reference, options);
        }
    }
}
