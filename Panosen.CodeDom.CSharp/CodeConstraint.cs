using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp
{
    /// <summary>
    /// 约束
    /// </summary>
    public class CodeConstraint
    {
        /// <summary>
        /// 被约束的类型
        /// </summary>
        public string GenericArgs { get; set; }

        /// <summary>
        /// 约束为该类型
        /// </summary>
        public string InheritFrom { get; set; }
    }
}
