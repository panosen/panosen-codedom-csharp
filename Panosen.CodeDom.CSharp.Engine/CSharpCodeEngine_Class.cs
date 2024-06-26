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
        /// 生成类
        /// </summary>
        public void GenerateClass(CodeWriter codeWriter, CodeClass codeClass, GenerateOptions options = null)
        {
            if (codeClass == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            GenerateSummary(codeClass.Summary, codeWriter, options);

            if (codeClass.AttributeList != null && codeClass.AttributeList.Count > 0)
            {
                foreach (var codeAttribute in codeClass.AttributeList)
                {
                    codeWriter.Write(options.IndentString);
                    GenerateAttribute(codeAttribute, codeWriter, options);
                    codeWriter.WriteLine();
                }
            }

            codeWriter.Write(options.IndentString);

            if (codeClass.AccessModifiers != AccessModifiers.None)
            {
                codeWriter.Write(codeClass.AccessModifiers.Value()).Write(Marks.WHITESPACE);
            }

            if (codeClass.IsStatic)
            {
                codeWriter.Write(Keywords.STATIC).Write(Marks.WHITESPACE);
            }

            if (codeClass.IsAbstract)
            {
                codeWriter.Write(Keywords.ABSTRACT).Write(Marks.WHITESPACE);
            }

            if (codeClass.IsPartial)
            {
                codeWriter.Write(Keywords.PARTIAL).Write(Marks.WHITESPACE);
            }

            if (codeClass.IsSealed)
            {
                codeWriter.Write(Keywords.SEALED).Write(Marks.WHITESPACE);
            }

            codeWriter.Write(Keywords.CLASS).Write(Marks.WHITESPACE).Write(codeClass.Name ?? string.Empty);

            //泛型参数
            GenerateGeneraicParameters(codeClass.GenericParamsterList, codeWriter, options);

            List<string> items = new List<string>();
            if (codeClass.BaseClass != null)
            {
                items.Add(codeClass.BaseClass.Name);
            }
            if (codeClass.InterfaceList != null && codeClass.InterfaceList.Count > 0)
            {
                items.AddRange(codeClass.InterfaceList.Select(v => v.Name));
            }
            if (items.Count > 0)
            {
                codeWriter.Write(Marks.WHITESPACE).Write(Marks.COLON).Write(Marks.WHITESPACE).Write(string.Join(", ", items));
            }

            //泛型参数约束
            GenerateGenericParametersConstraint(codeClass.GenericParamsterList, codeWriter, options);

            codeWriter.WriteLine();

            codeWriter.Write(options.IndentString).WriteLine(Marks.LEFT_BRACE);

            options.PushIndent();

            if (codeClass.ConstantList != null && codeClass.ConstantList.Count > 0)
            {
                foreach (var codeConstant in codeClass.ConstantList)
                {
                    codeWriter.WriteLine();
                    GenerateConstant(codeConstant, codeWriter, options);
                }
            }

            if (codeClass.FieldList != null && codeClass.FieldList.Count > 0)
            {
                foreach (var codeField in codeClass.FieldList)
                {
                    codeWriter.WriteLine();
                    GenerateField(codeField, codeWriter, options);
                }
            }

            if (codeClass.PropertyList != null && codeClass.PropertyList.Count > 0)
            {
                foreach (var codeProperty in codeClass.PropertyList)
                {
                    codeWriter.WriteLine();
                    GenerateProperty(codeProperty, codeWriter, options);
                }
            }

            if (codeClass.ConstructorList != null && codeClass.ConstructorList.Count > 0)
            {
                foreach (var codeConstructor in codeClass.ConstructorList)
                {
                    codeWriter.WriteLine();
                    GenerateMethod(codeWriter, codeConstructor,  options);
                }
            }

            if (codeClass.MethodList != null && codeClass.MethodList.Count > 0)
            {
                foreach (var codeMethod in codeClass.MethodList)
                {
                    codeWriter.WriteLine();
                    GenerateMethod(codeWriter, codeMethod, options);
                }
            }

            options.PopIndent();

            codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
        }
    }
}
