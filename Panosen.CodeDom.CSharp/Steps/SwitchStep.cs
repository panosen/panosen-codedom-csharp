using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp
{
    /// <summary>
    /// switch
    /// </summary>
    public class SwitchStep : Step
    {
        /// <summary>
        /// expression
        /// </summary>
        public string Expression { get; set; }

        /// <summary>
        /// cases
        /// </summary>
        public List<SwitchStepCase> ConditionList { get; set; }

        /// <summary>
        /// default
        /// </summary>
        public StepCollection DefaultSteps { get; set; }
    }

    /// <summary>
    /// SwitchStepExtension
    /// </summary>
    public static class SwitchStepExtension
    {
        /// <summary>
        /// WithElseIf
        /// </summary>
        public static TSwitchStep WithCase<TSwitchStep>(this TSwitchStep switchStep, SwitchStepCase switchStepCase)
            where TSwitchStep : SwitchStep
        {
            if (switchStep.ConditionList == null)
            {
                switchStep.ConditionList = new List<SwitchStepCase>();
            }

            switchStep.ConditionList.Add(switchStepCase);

            return switchStep;
        }

        /// <summary>
        /// WithElseIf
        /// </summary>
        public static SwitchStepCase WithCase(this SwitchStep switchStep, DataKey conditonExpression)
        {
            if (switchStep.ConditionList == null)
            {
                switchStep.ConditionList = new List<SwitchStepCase>();
            }

            SwitchStepCase switchStepCase = new SwitchStepCase();
            switchStepCase.ConditionExpression = conditonExpression;

            switchStep.ConditionList.Add(switchStepCase);

            return switchStepCase;
        }
        /// <summary>
        /// WithBreak
        /// </summary>
        public static TSwitchStep WithDefault<TSwitchStep>(this TSwitchStep switchStep, StepCollection stepBuilderCollection)
            where TSwitchStep : SwitchStep
        {
            switchStep.DefaultSteps = stepBuilderCollection;

            return switchStep;
        }

        /// <summary>
        /// WithDefault
        /// </summary>
        public static StepCollection WithDefault(this SwitchStep switchStep)
        {
            StepCollection stepBuilderCollection = new StepCollection();

            switchStep.DefaultSteps = stepBuilderCollection;

            return stepBuilderCollection;
        }
    }
}
