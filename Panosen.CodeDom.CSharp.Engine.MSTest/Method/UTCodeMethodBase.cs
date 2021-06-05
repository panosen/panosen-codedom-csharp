using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.CSharp.Engine.MSTest.Method
{
    public abstract class UTCodeMethodBase : UTBase
    {
        protected abstract void PrepareCodeMethod(CodeMethod codeMethod);

        protected sealed override Code PrepareCode()
        {
            CodeMethod codeMethod = new CodeMethod();
            codeMethod.AccessModifiers = AccessModifiers.Public;
            codeMethod.Name = "TestMethod";

            PrepareCodeMethod(codeMethod);

            return codeMethod;
        }
    }
}
