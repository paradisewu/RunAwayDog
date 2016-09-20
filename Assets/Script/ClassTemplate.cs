using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

//创建类模板(文件)  
//统一在语句末加上"\n"  
public class ClassTemplate
{

    private static StringBuilder builder;
    private static string path;
    private static string className;
    private static bool useNameSpace = false;

    private static string fourSpace = "    ";

    public static void Start(string savaPath)
    {
        builder = new StringBuilder();
        path = savaPath;
        className = savaPath.Substring(savaPath.LastIndexOf("/") + 1);
        className = className.Substring(0, className.IndexOf('.'));
        useNameSpace = false;
        //Debug.Log("className：" + className);  
    }

    public static void End()
    {
        if (useNameSpace) Write(fourSpace + "}\n}");
        else Write("\n}");
        File.WriteAllText(path, builder.ToString());
    }

    public static void WriteUsing(string s)
    {
        Write("using " + s + ";" + "\n");
    }

    public static void WriteNameSpace(string s)
    {
        useNameSpace = true;
        Write("\nnamespace " + s + "\n{\n");
    }

    public static void WriteClass(string parentName)
    {
        if (!useNameSpace) Write("\n");
        WriteZeroOrOneInterval();
        Write("public class " + className);
        if (!string.IsNullOrEmpty(parentName)) Write(" : " + parentName + " ");
        else Write(" ");
        WriteZeroOrOneInterval();
        Write("{\n\n");
    }

    //prefix即变量修饰符，如public static   
    public static void WriteField(string type, string name, string prefix = "public", string value = "")
    {
        WriteOneOrTwoInterval();
        if (string.IsNullOrEmpty(value)) Write(prefix + " " + type + " " + name + ";\n");
        else Write(prefix + " " + type + " " + name + " = " + value + ";\n");
    }

    /// <summary>  
    /// methodInfo:如public static void Init()  
    /// </summary>  
    /// <param name="methodInfo"></param>  
    public static void StartMethod(string methodInfo)
    {
        Write("\n");
        WriteOneOrTwoInterval();
        Write(methodInfo);
        Write("\n");
        WriteOneOrTwoInterval();
        Write("{\n");
    }

    public static void MethodProcess(string s)
    {
        WriteTwoOrThreeInterval();
        Write(s + "\n");
    }

    public static void EndMethod()
    {
        WriteOneOrTwoInterval();
        Write("}\n");
    }

    public static void WriteConstructionRead(List<string> name, List<string> readMethod)
    {
        Write("\n");
        WriteOneOrTwoInterval();
        Write("public " + className + "()\n");
        WriteOneOrTwoInterval();
        Write("{\n");

        for (int i = 0; i < name.Count; i++)
        {
            WriteTwoOrThreeInterval();
            Write(name[i] + " = " + readMethod[i] + "();\n");
        }

        WriteOneOrTwoInterval();
        Write("}\n\n");
    }

    public static void WriteConstructionCopy(List<string> name, List<string> readMethod)
    {
        Write("\n");
        WriteOneOrTwoInterval();
        Write("public " + className + "(" + className + " a" + ")\n");
        WriteOneOrTwoInterval();
        Write("{\n");

        for (int i = 0; i < name.Count; i++)
        {
            if (readMethod[i].Contains("List"))
            {
                string type = readMethod[i].Substring(4, readMethod[i].Length - 8).ToLower();
                //Debug.Log(type);  
                WriteTwoOrThreeInterval();
                Write(name[i] + " = new " + type + "[a." + name[i] + ".Length];\n");
                WriteTwoOrThreeInterval();
                Write("Array.Copy(a." + name[i] + ", " + name[i] + ", " + "a." + name[i] + ".Length);\n");
            }
            else if (readMethod[i].Contains("Dict"))
            {
                string type = readMethod[i].Substring(4, readMethod[i].Length - 8).ToLower();
                //Debug.Log(type);  
                WriteTwoOrThreeInterval();
                Write(name[i] + " = " + "new Dictionary<string, " + type + ">(a." + name[i] + ");\n");
            }
            else
            {
                WriteTwoOrThreeInterval();
                Write(name[i] + " = " + "a." + name[i] + ";\n");
            }
        }

        WriteOneOrTwoInterval();
        Write("}\n\n");
    }

    public static string GetClassName()
    {
        return className;
    }

    public static void Write(string s)
    {
        builder.Append(s);
    }

    private static void WriteZeroOrOneInterval()
    {
        if (useNameSpace) Write(fourSpace);
    }

    private static void WriteOneOrTwoInterval()
    {
        if (useNameSpace) Write(fourSpace + fourSpace);
        else Write(fourSpace);
    }

    private static void WriteTwoOrThreeInterval()
    {
        if (useNameSpace) Write(fourSpace + fourSpace + fourSpace);
        else Write(fourSpace + fourSpace);
    }

}
