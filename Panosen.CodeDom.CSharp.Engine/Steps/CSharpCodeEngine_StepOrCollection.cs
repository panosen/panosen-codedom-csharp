using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine
{
    partial class CSharpCodeEngine
    {
        /// <summary>
        /// 生成方法步骤
        /// </summary>
        public void GenerateStepOrCollection(StepOrCollection stepBuilder, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (stepBuilder == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            if (stepBuilder is EmptyStep)
            {
                codeWriter.WriteLine();
            }

            if (stepBuilder is StatementStep)
            {
                GenerateStatementStep(stepBuilder as StatementStep, codeWriter, options);
                return;
            }

            if (stepBuilder is UsingStep)
            {
                GenerateUsingStep(stepBuilder as UsingStep, codeWriter, options);
                return;
            }

            if (stepBuilder is IfStep)
            {
                GenerateIfStep(stepBuilder as IfStep, codeWriter, options);
                return;
            }

            if (stepBuilder is WhileStep)
            {
                GenerateWhileStep(stepBuilder as WhileStep, codeWriter, options);
                return;
            }

            if (stepBuilder is TryStep)
            {
                GenerateTryStep(stepBuilder as TryStep, codeWriter, options);
                return;
            }

            if (stepBuilder is SwitchStep)
            {
                GenerateSwitchStep(stepBuilder as SwitchStep, codeWriter, options);
                return;
            }

            if (stepBuilder is ForeachStep)
            {
                GenerateForeachStep(stepBuilder as ForeachStep, codeWriter, options);
                return;
            }

            if (stepBuilder is ForStep)
            {
                GenerateForStep(stepBuilder as ForStep, codeWriter, options);
                return;
            }

            if (stepBuilder is BlockStep)
            {
                GenerateBlockStep(stepBuilder as BlockStep, codeWriter, options);
                return;
            }

            if (stepBuilder is PushIndentStep)
            {
                GeneratePushIndentStep(stepBuilder as PushIndentStep, codeWriter, options);
                return;
            }

            if (stepBuilder is StatementChainStep)
            {
                GenerateStatementChainStep(stepBuilder as StatementChainStep, codeWriter, options);
                return;
            }

            if (stepBuilder is AssignmentStep)
            {
                GenerateAssignmentStep(stepBuilder as AssignmentStep, codeWriter, options);
                return;
            }

            if (stepBuilder is StepCollection)
            {
                var stepBuilderCollection = stepBuilder as StepCollection;
                foreach (var item in stepBuilderCollection.Steps)
                {
                    GenerateStepOrCollection(item, codeWriter, options);
                }
                return;
            }
        }
    }
}
