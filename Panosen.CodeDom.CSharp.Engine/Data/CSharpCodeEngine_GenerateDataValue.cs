﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharp.Engine
{
    partial class CSharpCodeEngine
    {
        /// <summary>
        /// GenerateDataValue
        /// </summary>
        public void GenerateDataValue(DataValue dataValue, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (dataValue.Value == null)
            {
                codeWriter.Write("null");
            }
            else
            {
                codeWriter.Write(dataValue.Value ?? "null");
            }
        }
    }
}
