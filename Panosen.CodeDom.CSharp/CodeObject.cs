using System;
using System.Collections.Generic;
using System.Reflection;

namespace Panosen.CodeDom.CSharp
{
    /// <summary>
    /// 有名称的编程对象
    /// </summary>
    public abstract class CodeObject : Code
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 注释
        /// </summary>
        public string Summary { get; set; }

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
    }

    /// <summary>
    /// CodeObject Extension
    /// </summary>
    public static class CodeObjectExtension
    {
        /// <summary>
        /// Set Name
        /// </summary>
        public static TCodeObject SetName<TCodeObject>(this TCodeObject codeObject, string name) where TCodeObject : CodeObject
        {
            codeObject.Name = name;

            return codeObject;
        }

        /// <summary>
        /// Set Name
        /// </summary>
        public static TCodeObject SetSummary<TCodeObject>(this TCodeObject codeObject, string summary) where TCodeObject : CodeObject
        {
            codeObject.Summary = summary;

            return codeObject;
        }


        /// <summary>
        /// 添加一个System引用
        /// </summary>
        public static TCodeObject AddSystemUsing<TCodeObject>(this TCodeObject codeObject, string systemUsing)
            where TCodeObject : CodeObject, INamespace
        {
            if (codeObject.SystemUsingList == null)
            {
                codeObject.SystemUsingList = new List<string>();
            }

            codeObject.SystemUsingList.Add(systemUsing);

            return codeObject;
        }

        /// <summary>
        /// 添加一个Nuget引用
        /// </summary>
        public static TCodeObject AddNugetUsing<TCodeObject>(this TCodeObject codeObject, string nugetUsing)
            where TCodeObject : CodeObject, INamespace
        {
            if (codeObject.NugetUsingList == null)
            {
                codeObject.NugetUsingList = new List<string>();
            }

            codeObject.NugetUsingList.Add(nugetUsing);

            return codeObject;
        }

        /// <summary>
        /// 添加一个Project引用
        /// </summary>
        public static TCodeObject AddProjectUsing<TCodeObject>(this TCodeObject codeObject, string projectUsing)
            where TCodeObject : CodeObject, INamespace
        {
            if (codeObject.ProjectUsingList == null)
            {
                codeObject.ProjectUsingList = new List<string>();
            }

            codeObject.ProjectUsingList.Add(projectUsing);

            return codeObject;
        }
    }
}
