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
        /// 生成接口
        /// </summary>
        public void GenerateInterface(CodeWriter codeWriter, CodeInterface codeInterface, GenerateOptions options = null)
        {
            if (codeInterface == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            GenerateSummary(codeInterface.Summary, codeWriter, options);

            codeWriter.Write(options.IndentString);

            if (codeInterface.AccessModifiers != AccessModifiers.None)
            {
                codeWriter.Write(codeInterface.AccessModifiers.Value()).Write(Marks.WHITESPACE);
            }

            if (codeInterface.IsPartial)
            {
                codeWriter.Write(Keywords.PARTIAL).Write(Marks.WHITESPACE);
            }

            codeWriter.Write(Keywords.INTERFACE).Write(Marks.WHITESPACE).Write(codeInterface.Name ?? string.Empty);

            if (codeInterface.ParentInterfaceList != null && codeInterface.ParentInterfaceList.Count > 0)
            {
                codeWriter.Write(Marks.COLON);
                for (int i = 0; i < codeInterface.ParentInterfaceList.Count; i++)
                {
                    codeWriter.Write(Marks.WHITESPACE).Write(codeInterface.ParentInterfaceList[i].Name);
                    if (i < codeInterface.ParentInterfaceList.Count - 1)
                    {
                        codeWriter.Write(Marks.COMMA);
                    }
                }
            }

            codeWriter.WriteLine();

            codeWriter.Write(options.IndentString).WriteLine(Marks.LEFT_BRACE);

            options.PushIndent();

            if (codeInterface.MethodList != null && codeInterface.MethodList.Count > 0)
            {
                foreach (var codeMethod in codeInterface.MethodList)
                {
                    codeWriter.WriteLine();
                    GenerateMethod(codeWriter, codeMethod, options);
                }
            }

            options.PopIndent();

            codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
        }
    }
}
