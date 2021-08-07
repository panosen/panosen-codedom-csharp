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
        /// 访问修饰符
        /// </summary>
        public AccessModifiers AccessModifiers { get; set; }

        /// <summary>
        /// 方法
        /// </summary>
        public List<CodeMethod> MethodList { get; set; }
    }

    /// <summary>
    /// CodeInterface 扩展方法
    /// </summary>
    public static class CodeInterfaceExtension
    {
        /// <summary>
        /// 添加一个方法
        /// </summary>
        /// <param name="codeInterface"></param>
        /// <param name="codeMethod"></param>
        /// <returns></returns>
        public static CodeInterface AddMethod(this CodeInterface codeInterface, CodeMethod codeMethod)
        {
            if (codeInterface.MethodList == null)
            {
                codeInterface.MethodList = new List<CodeMethod>();
            }

            codeInterface.MethodList.Add(codeMethod);

            return codeInterface;
        }

        /// <summary>
        /// 添加一批方法
        /// </summary>
        /// <param name="codeInterface"></param>
        /// <param name="codeMethods"></param>
        /// <returns></returns>
        public static CodeInterface AddMethods(this CodeInterface codeInterface, List<CodeMethod> codeMethods)
        {
            if (codeMethods == null || codeMethods.Count == 0)
            {
                return codeInterface;
            }

            if (codeInterface.MethodList == null)
            {
                codeInterface.MethodList = new List<CodeMethod>();
            }

            codeInterface.MethodList.AddRange(codeMethods);

            return codeInterface;
        }
    }
}
