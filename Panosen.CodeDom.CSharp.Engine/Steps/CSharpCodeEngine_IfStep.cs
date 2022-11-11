using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine
{
    partial class CSharpCodeEngine
    {
        private void GenerateIfStep(IfStep ifStep, CodeWriter codeWriter, GenerateOptions options)
        {
            if (ifStep == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(options.IndentString).Write(Keywords.IF).Write(Marks.WHITESPACE).Write(Marks.LEFT_BRACKET).Write(ifStep.Condition ?? string.Empty).WriteLine(Marks.RIGHT_BRACKET);

            GenerateStepOrCollectionListAsBlock(ifStep.Steps, codeWriter, options);

            if (ifStep.ElseIfSteps != null && ifStep.ElseIfSteps.Count > 0)
            {
                foreach (var elseIfStep in ifStep.ElseIfSteps)
                {
                    GenerateElseIfStep(elseIfStep, codeWriter, options);
                }
            }

            GenerateElseStep(ifStep.ElseStep, codeWriter, options);
        }
    }
}
