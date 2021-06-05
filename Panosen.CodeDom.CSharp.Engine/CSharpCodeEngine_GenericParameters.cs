using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine
{
    partial class CSharpCodeEngine
    {
        /// <summary>
        /// 泛型参数
        /// </summary>
        private void GenerateGeneraicParameters(List<CodeGenericParamster> genericParamsters, CodeWriter codeWriter, GenerateOptions options)
        {
            if (genericParamsters == null || genericParamsters.Count == 0)
            {
                return;
            }
            if (codeWriter == null)
            {
                return;
            }
            options = options ?? new GenerateOptions();

            codeWriter.Write(Marks.LESS_THAN);

            var enumerator = genericParamsters.GetEnumerator();
            var moveNext = enumerator.MoveNext();
            while (moveNext)
            {
                var current = enumerator.Current;
                codeWriter.Write(current.Name);

                moveNext = enumerator.MoveNext();
                if (moveNext)
                {
                    codeWriter.Write(Marks.COMMA).Write(Marks.WHITESPACE);
                }
            }

            codeWriter.Write(Marks.GREATER_THAN);
        }

        /// <summary>
        /// 泛型参数约束
        /// </summary>
        /// <param name="genericParamsters"></param>
        /// <param name="codeWriter"></param>
        /// <param name="options"></param>
        private void GenerateGenericParametersConstraint(List<CodeGenericParamster> genericParamsters, CodeWriter codeWriter, GenerateOptions options)
        {
            if (genericParamsters == null || genericParamsters.Count == 0)
            {
                return;
            }
            if (codeWriter == null)
            {
                return;
            }
            options = options ?? new GenerateOptions();

            foreach (var genericParameter in genericParamsters)
            {
                if (genericParameter.Constraints == null || genericParameter.Constraints.Count == 0)
                {
                    continue;
                }
                codeWriter.Write(Marks.WHITESPACE).Write(Keywords.WHERE).Write(Marks.WHITESPACE);

                codeWriter.Write(genericParameter.Name);

                codeWriter.Write(Marks.WHITESPACE).Write(Marks.COLON).Write(Marks.WHITESPACE);

                var enumerator = genericParameter.Constraints.GetEnumerator();
                var moveNext = enumerator.MoveNext();
                while (moveNext)
                {
                    var current = enumerator.Current;
                    codeWriter.Write(current);

                    moveNext = enumerator.MoveNext();
                    if (moveNext)
                    {
                        codeWriter.Write(Marks.COMMA).Write(Marks.WHITESPACE);
                    }
                }
            }
        }
    }
}
