using System;
using System.IO;

namespace Panosen.CodeDom.CSharp.Engine
{
    public partial class CSharpCodeEngine
    {
        /// <summary>
        /// Generate
        /// </summary>
        public void Generate(CodeWriter codeWriter, Code code, GenerateOptions options = null)
        {
            if (code == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            if (code is CodeNamespace)
            {
                GenerateNamespace(codeWriter, code as CodeNamespace, options);
                return;
            }

            if (code is CodeClass)
            {
                GenerateClass(codeWriter, code as CodeClass, options);
                return;
            }

            if (code is CodeInterface)
            {
                GenerateInterface(codeWriter, code as CodeInterface, options);
                return;
            }

            if (code is CodeExpression)
            {
                GenerateExpresion(codeWriter, code as CodeExpression, options);
                return;
            }

            if (code is CodeMethod)
            {
                GenerateMethod(codeWriter, code as CodeMethod, options);
                return;
            }

            if (code is CodeEnum)
            {
                GenerateEnum(codeWriter, code as CodeEnum, options);
                return;
            }
        }
    }
}
