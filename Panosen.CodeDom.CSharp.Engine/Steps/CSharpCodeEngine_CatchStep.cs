using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine
{
    partial class CSharpCodeEngine
    {
        private void GenerateCacheStep(CatchStep catchStep, CodeWriter codeWriter, GenerateOptions options)
        {
            if (catchStep == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(options.IndentString).Write(Keywords.CATCH);
            if (!string.IsNullOrEmpty(catchStep.ExceptionType))
            {
                codeWriter.Write(Marks.WHITESPACE).Write(Marks.LEFT_BRACKET).Write(catchStep.ExceptionType);

                if (!string.IsNullOrEmpty(catchStep.ExceptionName))
                {
                    codeWriter.Write(Marks.WHITESPACE).Write(catchStep.ExceptionName);
                }

                codeWriter.Write(Marks.RIGHT_BRACKET);
            }
            codeWriter.WriteLine();

            GenerateStepOrCollectionListAsBlock(catchStep.Steps, codeWriter, options);
        }
    }
}
