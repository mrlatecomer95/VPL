using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using ICSharpCode.NRefactory.Editor;

namespace NodeClassGenerator
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            var filePath = @"E:\Documents\Git\VPL\MISC\Libraries\PIPoint.dll";

            var text = "";
            //IDocument document = new ReadOnlyDocument(new StringTextSource(text), filePath);

            Assembly assembly = Assembly.LoadFile(filePath);
            var Types = assembly.GetTypes();
            var list = GetFunctionList(assembly);

            var expoType = assembly.GetExportedTypes().First(x => !x.IsEnum && x.IsVisible);
            var mList = expoType.GetMethods().Where(m => list.Contains(m.Name)).ToList();
            foreach (var method in mList)
            {
                //var param = method.GetParameters();
                GenerateNode(method);
            }
        }
        private static List<string> GetFunctionList(Assembly assembly)
        {
            var enumFuncList = assembly.GetTypes().FirstOrDefault(x => x.IsEnum && x.Name == "FunctionList");
            if (enumFuncList != null)
            {
                var list = new List<string>();
                foreach (var item in Enum.GetValues(enumFuncList))
                {
                    list.Add(item.ToString());
                }
                return list;
            }
            return new List<string>();
        }


        private static void GenerateNode(MethodInfo method)
        {

            var name = method.Name;
            var parameters = method.GetParameters();
            var fileString = "";

            fileString += NodeStateBody(method);

            //var path = @"c:\temp\" + name + ".cs";
            var path = AppDomain.CurrentDomain.BaseDirectory + string.Format(@"\Nodes");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = string.Format(@"{0}\{1}.cs", path, name);
            File.WriteAllText(path, fileString);
        }


        private static string NodeUsingStatements(MethodInfo method)
        {
            var fileString = @"using System;
            using System.Windows;
            using System.Windows.Controls;
            using System.Xml;
            using TUM.CMS.VplControl.Core;
            using " + method.ReflectedType.Namespace + ";" + Environment.NewLine;

            return fileString;
        }

        private static string NodeStateBody(MethodInfo method)
        {
            var name = method.Name;

            var fileString = NodeUsingStatements(method);

            fileString += @"namespace " + method.ReflectedType.Namespace + @".Nodes
            {
                public class " + name + @" : Node
                {
                    public " + name + @"(VplControl hostCanvas): base(hostCanvas)

                    {" + Environment.NewLine;

            /* Generate Input Ports */

            fileString += NodeInputParams(method);
            fileString += NodeOutputParams(method) + "}";
            fileString += NodeCalulateMethod(method);
            fileString += NodeSerializeNetworkMethod(method);
            fileString += NodeDeserializeNetworkMethod(method);
            fileString += NodeCloneMethod(method) + Environment.NewLine + "}";
            fileString += Environment.NewLine + "}";
            return fileString;
        }

        private static string NodeInputParams(MethodInfo method)
        {
            var parameters = method.GetParameters();
            //return parameters.Aggregate("", (current, portInfo) => current + string.Format(@"AddInputPortToNode(""{0}"", Type.GetType(""{1}""));" + Environment.NewLine, portInfo.Name, portInfo.ParameterType.ToString()));

            var fileString = "";
            foreach (var portInfo in parameters)
            {
                fileString += string.Format(@"AddInputPortToNode(""{0}"", Type.GetType(""{1}""));" + Environment.NewLine, portInfo.Name, portInfo.ParameterType.ToString());
            }
            return fileString;
        }
        private static string NodeOutputParams(MethodInfo method)
        {
            var fileString = "";
            fileString += string.Format(@"AddOutputPortToNode(""Output"",Type.GetType(""{0}""));" + Environment.NewLine, method.GetType().ToString());
            return fileString;
        }

        private static string NodeCalulateMethod(MethodInfo method)
        {
            var fileString = @" public override void Calculate()" + Environment.NewLine + "{" + Environment.NewLine;
            var paramCount = 0;
            foreach (var parameterInfo in method.GetParameters())
            {
                GetTypeToString(parameterInfo);
                fileString += "var input" + paramCount + " =  Convert.ChangeType(InputPorts[" + paramCount +
                              @"].Data, Type.GetType(""" + parameterInfo.ParameterType.ToString() + @"""));" + Environment.NewLine;
                paramCount++;
            }

            fileString += string.Format(@"{0}.{1}(", method.ReflectedType.Name, method.Name);


            for (int i = 0; i < paramCount; i++)
            {
                fileString += string.Format(@"input{0},", i);
            }
            //Finalize FileString
            fileString = fileString.Substring(0, fileString.Length - 1);

            fileString += ");" + Environment.NewLine;

            fileString += "}" + Environment.NewLine;

            return fileString;
        }

        private static string NodeSerializeNetworkMethod(MethodInfo method)
        {
            return @"public override void SerializeNetwork(XmlWriter xmlWriter)
                    {
                        base.SerializeNetwork(xmlWriter);

                        // add your xml serialization methods here
                    }" + Environment.NewLine;
        }

        private static string NodeDeserializeNetworkMethod(MethodInfo method)
        {
            return @"                    public override void DeserializeNetwork(XmlReader xmlReader)
                    {
                        base.DeserializeNetwork(xmlReader);

                        // add your xml deserialization methods here
                    }" + Environment.NewLine;
        }

        private static string NodeCloneMethod(MethodInfo method)
        {
            return @" public override Node Clone()
                    {
                        return new " + method.Name + @"(HostCanvas)
                        {
                            Top = Top,
                            Left = Left
                        };
                    }" + Environment.NewLine;
        }


        #region PRIVATE Functions

        private static string GetTypeToString(ParameterInfo paramInfo)
        {
            var TypeName = paramInfo.ParameterType.ToString();

            if (paramInfo.ParameterType.Equals(typeof(List<string>)))
            {
                return paramInfo.ParameterType.ToString();
            }
            else
            {
                return paramInfo.ParameterType.ToString();
            }
            //switch (TypeName)
            //{
            //    case "System.Collections.Generic.List`1[System.String]":
                    
            //        break;
            //    default:
            //        return "";
            //}
            return "";

        }
        #endregion
    }

    public class PortInfo
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
