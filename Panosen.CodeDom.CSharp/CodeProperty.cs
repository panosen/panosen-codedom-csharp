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
    public class CodeProperty : CodeObject
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
        public DataItem Value { get; set; }

        /// <summary>
        /// 是否是virtual
        /// </summary>
        public bool IsVirtual { get; set; }

        /// <summary>
        /// 是否是override
        /// </summary>
        public bool IsOverride { get; set; }

        /// <summary>
        /// get 访问器
        /// </summary>
        public StepBuilderCollection GetStepBuilderCollection { get; set; }

        /// <summary>
        /// set 访问器包含的步骤
        /// </summary>
        public StepBuilderCollection SetStepBuilderCollection { get; set; }
    }

    /// <summary>
    /// CodePropertyExtension
    /// </summary>
    public static class CodePropertyExtension
    {
        /// <summary>
        /// AddAttribute
        /// </summary>
        /// <typeparam name="TCodeProperty"></typeparam>
        /// <param name="codeProperty"></param>
        /// <param name="codeAttribute"></param>
        /// <returns></returns>
        public static TCodeProperty AddAttribute<TCodeProperty>(this TCodeProperty codeProperty, CodeAttribute codeAttribute) where TCodeProperty : CodeProperty
        {
            if (codeProperty.AttributeList == null)
            {
                codeProperty.AttributeList = new List<CodeAttribute>();
            }

            codeProperty.AttributeList.Add(codeAttribute);

            return codeProperty;
        }

        /// <summary>
        /// AddAttribute
        /// </summary>
        /// <param name="codeProperty"></param>
        /// <param name="name"></param>
        /// <returns></returns>
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

        /// <summary>
        /// AddValue
        /// </summary>
        public static TCodeProperty AddValue<TCodeProperty>(this TCodeProperty codeProperty, DataItem dataItem) where TCodeProperty : CodeProperty
        {
            codeProperty.Value = dataItem;

            return codeProperty;
        }

        /// <summary>
        /// AddStringValue
        /// </summary>
        public static TCodeProperty AddStringValue<TCodeProperty>(this TCodeProperty codeProperty, string value) where TCodeProperty : CodeProperty
        {
            codeProperty.Value = DataValue.DoubleQuotationString(value);

            return codeProperty;
        }

        /// <summary>
        /// AddPlainValue
        /// </summary>
        public static CodeProperty AddPlainValue<TCodeProperty>(this TCodeProperty codeProperty, string value) where TCodeProperty : CodeProperty
        {
            codeProperty.Value = (DataValue)value;

            return codeProperty;
        }

        /// <summary>
        /// AddGetStepBuilderCollection
        /// </summary>
        /// <typeparam name="TCodeProperty"></typeparam>
        /// <param name="codeProperty"></param>
        /// <param name="stepBuilderCollection"></param>
        /// <returns></returns>
        public static TCodeProperty AddGetStepBuilderCollection<TCodeProperty>(this TCodeProperty codeProperty, StepBuilderCollection stepBuilderCollection) where TCodeProperty : CodeProperty
        {
            codeProperty.GetStepBuilderCollection = stepBuilderCollection;

            return codeProperty;
        }

        /// <summary>
        /// AddGetStepBuilderCollection
        /// </summary>
        /// <param name="codeProperty"></param>
        /// <returns></returns>
        public static StepBuilderCollection AddGetStepBuilderCollection(this CodeProperty codeProperty)
        {
            StepBuilderCollection stepBuilderCollection = new StepBuilderCollection();

            codeProperty.GetStepBuilderCollection = stepBuilderCollection;

            return stepBuilderCollection;
        }

        /// <summary>
        /// AddSetStepBuilderCollection
        /// </summary>
        /// <typeparam name="TCodeProperty"></typeparam>
        /// <param name="codeProperty"></param>
        /// <param name="stepBuilderCollection"></param>
        /// <returns></returns>
        public static TCodeProperty AddSetStepBuilderCollection<TCodeProperty>(this TCodeProperty codeProperty, StepBuilderCollection stepBuilderCollection) where TCodeProperty : CodeProperty
        {
            codeProperty.SetStepBuilderCollection = stepBuilderCollection;

            return codeProperty;
        }

        /// <summary>
        /// AddSetStepBuilderCollection
        /// </summary>
        /// <param name="codeProperty"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 设置IsOverride
        /// </summary>
        public static TCodeProperty SetIsOverride<TCodeProperty>(this TCodeProperty codeProperty, bool isOverride) where TCodeProperty : CodeProperty
        {
            codeProperty.IsOverride = isOverride;

            return codeProperty;
        }
    }
}
