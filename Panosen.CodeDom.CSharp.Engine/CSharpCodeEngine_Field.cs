using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine
{
    partial class CSharpCodeEngine
    {
        /// <summary>
        /// 生成字段
        /// </summary>
        /// <param name="codeField"></param>
        /// <param name="codeWriter"></param>
        /// <param name="options"></param>
        public void GenerateField(CodeField codeField, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeField == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            GenerateSummary(codeField.Summary, codeWriter, options);

            codeWriter.Write(options.IndentString);

            if (codeField.AccessModifiers != AccessModifiers.None)
            {
                codeWriter.Write(codeField.AccessModifiers.Value()).Write(Marks.WHITESPACE);
            }
            else
            {
                codeWriter.Write(AccessModifiers.Private.Value()).Write(Marks.WHITESPACE);
            }

            if (codeField.IsStatic)
            {
                codeWriter.Write(Keywords.STATIC).Write(Marks.WHITESPACE);
            }

            if (codeField.IsReadOnly)
            {
                codeWriter.Write(Keywords.READONLY).Write(Marks.WHITESPACE);
            }

            if (codeField.IsVolatile)
            {
                codeWriter.Write(Keywords.VOLATILE).Write(Marks.WHITESPACE);
            }

            codeWriter.Write(codeField.Type ?? string.Empty).Write(Marks.WHITESPACE);

            codeWriter.Write(codeField.Name ?? string.Empty);

            if (!string.IsNullOrEmpty(codeField.Value))
            {
                codeWriter.Write(Marks.WHITESPACE).Write(Marks.EQUAL).Write(Marks.WHITESPACE).Write(codeField.Value);
            }

            codeWriter.WriteLine(Marks.SEMICOLON);
        }
    }
}
