using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp
{
    /// <summary>
    /// 接口
    /// </summary>
    public class CodeInterface : CodeObject
    {

        /// <summary>
        /// IsPartial
        /// </summary>
        public bool IsPartial { get; set; }

        /// <summary>
        /// 访问修饰符
        /// </summary>
        public AccessModifiers AccessModifiers { get; set; }

        /// <summary>
        /// 方法
        /// </summary>
        public List<CodeMethod> MethodList { get; set; }

        /// <summary>
        /// 该接口继承的接口
        /// </summary>
        public List<CodeInterface> ParentInterfaceList { get; set; }
    }

    /// <summary>
    /// CodeInterface 扩展方法
    /// </summary>
    public static class CodeInterfaceExtension
    {

        /// <summary>
        /// 设置访问修饰符
        /// </summary>
        public static TCodeInterface SetAccessModifiers<TCodeInterface>(this TCodeInterface codeClass, AccessModifiers accessModifiers)
            where TCodeInterface : CodeInterface
        {
            codeClass.AccessModifiers = accessModifiers;

            return codeClass;
        }

        /// <summary>
        /// 设置IsPartial
        /// </summary>
        public static TCodeInterface SetIsPartial<TCodeInterface>(this TCodeInterface codeInterface, bool isPartial)
            where TCodeInterface : CodeInterface
        {
            codeInterface.IsPartial = isPartial;

            return codeInterface;
        }

        /// <summary>
        /// 添加一个方法
        /// </summary>
        public static TCodeInterface AddMethod<TCodeInterface>(this TCodeInterface codeClass, CodeMethod codeMethod)
            where TCodeInterface : CodeInterface
        {
            if (codeClass.MethodList == null)
            {
                codeClass.MethodList = new List<CodeMethod>();
            }

            codeClass.MethodList.Add(codeMethod);

            return codeClass;
        }

        /// <summary>
        /// 添加一个方法
        /// </summary>
        public static CodeMethod AddMethod(this CodeInterface codeClass, string name, string summary = null)
        {
            if (codeClass.MethodList == null)
            {
                codeClass.MethodList = new List<CodeMethod>();
            }

            CodeMethod codeMethod = new CodeMethod();
            codeMethod.Name = name;
            codeMethod.Summary = summary;

            codeClass.MethodList.Add(codeMethod);

            return codeMethod;
        }

        /// <summary>
        /// 添加一批方法
        /// </summary>
        public static TCodeInterface AddMethods<TCodeInterface>(this TCodeInterface codeClass, List<CodeMethod> codeMethods)
            where TCodeInterface : CodeInterface
        {
            if (codeMethods == null || codeMethods.Count == 0)
            {
                return codeClass;
            }
            if (codeClass.MethodList == null)
            {
                codeClass.MethodList = new List<CodeMethod>();
            }

            codeClass.MethodList.AddRange(codeMethods);

            return codeClass;
        }

        /// <summary>
        /// 添加接口
        /// </summary>
        public static CodeInterface AddParent<TCodeInterface>(this TCodeInterface codeInterface, string name, string summary = null)
            where TCodeInterface : CodeInterface
        {
            if (codeInterface.ParentInterfaceList == null)
            {
                codeInterface.ParentInterfaceList = new List<CodeInterface>();
            }

            CodeInterface parentInterface = new CodeInterface();
            parentInterface.Name = name;
            parentInterface.Summary = summary;

            codeInterface.ParentInterfaceList.Add(parentInterface);

            return parentInterface;
        }

        /// <summary>
        /// 添加接口
        /// </summary>
        public static TCodeInterface AddInterface<TCodeInterface>(this TCodeInterface codeInterface, CodeInterface parentInterface)
            where TCodeInterface : CodeInterface
        {
            if (codeInterface.ParentInterfaceList == null)
            {
                codeInterface.ParentInterfaceList = new List<CodeInterface>();
            }

            codeInterface.ParentInterfaceList.Add(parentInterface);

            return codeInterface;
        }
    }
}
