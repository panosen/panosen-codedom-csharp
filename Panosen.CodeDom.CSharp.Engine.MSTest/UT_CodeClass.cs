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
    /// 字段 2
    /// </summary>
    private int Field2 = 222;

    /// <summary>
    /// 字段 3
    /// </summary>
    private string Field3 = ""333"";

    /// <summary>
    /// 属性 0
    /// </summary>
    public int Property0 { get; set; }

    /// <summary>
    /// 属性 1
    /// </summary>
    public virtual int Property1 { get; set; }

    /// <summary>
    /// 属性 2
    /// </summary>
    public override string Property2 { get; set; }

    /// <summary>
    /// 属性 3
    /// </summary>
    public int Property3 { get; set; } = 333;

    /// <summary>
    /// 属性 4
    /// </summary>
    public int Property4 { get; set; } = 444;

    /// <summary>
    /// 属性 5
    /// </summary>
    public string Property5 { get; set; } = ""555"";

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

            codeClass.PropertyList = new List<CodeProperty>();

            {
                codeClass.AddProperty("int", "Property0", summary: "属性 0");
            }
            {
                codeClass.AddProperty("int", "Property1", summary: "属性 1", isVirtual: true);
            }
            {
                codeClass.AddProperty("string", "Property2", summary: "属性 2", isOverride: true);
            }
            {
                codeClass.AddProperty("int", "Property3", summary: "属性 3", value: (DataValue)333);
            }
            {
                codeClass.AddProperty("int", "Property4", summary: "属性 4", value: (DataValue)"444");
            }
            {
                codeClass.AddProperty("string", "Property5", summary: "属性 5", value: DataValue.DoubleQuotationString("555"));
            }

            {
                codeClass.AddField("string", "Field0", summary: "字段 0");
            }
            {
                codeClass.AddField("string", "Field1", summary: "字段 1");
            }
            {
                codeClass.AddField("int", "Field2", summary: "字段 2", value: (DataValue)222);
            }
            {
                codeClass.AddField("string", "Field3", summary: "字段 3", value: DataValue.DoubleQuotationString("333"));
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

                codeMethod.StepCollection = new StepCollection();

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
            methodX.StepCollection = new StepCollection();

            codeClass.AddConstructor(new CodeMethod
            {
                Name = "TheConstructor",
                AccessModifiers = AccessModifiers.Public,
                StepCollection = new StepCollection()
            });

            var property1 = codeClass.AddProperty("int", "age");
            property1.AddGetStepCollection().StepStatement("return 1;");
            property1.AddSetStepCollection().StepStatement("//okok").StepStatement("this.xxx = 2;");

            return codeClass;
        }
    }
}
