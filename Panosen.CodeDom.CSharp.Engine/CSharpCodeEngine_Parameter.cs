using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine
{
    partial class CSharpCodeEngine
    {
        /// <summary>
        /// GenerateParameter
        /// </summary>
        public void GenerateParameter(CodeParameter codeParameter, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeParameter == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            if (codeParameter.AttributeList != null && codeParameter.AttributeList.Count > 0)
            {
                foreach (var codeAttribute in codeParameter.AttributeList)
                {
                    GenerateAttribute(codeAttribute, codeWriter, options);
                }
                codeWriter.Write(Marks.WHITESPACE);
            }

            if (codeParameter.WithThis)
            {
                codeWriter.Write(Keywords.THIS).Write(Marks.WHITESPACE);
            }

            if (codeParameter.WithOut)
            {
                codeWriter.Write(Keywords.OUT).Write(Marks.WHITESPACE);
            }

            if (codeParameter.WithRef)
            {
                codeWriter.Write(Keywords.REF).Write(Marks.WHITESPACE);
            }

            codeWriter.Write(codeParameter.Type).Write(Marks.WHITESPACE).Write(codeParameter.Name);
        }
    }
}
