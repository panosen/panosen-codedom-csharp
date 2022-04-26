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
        /// <param name="codeNamespace"></param>
        /// <param name="codeWriter"></param>
        /// <param name="options"></param>
        public void GenerateNamespace(CodeNamespace codeNamespace, CodeWriter codeWriter, GenerateOptions options = null)
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
                    GenerateClass(codeClass, codeWriter, options);
                }
            }

            if (codeNamespace.InterfaceList != null && codeNamespace.InterfaceList.Count > 0)
            {
                foreach (var codeInterface in codeNamespace.InterfaceList)
                {
                    codeWriter.WriteLine();
                    GenerateInterface(codeInterface, codeWriter, options);
                }
            }

            if (codeNamespace.EnumList != null && codeNamespace.EnumList.Count > 0)
            {
                foreach (var codeEnum in codeNamespace.EnumList)
                {
                    codeWriter.WriteLine();
                    GenerateEnum(codeEnum, codeWriter, options);
                }
            }

            options.PopIndent();

            codeWriter.WriteLine(Marks.RIGHT_BRACE);
        }
    }
}
