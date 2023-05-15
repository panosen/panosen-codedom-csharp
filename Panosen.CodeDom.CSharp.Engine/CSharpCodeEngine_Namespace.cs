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
        /// 生成命名空间
        /// </summary>
        public void GenerateNamespace(CodeWriter codeWriter, CodeNamespace codeNamespace, GenerateOptions options = null)
        {
            if (codeNamespace == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            GenerateSummary(codeNamespace.Summary, codeWriter, options);

            codeWriter.Write(options.IndentString).Write(Keywords.NAMESPACE).Write(Marks.WHITESPACE).WriteLine(codeNamespace.Name ?? string.Empty);

            codeWriter.WriteLine(Marks.LEFT_BRACE);

            options.PushIndent();

            if (codeNamespace.ClassList != null && codeNamespace.ClassList.Count > 0)
            {
                foreach (var codeClass in codeNamespace.ClassList)
                {
                    codeWriter.WriteLine();
                    GenerateClass(codeWriter, codeClass, options);
                }
            }

            if (codeNamespace.InterfaceList != null && codeNamespace.InterfaceList.Count > 0)
            {
                foreach (var codeInterface in codeNamespace.InterfaceList)
                {
                    codeWriter.WriteLine();
                    GenerateInterface(codeWriter, codeInterface, options);
                }
            }

            if (codeNamespace.EnumList != null && codeNamespace.EnumList.Count > 0)
            {
                foreach (var codeEnum in codeNamespace.EnumList)
                {
                    codeWriter.WriteLine();
                    GenerateEnum(codeWriter, codeEnum, options);
                }
            }

            options.PopIndent();

            codeWriter.WriteLine(Marks.RIGHT_BRACE);
        }
    }
}
