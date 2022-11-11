using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp
{
    /// <summary>
    /// SwitchStepCondition
    /// </summary>
    public class SwitchStepCase : StepCollection
    {
        /// <summary>
        /// case 后面跟的语句
        /// </summary>
        public DataKey ConditionExpression { get; set; }

        /// <summary>
        /// 不包含语句和break，直接贯穿到下一个case
        /// </summary>
        public bool LinkToNext { get; set; }
    }

    /// <summary>
    /// SwitchStepCaseExtension
    /// </summary>
    public static class SwitchStepCaseExtension
    {
        /// <summary>
        /// LinkToNext
        /// </summary>
        public static TSwitchStepCase SetConditionExpression<TSwitchStepCase>(this TSwitchStepCase switchStepCase, DataKey conditionExpression)
            where TSwitchStepCase : SwitchStepCase
        {
            switchStepCase.ConditionExpression = conditionExpression;

            return switchStepCase;
        }

        /// <summary>
        /// LinkToNext
        /// </summary>
        public static TSwitchStepCase SetLinkToNext<TSwitchStepCase>(this TSwitchStepCase switchStepCase, bool linkToNext)
            where TSwitchStepCase : SwitchStepCase
        {
            switchStepCase.LinkToNext = linkToNext;

            return switchStepCase;
        }
    }
}
