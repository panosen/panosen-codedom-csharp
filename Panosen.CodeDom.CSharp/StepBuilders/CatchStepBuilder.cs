using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp
{
    /// <summary>
    /// catch
    /// </summary>
    public class CatchStepBuilder : StepBuilderCollection
    {
        /// <summary>
        /// `Excepton e` 或 `Exception`
        /// </summary>
        public string Content { get; set; }
    }
}
