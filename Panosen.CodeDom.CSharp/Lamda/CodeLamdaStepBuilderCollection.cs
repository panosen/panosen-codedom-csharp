using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp
{
    /// <summary>
    /// ${Parameter} => ${Expression}
    /// </summary>
    public class CodeLamdaStepCollection : DataItem, IStepCollectionHost
    {
        /// <summary>
        /// 参数
        /// </summary>
        public string Parameter { get; set; }

        #region IStepCollectionHost Members

        /// <summary>
        /// 步骤
        /// </summary>
        public StepCollection StepCollection { get; set; }

        #endregion
    }

    /// <summary>
    /// CodeLamdaStepCollectionExtension
    /// </summary>
    public static class CodeLamdaStepCollectionExtension
    {
        /// <summary>
        /// SetParameter
        /// </summary>
        public static TCodeLamdaStepCollection SetParameter<TCodeLamdaStepCollection>(this TCodeLamdaStepCollection lamda, string parameter)
            where TCodeLamdaStepCollection : CodeLamdaStepCollection
        {
            lamda.Parameter = parameter;

            return lamda;
        }
    }
}
