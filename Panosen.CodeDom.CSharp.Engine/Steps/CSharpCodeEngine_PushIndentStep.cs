using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine
{
    partial class CSharpCodeEngine
    {
        private void GeneratePushIndentStep(PushIndentStep pushIndentStep, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.Write(options.IndentString).WriteLine(pushIndentStep.Key ?? string.Empty);

            if (pushIndentStep.Steps == null || pushIndentStep.Steps.Count == 0)
            {
                return;
            }

            options.PushIndent();

            foreach (var item in pushIndentStep.Steps)
            {
                GenerateStepOrCollection(item, codeWriter, options);
            }

            options.PopIndent();
        }
    }
}
