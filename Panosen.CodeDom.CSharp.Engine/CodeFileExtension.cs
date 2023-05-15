using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine
{
    /// <summary>
    /// CodeFile Extension
    /// </summary>
    public static class CodeFileExtension
    {
        /// <summary>
        /// TransformText
        /// </summary>
        public static string TransformText(this CodeFile codeFile)
        {
            CSharpCodeEngine generator = new CSharpCodeEngine();

            StringBuilder builder = new StringBuilder();

            generator.GenerateCodeFile(builder, codeFile);

            return builder.ToString();
        }
    }
}
