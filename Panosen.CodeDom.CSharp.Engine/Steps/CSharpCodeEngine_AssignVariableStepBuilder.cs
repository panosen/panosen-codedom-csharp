using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine
{
    partial class CSharpCodeEngine
    {
        private void GenerateAssignmentStep(AssignmentStep assignmentStep, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.Write(options.IndentString).Write(assignmentStep.Left)
                .Write(Marks.WHITESPACE).Write(Marks.EQUAL).Write(Marks.WHITESPACE);

            GenerateExpresion(codeWriter, assignmentStep.Right,options);

            codeWriter.WriteLine(Marks.SEMICOLON);
        }
    }
}
