using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine
{
    partial class CSharpCodeEngine
    {
        private void GenerateForeachStepBuilder(ForeachStepBuilder foreachStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.Write(options.IndentString).Write(Keywords.FOREACH).Write(Marks.WHITESPACE).Write(Marks.LEFT_BRACKET)
                .Write(foreachStepBuilder.Type ?? Keywords.VAR).Write(Marks.WHITESPACE)
                .Write(foreachStepBuilder.Item ?? string.Empty).Write(Marks.WHITESPACE)
                .Write(Keywords.IN).Write(Marks.WHITESPACE)
                .Write(foreachStepBuilder.Items ?? string.Empty)
                .WriteLine(Marks.RIGHT_BRACKET);

            GenerateStepBuilderOrCollectionListAsBlock(foreachStepBuilder.StepBuilders, codeWriter, options);
        }
    }
}
