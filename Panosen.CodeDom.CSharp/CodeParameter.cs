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

        /// <summary>
        /// ref
        /// </summary>
        public bool WithRef { get; set; }

        /// <summary>
        /// out
        /// </summary>
        public bool WithOut { get; set; }
    }

    /// <summary>
    /// CodeParameterExtension
    /// </summary>
    public static class CodeParameterExtension
    {
        /// <summary>
        /// AddAttribute
        /// </summary>
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

        /// <summary>
        /// WithThis
        /// </summary>
        public static TCodeParameter WithThis<TCodeParameter>(this TCodeParameter codeParameter, bool withThis)
            where TCodeParameter : CodeParameter
        {
            codeParameter.WithThis = withThis;

            return codeParameter;
        }

        /// <summary>
        /// WithOut
        /// </summary>
        public static TCodeParameter WithOut<TCodeParameter>(this TCodeParameter codeParameter, bool withOut)
            where TCodeParameter : CodeParameter
        {
            codeParameter.WithOut = withOut;

            return codeParameter;
        }

        /// <summary>
        /// WithRef
        /// </summary>
        public static TCodeParameter WithRef<TCodeParameter>(this TCodeParameter codeParameter, bool withRef)
            where TCodeParameter : CodeParameter
        {
            codeParameter.WithRef = withRef;

            return codeParameter;
        }
    }
}
