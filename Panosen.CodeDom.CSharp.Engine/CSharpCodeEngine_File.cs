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
            List<string> systemUsing = new List<string>();
            List<string> nugetUsing = new List<string>();
            List<string> projectUsing = new List<string>();

            AddTo(systemUsing, codeFile.NamespaceList.SelectMany(v => v.ClassList.SelectMany(x => x.SystemUsingList ?? new List<string>())).ToList());
            AddTo(nugetUsing, codeFile.NamespaceList.SelectMany(v => v.ClassList.SelectMany(x => x.NugetUsingList ?? new List<string>())).ToList());
            AddTo(projectUsing, codeFile.NamespaceList.SelectMany(v => v.ClassList.SelectMany(x => x.ProjectUsingList ?? new List<string>())).ToList());

            systemUsing = systemUsing.Distinct().OrderBy(v => v).ToList();
            nugetUsing = nugetUsing.Distinct().OrderBy(v => v).ToList();
            projectUsing = projectUsing.Distinct().OrderBy(v => v).ToList();

            WriteUsing(codeWriter, systemUsing);
            WriteUsing(codeWriter, nugetUsing);
            WriteUsing(codeWriter, projectUsing);
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

        private void AddTo(List<string> target, List<string> items)
        {
            if (items == null || items.Count == 0)
            {
                return;
            }

            target.AddRange(items);
        }
    }
}

