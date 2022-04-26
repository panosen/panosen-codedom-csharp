using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp
{
    /// <summary>
    /// 字段
    /// </summary>
    public class CodeEnumValue : CodeObject
    {
        /// <summary>
        /// 值
        /// </summary>
        public DataItem Value { get; set; }
    }
}
