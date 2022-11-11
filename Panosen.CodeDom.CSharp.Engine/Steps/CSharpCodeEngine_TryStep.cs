using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine
{
    partial class CSharpCodeEngine
    {
        private void GenerateTryStep(TryStep tryStep, CodeWriter codeWriter, GenerateOptions options)
        {
            if (tryStep == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(options.IndentString).WriteLine(Keywords.TRY);

            GenerateStepOrCollectionListAsBlock(tryStep.Steps, codeWriter, options);

            if (tryStep.CatchSteps != null && tryStep.CatchSteps.Count > 0)
            {
                foreach (var catchStep in tryStep.CatchSteps)
                {
                    GenerateCacheStep(catchStep, codeWriter, options);
                }
            }

            GenerateFinallyStep(tryStep.FinallyStep, codeWriter, options);
        }
    }
}
