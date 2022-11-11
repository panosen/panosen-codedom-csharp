using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine
{
    partial class CSharpCodeEngine
    {
        private void GenerateUsingStep(UsingStep usingStep, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.Write(options.IndentString).Write(Keywords.USING).Write(Marks.WHITESPACE).Write(Marks.LEFT_BRACKET).Write(usingStep.Content ?? string.Empty).WriteLine(Marks.RIGHT_BRACKET);

            GenerateStepOrCollectionListAsBlock(usingStep.Steps, codeWriter, options);
        }
    }
}
