using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp
{
    /// <summary>
    /// 属性
    /// </summary>
    public class CodeProperty : CodeMember
    {
        /// <summary>
        /// 访问修饰符
        /// </summary>
        public AccessModifiers AccessModifiers { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 特性
        /// </summary>
        public List<CodeAttribute> AttributeList { get; set; }

        /// <summary>
        /// 只带get不带set
        /// </summary>
        public CodePropertyAccess CodePropertyAccess { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 是否是分布类
        /// </summary>
        public bool IsVirtual { get; set; }

        /// <summary>
        /// get 访问器
        /// </summary>
        public StepBuilderCollection GetStepBuilderCollection { get; set; }

        /// <summary>
        /// set 访问器包含的步骤
        /// </summary>
        public StepBuilderCollection SetStepBuilderCollection { get; set; }
    }

    public static class CodePropertyExtension
    {
        public static TCodeProperty AddAttribute<TCodeProperty>(this TCodeProperty codeProperty, CodeAttribute codeAttribute) where TCodeProperty : CodeProperty
        {
            if (codeProperty.AttributeList == null)
            {
                codeProperty.AttributeList = new List<CodeAttribute>();
            }

            codeProperty.AttributeList.Add(codeAttribute);

            return codeProperty;
        }

        public static CodeAttribute AddAttribute(this CodeProperty codeProperty, string name)
        {
            if (codeProperty.AttributeList == null)
            {
                codeProperty.AttributeList = new List<CodeAttribute>();
            }

            CodeAttribute codeAttribute = new CodeAttribute();
            codeAttribute.Name = name;

            codeProperty.AttributeList.Add(codeAttribute);

            return codeAttribute;
        }

        public static TCodeProperty AddGetStepBuilderCollection<TCodeProperty>(this TCodeProperty codeProperty, StepBuilderCollection stepBuilderCollection) where TCodeProperty : CodeProperty
        {
            codeProperty.GetStepBuilderCollection = stepBuilderCollection;

            return codeProperty;
        }

        public static StepBuilderCollection AddGetStepBuilderCollection(this CodeProperty codeProperty)
        {
            StepBuilderCollection stepBuilderCollection = new StepBuilderCollection();

            codeProperty.GetStepBuilderCollection = stepBuilderCollection;

            return stepBuilderCollection;
        }

        public static TCodeProperty AddSetStepBuilderCollection<TCodeProperty>(this TCodeProperty codeProperty, StepBuilderCollection stepBuilderCollection) where TCodeProperty : CodeProperty
        {
            codeProperty.SetStepBuilderCollection = stepBuilderCollection;

            return codeProperty;
        }

        public static StepBuilderCollection AddSetStepBuilderCollection(this CodeProperty codeProperty)
        {
            StepBuilderCollection stepBuilderCollection = new StepBuilderCollection();

            codeProperty.SetStepBuilderCollection = stepBuilderCollection;

            return stepBuilderCollection;
        }

        /// <summary>
        /// 设置IsVirtual
        /// </summary>
        public static TCodeProperty SetIsVirtual<TCodeProperty>(this TCodeProperty codeProperty, bool isVirtual) where TCodeProperty : CodeProperty
        {
            codeProperty.IsVirtual = isVirtual;

            return codeProperty;
        }
    }
}
