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
        /// 生成cs文件
        /// </summary>
        /// <param name="codeFile"></param>
        /// <param name="codeWriter"></param>
        /// <param name="options"></param>
        public void GenerateCodeFile(CodeFile codeFile, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeFile == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            GenerateUsing(codeWriter, codeFile);

            GenerateNamespaceList(codeWriter, codeFile.NamespaceList, options);
        }

        private void GenerateUsing(CodeWriter codeWriter, CodeFile codeFile)
        {
            if (codeFile.SystemUsingList != null && codeFile.SystemUsingList.Count > 0)
            {
                WriteUsing(codeWriter, codeFile.SystemUsingList.Distinct().OrderBy(v => v).ToList());
            }
            if (codeFile.NugetUsingList != null && codeFile.NugetUsingList.Count > 0)
            {
                WriteUsing(codeWriter, codeFile.NugetUsingList.Distinct().OrderBy(v => v).ToList());
            }
            if (codeFile.ProjectUsingList != null && codeFile.ProjectUsingList.Count > 0)
            {
                WriteUsing(codeWriter, codeFile.ProjectUsingList.Distinct().OrderBy(v => v).ToList());
            }
        }

        private void GenerateNamespaceList(CodeWriter codeWriter, List<CodeNamespace> namespaceList, GenerateOptions options)
        {
            if (namespaceList == null || namespaceList.Count == 0)
            {
                return;
            }

            foreach (var codeNamespace in namespaceList)
            {
                GenerateNamespace(codeNamespace, codeWriter, options);
            }
        }

        private void WriteUsing(CodeWriter codeWriter, List<string> usingList)
        {
            if (usingList.Count <= 0)
            {
                return;
            }

            foreach (var usingItem in usingList)
            {
                codeWriter.Write("using ").Write(usingItem).WriteLine(";");
            }

            codeWriter.WriteLine();
        }
    }
}

