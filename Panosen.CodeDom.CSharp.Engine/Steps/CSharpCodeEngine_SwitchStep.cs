using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine
{
    partial class CSharpCodeEngine
    {
        private void GenerateSwitchStep(SwitchStep switchStep, CodeWriter codeWriter, GenerateOptions options)
        {
            // switch (${expression})
            codeWriter.Write(options.IndentString).Write(Keywords.SWITCH).Write(Marks.WHITESPACE)
                .Write(Marks.LEFT_BRACKET).Write(switchStep.Expression ?? string.Empty).WriteLine(Marks.RIGHT_BRACKET);

            // {
            codeWriter.Write(options.IndentString).WriteLine(Marks.LEFT_BRACE);
            options.PushIndent();

            if (switchStep.ConditionList != null && switchStep.ConditionList.Count > 0)
            {
                foreach (var item in switchStep.ConditionList)
                {
                    // case ${conditionKey}:
                    codeWriter.Write(options.IndentString).Write(Keywords.CASE).Write(Marks.WHITESPACE).Write(item.ConditionExpression.Value).WriteLine(Marks.COLON);

                    if (item.LinkToNext)
                    {
                        continue;
                    }

                    {
                        options.PushIndent();

                        // {
                        if (item.Steps != null && item.Steps.Count > 0)
                        {
                            codeWriter.Write(options.IndentString).WriteLine(Marks.LEFT_BRACE);
                        }

                        {
                            options.PushIndent();

                            GenerateStepOrCollectionList(item.Steps, codeWriter, options);

                            options.PopIndent();
                        }

                        // }
                        if (item.Steps != null && item.Steps.Count > 0)
                        {
                            codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
                        }

                        // break;
                        codeWriter.Write(options.IndentString).Write(Keywords.BREAK).WriteLine(Marks.SEMICOLON);

                        options.PopIndent();
                    }
                }
            }

            if (switchStep.DefaultSteps != null)
            {
                // case ${conditionKey}:
                codeWriter.Write(options.IndentString).Write(Keywords.DEFAULT).WriteLine(Marks.COLON);

                options.PushIndent();

                // {
                if (switchStep.DefaultSteps.Steps != null && switchStep.DefaultSteps.Steps.Count > 0)
                {
                    codeWriter.Write(options.IndentString).WriteLine(Marks.LEFT_BRACE);
                }

                {
                    options.PushIndent();

                    GenerateStepOrCollectionList(switchStep.DefaultSteps.Steps, codeWriter, options);

                    options.PopIndent();
                }

                // }
                if (switchStep.DefaultSteps.Steps != null && switchStep.DefaultSteps.Steps.Count > 0)
                {
                    codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
                }

                // break;
                codeWriter.Write(options.IndentString).Write(Keywords.BREAK).WriteLine(Marks.SEMICOLON);

                options.PopIndent();
            }

            // }
            options.PopIndent();
            codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
        }
    }
}
