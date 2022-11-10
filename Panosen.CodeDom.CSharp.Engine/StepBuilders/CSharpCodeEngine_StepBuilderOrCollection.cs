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
        public void GenerateStepBuilderOrCollection(StepBuilderOrCollection stepBuilder, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (stepBuilder == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            if (stepBuilder is EmptyStepBuilder)
            {
                codeWriter.WriteLine();
            }

            if (stepBuilder is StatementStepBuilder)
            {
                GenerateStatementStepBuilder(stepBuilder as StatementStepBuilder, codeWriter, options);
                return;
            }

            if (stepBuilder is UsingStepBuilder)
            {
                GenerateUsingStepBuilder(stepBuilder as UsingStepBuilder, codeWriter, options);
                return;
            }

            if (stepBuilder is IfStepBuilder)
            {
                GenerateIfStepBuilder(stepBuilder as IfStepBuilder, codeWriter, options);
                return;
            }

            if (stepBuilder is WhileStepBuilder)
            {
                GenerateWhileStepBuilder(stepBuilder as WhileStepBuilder, codeWriter, options);
                return;
            }

            if (stepBuilder is TryStepBuilder)
            {
                GenerateTryStepBuilder(stepBuilder as TryStepBuilder, codeWriter, options);
                return;
            }

            if (stepBuilder is SwitchStepBuilder)
            {
                GenerateSwitchStepBuilder(stepBuilder as SwitchStepBuilder, codeWriter, options);
                return;
            }

            if (stepBuilder is ForeachStepBuilder)
            {
                GenerateForeachStepBuilder(stepBuilder as ForeachStepBuilder, codeWriter, options);
                return;
            }

            if (stepBuilder is ForStepBuilder)
            {
                GenerateForStepBuilder(stepBuilder as ForStepBuilder, codeWriter, options);
                return;
            }

            if (stepBuilder is BlockStepBuilder)
            {
                GenerateBlockStepBuilder(stepBuilder as BlockStepBuilder, codeWriter, options);
                return;
            }

            if (stepBuilder is PushIndentStepBuilder)
            {
                GeneratePushIndentStepBuilder(stepBuilder as PushIndentStepBuilder, codeWriter, options);
                return;
            }

            if (stepBuilder is StatementChainStepBuilder)
            {
                GenerateStatementChainStepBuilder(stepBuilder as StatementChainStepBuilder, codeWriter, options);
                return;
            }

            if (stepBuilder is AssignmentStepBuilder)
            {
                GenerateAssignmentStepBuilder(stepBuilder as AssignmentStepBuilder, codeWriter, options);
                return;
            }

            if (stepBuilder is StepBuilderCollection)
            {
                var stepBuilderCollection = stepBuilder as StepBuilderCollection;
                foreach (var item in stepBuilderCollection.StepBuilders)
                {
                    GenerateStepBuilderOrCollection(item, codeWriter, options);
                }
                return;
            }
        }
    }
}
