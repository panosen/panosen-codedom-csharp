using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp
{
    /// <summary>
    /// csharp code file
    /// </summary>
    public class CodeFile
    {
        /// <summary>
        /// 命名空间
        /// </summary>
        public List<CodeNamespace> NamespaceList { get; set; }

        /// <summary>
        /// 系统引用
        /// </summary>
        public List<string> SystemUsingList { get; set; }

        /// <summary>
        /// 从nuget包里面的引用
        /// </summary>
        public List<string> NugetUsingList { get; set; }

        /// <summary>
        /// 当前项目的引用
        /// </summary>
        public List<string> ProjectUsingList { get; set; }

        /// <summary>
        /// 项目说明
        /// </summary>
        public List<string> MottoList { get; set; }
    }

    /// <summary>
    /// CodeFile 扩展
    /// </summary>
    public static class CodeFileExtension
    {
        /// <summary>
        /// 添加一个命名空间
        /// </summary>
        public static void AddNamespace(this CodeFile codeFile, CodeNamespace codeNamespace)
        {
            if (codeFile.NamespaceList == null)
            {
                codeFile.NamespaceList = new List<CodeNamespace>();
            }

            codeFile.NamespaceList.Add(codeNamespace);
        }

        /// <summary>
        /// 添加一个命名空间
        /// </summary>
        public static CodeNamespace AddNamespace(this CodeFile codeFile, string name, string summary = null)
        {
            if (codeFile.NamespaceList == null)
            {
                codeFile.NamespaceList = new List<CodeNamespace>();
            }

            CodeNamespace codeNamespace = new CodeNamespace();
            codeNamespace.Name = name;
            codeNamespace.Summary = summary;

            codeFile.NamespaceList.Add(codeNamespace);

            return codeNamespace;
        }


        /// <summary>
        /// 添加一个System引用
        /// </summary>
        public static TCodeFile AddSystemUsing<TCodeFile>(this TCodeFile codeFile, string systemUsing)
            where TCodeFile : CodeFile
        {
            if (codeFile.SystemUsingList == null)
            {
                codeFile.SystemUsingList = new List<string>();
            }

            codeFile.SystemUsingList.Add(systemUsing);

            return codeFile;
        }

        /// <summary>
        /// 添加一个Nuget引用
        /// </summary>
        public static TCodeFile AddNugetUsing<TCodeFile>(this TCodeFile codeFile, string nugetUsing)
            where TCodeFile : CodeFile
        {
            if (codeFile.NugetUsingList == null)
            {
                codeFile.NugetUsingList = new List<string>();
            }

            codeFile.NugetUsingList.Add(nugetUsing);

            return codeFile;
        }

        /// <summary>
        /// 添加一个Project引用
        /// </summary>
        public static TCodeFile AddProjectUsing<TCodeFile>(this TCodeFile codeFile, string projectUsing)
            where TCodeFile : CodeFile
        {
            if (codeFile.ProjectUsingList == null)
            {
                codeFile.ProjectUsingList = new List<string>();
            }

            codeFile.ProjectUsingList.Add(projectUsing);

            return codeFile;
        }

        /// <summary>
        /// 添加一个Motto
        /// </summary>
        public static TCodeFile AddMotto<TCodeFile>(this TCodeFile codeFile, string motto)
            where TCodeFile : CodeFile
        {
            if (codeFile.MottoList == null)
            {
                codeFile.MottoList = new List<string>();
            }

            codeFile.MottoList.Add(motto);

            return codeFile;
        }
    }
}
