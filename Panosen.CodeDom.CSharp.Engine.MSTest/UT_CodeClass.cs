using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Panosen.CodeDom.CSharp.Engine.MSTest
{
    [TestClass]
    public class UT_CodeClass : UTBase
    {
        protected override string PrepareExpected()
        {
            return @"/// <summary>
/// 学生
/// </summary>
public class Student
{

	/// <summary>
	/// 常量 0
	/// </summary>
	const string Constant0 = ""aa"";

	/// <summary>
	/// 常量 1
	/// </summary>
	const string Constant1 = ""aa"";

	/// <summary>
	/// 字段 0
	/// </summary>
	private string Field0;

	/// <summary>
	/// 字段 1
	/// </summary>
	private string Field1;

	/// <summary>
	/// 属性 0
	/// </summary>
	public int Property0 { get; set; }

	/// <summary>
	/// 属性 1
	/// </summary>
	public int Property1 { get; set; }

	public int age
	{
		get { return 1; }
		set
		{
			//okok
			this.xxx = 2;
		}
	}

	public TheConstructor()
	{
	}

	/// <summary>
	/// 方法 0
	/// </summary>
	public int Method0(int p1, int p2, int p3)
	{
	}

	/// <summary>
	/// 方法 1
	/// </summary>
	public int Method1(int p1, int p2, int p3)
	{
	}

	methodX(
		int p1,
		int p2,
		int p3,
		int p4)
	{
	}
}
";
        }

        protected override Code PrepareCode()
        {
            CodeClass codeClass = new CodeClass();
            codeClass.Name = "Student";
            codeClass.Summary = "学生";
            codeClass.AccessModifiers = AccessModifiers.Public;

            codeClass.AddSystemUsing(SystemUsing.SystemText);
            codeClass.AddNugetUsing("Newtonsoft.Json");
            codeClass.AddProjectUsing("SampleProject");

            codeClass.PropertyList = new List<CodeProperty>();
            for (int i = 0; i < 2; i++)
            {
                var codeProperty = new CodeProperty();
                codeClass.PropertyList.Add(codeProperty);

                codeProperty.Name = $"Property{i}";
                codeProperty.Type = "int";
                codeProperty.Summary = $"属性 {i}";
            }

            codeClass.FieldList = new List<CodeField>();
            for (int i = 0; i < 2; i++)
            {
                var codeField = new CodeField();
                codeClass.FieldList.Add(codeField);

                codeField.Name = $"Field{i}";
                codeField.Type = "string";
                codeField.Summary = $"字段 {i}";
            }

            codeClass.ConstantList = new List<CodeConstant>();
            for (int i = 0; i < 2; i++)
            {
                var codeConstant = new CodeConstant();
                codeClass.ConstantList.Add(codeConstant);

                codeConstant.Name = $"Constant{i}";
                codeConstant.Type = "string";
                codeConstant.Value = "\"aa\"";
                codeConstant.Summary = $"常量 {i}";
            }

            codeClass.MethodList = new List<CodeMethod>();
            for (int i = 0; i < 2; i++)
            {
                var codeMethod = new CodeMethod();
                codeClass.MethodList.Add(codeMethod);

                codeMethod.Name = $"Method{i}";
                codeMethod.Type = "int";
                codeMethod.Summary = $"方法 {i}";
                codeMethod.AccessModifiers = AccessModifiers.Public;

                codeMethod.StepBuilders = new List<StepBuilderOrCollection>();

                codeMethod.Parameters = new List<CodeParameter>();
                for (int j = 0; j < 3; j++)
                {
                    var codeParameter = new CodeParameter();
                    codeMethod.Parameters.Add(codeParameter);

                    codeParameter.Name = $"p{j + 1}";
                    codeParameter.Type = "int";
                }
            }

            var methodX = codeClass.AddMethod("methodX");
            for (int i = 0; i < 4; i++)
            {
                methodX.AddParameter("int", $"p{i + 1}");
            }
            methodX.StepBuilders = new List<StepBuilderOrCollection>();

            codeClass.AddConstructor(new CodeMethod
            {
                Name = "TheConstructor",
                AccessModifiers = AccessModifiers.Public,
                StepBuilders = new List<StepBuilderOrCollection>()
            });

            var property1 = codeClass.AddProperty("int", "age");
            property1.AddGetStepBuilderCollection().StepStatement("return 1;");
            property1.AddSetStepBuilderCollection().StepStatement("//okok").StepStatement("this.xxx = 2;");

            return codeClass;
        }
    }
}
