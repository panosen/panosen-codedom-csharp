using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine
{
    partial class CSharpCodeEngine
    {
        private void GenerateElseIfStep(ElseIfStep elseIfStep, CodeWriter codeWriter, GenerateOptions options)
        {
            if (elseIfStep == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(options.IndentString).Write(Keywords.ELSE).Write(Marks.WHITESPACE)
                .Write(Keywords.IF).Write(Marks.WHITESPACE)
                .Write(Marks.LEFT_BRACKET).Write(elseIfStep.Condition ?? string.Empty)
                .WriteLine(Marks.RIGHT_BRACKET);

            GenerateStepOrCollectionListAsBlock(elseIfStep.Steps, codeWriter, options);
        }
    }
}
