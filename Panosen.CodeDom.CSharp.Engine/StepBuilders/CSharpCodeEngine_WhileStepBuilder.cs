using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine
{
    partial class CSharpCodeEngine
    {
        private void GenerateWhileStepBuilder(WhileStepBuilder whileStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            if (whileStepBuilder == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(options.IndentString).Write(Keywords.WHILE).Write(Marks.WHITESPACE).Write(Marks.LEFT_BRACKET).Write(whileStepBuilder.Condition ?? string.Empty).WriteLine(Marks.RIGHT_BRACKET);

            GenerateStepBuilderOrCollectionListAsBlock(whileStepBuilder.StepBuilders, codeWriter, options);
        }
    }
}
