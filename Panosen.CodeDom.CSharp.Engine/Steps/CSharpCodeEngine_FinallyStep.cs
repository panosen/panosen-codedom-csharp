using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine
{
    partial class CSharpCodeEngine
    {
        private void GenerateFinallyStep(FinallyStep finallyStep, CodeWriter codeWriter, GenerateOptions options)
        {
            if (finallyStep == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(options.IndentString).WriteLine(Keywords.FINALLY);

            GenerateStepOrCollectionListAsBlock(finallyStep.Steps, codeWriter, options);
        }
    }
}
