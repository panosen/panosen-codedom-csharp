using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp
{
    /// <summary>
    /// 方法参数
    /// </summary>
    public class CodeParameter : CodeObject
    {
        /// <summary>
        /// 参数类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 特性
        /// </summary>
        public List<CodeAttribute> AttributeList { get; set; }

        /// <summary>
        /// 用于扩展方法
        /// </summary>
        public bool WithThis { get; set; }
    }

    /// <summary>
    /// CodeParameterExtension
    /// </summary>
    public static class CodeParameterExtension
    {
        /// <summary>
        /// AddAttribute
        /// </summary>
        /// <typeparam name="TCodeParameter"></typeparam>
        /// <param name="codeParameter"></param>
        /// <param name="codeAttribute"></param>
        /// <returns></returns>
        public static TCodeParameter AddAttribute<TCodeParameter>(this TCodeParameter codeParameter, CodeAttribute codeAttribute)
            where TCodeParameter : CodeParameter
        {
            if (codeParameter.AttributeList == null)
            {
                codeParameter.AttributeList = new List<CodeAttribute>();
            }

            codeParameter.AttributeList.Add(codeAttribute);

            return codeParameter;
        }

        /// <summary>
        /// AddAttribute
        /// </summary>
        /// <typeparam name="TCodeParameter"></typeparam>
        /// <param name="codeParameter"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static TCodeParameter AddAttribute<TCodeParameter>(this TCodeParameter codeParameter, string name)
            where TCodeParameter : CodeParameter
        {
            if (codeParameter.AttributeList == null)
            {
                codeParameter.AttributeList = new List<CodeAttribute>();
            }

            CodeAttribute codeAttribute = new CodeAttribute();
            codeAttribute.Name = name;

            codeParameter.AttributeList.Add(codeAttribute);

            return codeParameter;
        }
    }
}
