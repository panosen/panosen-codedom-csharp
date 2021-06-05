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
    }
}
