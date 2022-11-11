using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine
{
    partial class CSharpCodeEngine
    {
        private void GenerateForStep(ForStep forStep, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.Write(options.IndentString).Write(Keywords.FOR).Write(Marks.WHITESPACE).Write(Marks.LEFT_BRACKET)
                .Write(forStep.Start ?? string.Empty).Write(Marks.SEMICOLON).Write(Marks.WHITESPACE)
                .Write(forStep.Middle ?? string.Empty).Write(Marks.SEMICOLON).Write(Marks.WHITESPACE)
                .Write(forStep.End ?? string.Empty)
                .WriteLine(Marks.RIGHT_BRACKET);

            GenerateStepOrCollectionListAsBlock(forStep.Steps, codeWriter, options);
        }
    }
}
