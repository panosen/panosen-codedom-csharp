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
        /// GenerateDataItem
        /// </summary>
        public void GenerateDataItem(DataItem dataItem, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (dataItem is DataValue)
            {
                GenerateDataValue(dataItem as DataValue, codeWriter, options);
            }

            if (dataItem is CodeLamdaNewInstance)
            {
                GenerateLamdaNewInstance(dataItem as CodeLamdaNewInstance, codeWriter, options);
            }

            if (dataItem is CodeLamdaExpression)
            {
                GenerateLamdaExpression(dataItem as CodeLamdaExpression, codeWriter, options);
            }

            if (dataItem is CodeLamdaStepCollection)
            {
                GenerateLamdaStepCollection(dataItem as CodeLamdaStepCollection, codeWriter, options);
            }
        }
    }
}
