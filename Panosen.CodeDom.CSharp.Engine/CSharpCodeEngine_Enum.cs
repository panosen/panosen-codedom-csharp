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
        /// 生成类
        /// </summary>
        public void GenerateEnum(CodeWriter codeWriter, CodeEnum codeEnum,  GenerateOptions options = null)
        {
            if (codeEnum == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            GenerateSummary(codeEnum.Summary, codeWriter, options);

            codeWriter.Write(options.IndentString);

            if (codeEnum.AccessModifiers != AccessModifiers.None)
            {
                codeWriter.Write(codeEnum.AccessModifiers.Value()).Write(Marks.WHITESPACE);
            }

            codeWriter.Write(Keywords.ENUM).Write(Marks.WHITESPACE).Write(codeEnum.Name ?? string.Empty);

            codeWriter.WriteLine();

            codeWriter.Write(options.IndentString).WriteLine(Marks.LEFT_BRACE);

            options.PushIndent();

            if (codeEnum.ValueList != null && codeEnum.ValueList.Count > 0)
            {
                var enumerator = codeEnum.ValueList.GetEnumerator();
                var moveNext = enumerator.MoveNext();
                while (moveNext)
                {
                    codeWriter.WriteLine();
                    GenerateEnumValue(enumerator.Current, codeWriter, options);

                    moveNext = enumerator.MoveNext();
                    if (moveNext)
                    {
                        codeWriter.Write(Marks.COMMA);
                    }

                    codeWriter.WriteLine();
                }
            }

            options.PopIndent();

            codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
        }
    }
}
