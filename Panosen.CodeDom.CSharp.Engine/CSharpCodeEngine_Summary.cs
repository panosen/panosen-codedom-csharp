﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine
{
    partial class CSharpCodeEngine
    {
        /// <summary>
        /// 生成摘要
        /// </summary>
        public void GenerateSummary(string summary, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (string.IsNullOrEmpty(summary))
            {
                return;
            }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            var lines = summary.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            codeWriter.Write(options.IndentString).WriteLine("/// <summary>");
            foreach (var line in lines)
            {
                codeWriter.Write(options.IndentString).Write("/// ").WriteLine(line);
            }
            codeWriter.Write(options.IndentString).WriteLine("/// </summary>");
        }
    }
}
