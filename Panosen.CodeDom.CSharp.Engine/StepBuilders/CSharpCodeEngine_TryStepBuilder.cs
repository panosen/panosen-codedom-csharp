using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine
{
    partial class CSharpCodeEngine
    {
        private void GenerateTryStepBuilder(TryStepBuilder tryStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            if (tryStepBuilder == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(options.IndentString).WriteLine(Keywords.TRY);

            GenerateStepBuilderOrCollectionListAsBlock(tryStepBuilder.StepBuilders, codeWriter, options);

            if (tryStepBuilder.CatchStepBuilders != null && tryStepBuilder.CatchStepBuilders.Count > 0)
            {
                foreach (var catchStepBuilder in tryStepBuilder.CatchStepBuilders)
                {
                    GenerateCacheStepBuilder(catchStepBuilder, codeWriter, options);
                }
            }

            GenerateFinallyStepBuilder(tryStepBuilder.FinallyStepBuilder, codeWriter, options);
        }
    }
}
