using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp
{
    /// <summary>
    /// StatementStepBuilder
    /// </summary>
    public class StatementStepBuilder : StepBuilder
    {
        /// <summary>
        /// Statement
        /// </summary>
        public string Statement { get; private set; }

        /// <summary>
        /// StatementStepBuilder
        /// </summary>
        /// <param name="statement"></param>
        public StatementStepBuilder(string statement)
        {
            this.Statement = statement;
        }
    }
}
