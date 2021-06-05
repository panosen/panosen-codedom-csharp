using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.CSharp
{
    /// <summary>
    /// 命名空间
    /// </summary>
    public class CodeNamespace : CodeObject
    {
        /// <summary>
        /// 类
        /// </summary>
        public List<CodeClass> ClassList { get; set; }

        /// <summary>
        /// 接口
        /// </summary>
        public List<CodeInterface> InterfaceList { get; set; }
    }
    /// <summary>
    /// CodeNamespace 扩展
    /// </summary>
    public static class CodeNamespaceExtension
    {
        /// <summary>
        /// 添加一个类
        /// </summary>
        /// <param name="codeNamespace"></param>
        /// <param name="codeClass"></param>
        /// <returns></returns>
        public static CodeNamespace AddClass(this CodeNamespace codeNamespace, CodeClass codeClass)
        {
            if (codeNamespace.ClassList == null)
            {
                codeNamespace.ClassList = new List<CodeClass>();
            }

            codeNamespace.ClassList.Add(codeClass);
            return codeNamespace;
        }

        /// <summary>
        /// 添加一个类
        /// </summary>
        public static CodeClass AddClass(this CodeNamespace codeNamespace, string name, string summary = null, AccessModifiers accessModifiers = AccessModifiers.None)
        {
            if (codeNamespace.ClassList == null)
            {
                codeNamespace.ClassList = new List<CodeClass>();
            }

            CodeClass codeClass = new CodeClass();
            codeClass.Name = name;
            codeClass.Summary = summary;
            codeClass.AccessModifiers = accessModifiers;

            codeNamespace.ClassList.Add(codeClass);

            return codeClass;
        }

        /// <summary>
        /// 添加一个接口
        /// </summary>
        public static CodeNamespace AddInterface(this CodeNamespace codeNamespace, CodeInterface codeInterface)
        {
            if (codeNamespace.InterfaceList == null)
            {
                codeNamespace.InterfaceList = new List<CodeInterface>();
            }

            codeNamespace.InterfaceList.Add(codeInterface);
            return codeNamespace;
        }

        /// <summary>
        /// 添加一个接口
        /// </summary>
        public static CodeInterface AddInterface(this CodeNamespace codeNamespace, string name, string summary = null, AccessModifiers accessModifiers = AccessModifiers.None)
        {
            if (codeNamespace.InterfaceList == null)
            {
                codeNamespace.InterfaceList = new List<CodeInterface>();
            }

            CodeInterface codeInterface = new CodeInterface();
            codeInterface.Name = name;
            codeInterface.Summary = summary;
            codeInterface.AccessModifiers = accessModifiers;

            codeNamespace.InterfaceList.Add(codeInterface);

            return codeInterface;
        }
    }
}
