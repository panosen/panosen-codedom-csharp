using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine
{
    partial class CSharpCodeEngine
    {
        private void GenerateAttribute(CodeAttribute codeAttribute, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeAttribute == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            List<string> items = new List<string>();
            if (codeAttribute.ParamList != null && codeAttribute.ParamList.Count > 0)
            {
                items.AddRange(codeAttribute.ParamList.Select(v => ToValue(v)));
            }
            if (codeAttribute.ParamMap != null && codeAttribute.ParamMap.Count > 0)
            {
                items.AddRange(codeAttribute.ParamMap.Select(v => $"{v.Key} = {ToValue(v.Value)}"));
            }
            var itemString = items.Count > 0 ? $"({(string.Join(", ", items))})" : string.Empty;

            codeWriter.Write(Marks.LEFT_SQUARE_BRACKET).Write(codeAttribute.Name ?? string.Empty).Write(itemString).Write(Marks.RIGHT_SQUARE_BRACKET);
        }

        private static string ToValue(CodeValue codeValue)
        {
            switch (codeValue.Type)
            {
                case CodeValueType.STRING:
                    return $"\"{codeValue.Value}\"";

                case CodeValueType.PLAIN:
                default:
                    return codeValue.Value;
            }
        }
    }
}
