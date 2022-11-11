using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp
{
    /// <summary>
    /// IfStep
    /// </summary>
    public class IfStep : StepCollection
    {
        /// <summary>
        /// Condition
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// ElseIfSteps
        /// </summary>
        public List<ElseIfStep> ElseIfSteps { get; set; }

        /// <summary>
        /// ElseStep
        /// </summary>
        public ElseStep ElseStep { get; set; }
    }

    /// <summary>
    /// IfStepExtension
    /// </summary>
    public static class IfStepExtension
    {
        /// <summary>
        /// WithElseIf
        /// </summary>
        /// <param name="ifStep"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static ElseIfStep WithElseIf(this IfStep ifStep, string condition)
        {
            if (ifStep.ElseIfSteps == null)
            {
                ifStep.ElseIfSteps = new List<ElseIfStep>();
            }

            ElseIfStep elseIfStep = new ElseIfStep();
            elseIfStep.Condition = condition;
            ifStep.ElseIfSteps.Add(elseIfStep);

            return elseIfStep;
        }

        /// <summary>
        /// WithElse
        /// </summary>
        /// <param name="ifStep"></param>
        /// <returns></returns>
        public static ElseStep WithElse(this IfStep ifStep)
        {
            ElseStep elseStep = new ElseStep();

            ifStep.ElseStep = elseStep;

            return elseStep;
        }
    }
}
