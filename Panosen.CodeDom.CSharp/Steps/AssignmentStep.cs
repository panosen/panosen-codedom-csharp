using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp
{
    /// <summary>
    /// 赋值
    /// </summary>
    public class AssignmentStep : Step
    {
        /// <summary>
        /// 等号左边的变量
        /// </summary>
        public string Left { get; set; }

        /// <summary>
        /// 等号右边的值
        /// </summary>
        public CodeExpression Right { get; set; }
    }

    /// <summary>
    /// AssignStep Extension
    /// </summary>
    public static class AssignmentStepExtension
    {
        /// <summary>
        /// 设置等号左边的变量
        /// </summary>
        public static TAssignmentStep SetLeft<TAssignmentStep>(this TAssignmentStep assignVariableStep, string left)
            where TAssignmentStep : AssignmentStep
        {
            assignVariableStep.Left = left;

            return assignVariableStep;
        }

        /// <summary>
        /// 设置等号右边的变量
        /// </summary>
        public static TAssignmentStep SetRight<TAssignmentStep>(this TAssignmentStep assignVariableStep, string right)
            where TAssignmentStep : AssignmentStep
        {
            assignVariableStep.Left = right;

            return assignVariableStep;
        }

        /// <summary>
        /// 设置等号右边的值
        /// </summary>
        public static TAssignmentStep SetRight<TAssignmentStep>(this TAssignmentStep assignmentStep, CodeExpression codeExpression)
            where TAssignmentStep : AssignmentStep
        {
            assignmentStep.Right = codeExpression;

            return assignmentStep;
        }

        /// <summary>
        /// 设置等号右边的值
        /// </summary>
        private static TCodeExpression SetRight<TCodeExpression>(this AssignmentStep assignmentStep)
            where TCodeExpression : CodeExpression, new()
        {
            TCodeExpression codeExpression = new TCodeExpression();

            assignmentStep.Right = codeExpression;

            return codeExpression;
        }

        /// <summary>
        /// 设置等号右边的值
        /// </summary>
        public static ReferenceExpression SetRightOfReferenceExpression<TAssignmentStep>(this TAssignmentStep assignmentStep)
            where TAssignmentStep : AssignmentStep
        {
            return SetRight<ReferenceExpression>(assignmentStep);
        }

        /// <summary>
        /// 设置等号右边的值
        /// </summary>
        public static CallMethodExpression SetRightOfCallMethodExpression<TAssignmentStep>(this TAssignmentStep assignmentStep, string methodName = null)
            where TAssignmentStep : AssignmentStep
        {
            return SetRight<CallMethodExpression>(assignmentStep).SetMethodName(methodName);
        }
    }
}
