using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine
{
    partial class CSharpCodeEngine
    {
        private void GenerateElseStep(ElseStep elseStep, CodeWriter codeWriter, GenerateOptions options)
        {
            if (elseStep == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(options.IndentString).WriteLine(Keywords.ELSE);

            GenerateStepOrCollectionListAsBlock(elseStep.Steps, codeWriter, options);
        }
    }
}
