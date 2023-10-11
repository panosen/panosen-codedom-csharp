using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp
{
    /// <summary>
    /// x => new Item { }
    /// </summary>
    public sealed class CodeLamdaNewInstance : DataItem
    {
        /// <summary>
        /// 参数
        /// </summary>
        public string Parameter { get; set; }

        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 步骤集合
        /// </summary>
        public StepCollection StepCollection { get; set; }

        /// <summary>
        /// Statements
        /// </summary>
        public List<string> Statements { get; set; }
    }

    /// <summary>
    /// CodeLamdaNewInstanceExpressionExtension
    /// </summary>
    public static class CodeLamdaNewInstanceExpressionExtension
    {
        /// <summary>
        /// SetParameter
        /// </summary>
        public static CodeLamdaNewInstance SetParameter(this CodeLamdaNewInstance codeLamdaNewInstance, string parameter)
        {
            codeLamdaNewInstance.Parameter = parameter;

            return codeLamdaNewInstance;
        }

        /// <summary>
        /// SetBooleanExpression
        /// </summary>
        public static CodeLamdaNewInstance SetClassName(this CodeLamdaNewInstance codeLamdaNewInstance, string className)
        {
            codeLamdaNewInstance.ClassName = className;

            return codeLamdaNewInstance;
        }

        /// <summary>
        /// SetBooleanExpression
        /// </summary>
        public static CodeLamdaNewInstance StepStatement(this CodeLamdaNewInstance codeLamdaNewInstance, string statement)
        {
            if (codeLamdaNewInstance.Statements == null)
            {
                codeLamdaNewInstance.Statements = new List<string>();
            }

            codeLamdaNewInstance.Statements.Add(statement);

            return codeLamdaNewInstance;
        }
    }
}
