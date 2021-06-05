using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine
{
    partial class CSharpCodeEngine
    {
        private void GenerateCacheStepBuilder(CatchStepBuilder catchStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            if (catchStepBuilder == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(options.IndentString).Write(Keywords.CATCH);
            if (!string.IsNullOrEmpty(catchStepBuilder.Content))
            {
                codeWriter.Write(Marks.WHITESPACE).Write(Marks.LEFT_BRACKET).Write(catchStepBuilder.Content).Write(Marks.RIGHT_BRACKET);
            }
            codeWriter.WriteLine();

            GenerateStepBuilderOrCollectionListAsBlock(catchStepBuilder.StepBuilders, codeWriter, options);
        }
    }
}
