using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine
{
    partial class CSharpCodeEngine
    {
        private static void GenerateStatementStep(StatementStep statementStep, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.Write(options.IndentString).WriteLine(statementStep.Statement);
        }
    }
}
