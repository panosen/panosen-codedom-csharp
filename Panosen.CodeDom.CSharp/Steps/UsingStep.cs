using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp
{
    /// <summary>
    /// UsingStep
    /// </summary>
    public class UsingStep : StepCollection
    {
        /// <summary>
        /// Content
        /// </summary>
        public string Content { get; set; }
    }

    /// <summary>
    /// UsingStepExtension
    /// </summary>
    public static class UsingStepExtension
    {
        /// <summary>
        /// Use
        /// </summary>
        /// <typeparam name="TUsingStep"></typeparam>
        /// <param name="usingStep"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static TUsingStep Use<TUsingStep>(this TUsingStep usingStep, string content)
            where TUsingStep : UsingStep
        {
            usingStep.Content = content;

            return usingStep;
        }
    }
}
