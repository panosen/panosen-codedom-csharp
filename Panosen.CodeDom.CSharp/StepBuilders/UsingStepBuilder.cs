using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp
{
    public class UsingStepBuilder : StepBuilderCollection
    {
        public string Content { get; set; }
    }

    public static class UsingStepBuilderExtension
    {
        public static TUsingStepBuilder Use<TUsingStepBuilder>(this TUsingStepBuilder usingStepBuilder, string content)
            where TUsingStepBuilder : UsingStepBuilder
        {
            usingStepBuilder.Content = content;

            return usingStepBuilder;
        }
    }
}
