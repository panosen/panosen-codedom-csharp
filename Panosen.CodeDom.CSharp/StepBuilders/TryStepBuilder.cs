using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp
{
    /// <summary>
    /// try
    /// </summary>
    public class TryStepBuilder : StepBuilderCollection
    {
        /// <summary>
        /// catch
        /// </summary>
        public List<CatchStepBuilder> CatchStepBuilders { get; set; }

        /// <summary>
        /// finally
        /// </summary>
        public FinallyStepBuilder FinallyStepBuilder { get; set; }
    }

    /// <summary>
    /// try catch
    /// </summary>
    public static class TryStepBuilderExtension
    {
        /// <summary>
        /// catch(content)
        /// </summary>
        public static CatchStepBuilder WithCatch(this TryStepBuilder tryStepBuilder, string content = null)
        {
            if (tryStepBuilder.CatchStepBuilders == null)
            {
                tryStepBuilder.CatchStepBuilders = new List<CatchStepBuilder>();
            }

            CatchStepBuilder catchStepBuilder = new CatchStepBuilder();
            catchStepBuilder.Content = content;
            tryStepBuilder.CatchStepBuilders.Add(catchStepBuilder);

            return catchStepBuilder;
        }

        /// <summary>
        /// finally
        /// </summary>
        public static FinallyStepBuilder WithFinally(this TryStepBuilder tryStepBuilder)
        {
            FinallyStepBuilder finallyStepBuilder = new FinallyStepBuilder();

            tryStepBuilder.FinallyStepBuilder = finallyStepBuilder;

            return finallyStepBuilder;
        }
    }
}
