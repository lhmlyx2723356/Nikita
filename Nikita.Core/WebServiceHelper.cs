using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web.Services.Description;

namespace Nikita.Core
{
    public class WebServiceHelper
    {
        /// <summary>

        /// 动态调用WebService

        /// </summary>

        /// <param name="url">WebService地址</param>

        /// <param name="methodname">方法名(模块名)</param>

        /// <param name="args">参数列表</param>

        /// <returns>object</returns>

        public static object InvokeWebService(string url, string methodname, object[] args)
        {
            return InvokeWebService(url, null, methodname, args);
        }

        /// <summary>

        /// 动态调用WebService

        /// </summary>

        /// <param name="url">WebService地址</param>

        /// <param name="classname">类名</param>

        /// <param name="methodname">方法名(模块名)</param>

        /// <param name="args">参数列表</param>

        /// <returns>object</returns>

        public static object InvokeWebService(string url, string classname, string methodname, object[] args)
        {
            const string @namespace = "ServiceBase.WebService.DynamicWebLoad";

            if (string.IsNullOrEmpty(classname))
            {
                classname = GetClassName(url);
            }

            //获取服务描述语言(WSDL)

            WebClient wc = new WebClient();

            Stream stream = wc.OpenRead(url + "?WSDL");

            ServiceDescription sd = ServiceDescription.Read(stream);

            ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();

            sdi.AddServiceDescription(sd, "", "");

            CodeNamespace cn = new CodeNamespace(@namespace);

            //生成客户端代理类代码

            CodeCompileUnit ccu = new CodeCompileUnit();

            ccu.Namespaces.Add(cn);

            sdi.Import(cn, ccu);

            CSharpCodeProvider csc = new CSharpCodeProvider();

            ICodeCompiler icc = csc.CreateCompiler();

            //设定编译器的参数

            CompilerParameters cplist = new CompilerParameters { GenerateExecutable = false, GenerateInMemory = true };

            cplist.ReferencedAssemblies.Add("System.dll");

            cplist.ReferencedAssemblies.Add("System.XML.dll");

            cplist.ReferencedAssemblies.Add("System.Web.Services.dll");

            cplist.ReferencedAssemblies.Add("System.Data.dll");

            //编译代理类

            CompilerResults cr = icc.CompileAssemblyFromDom(cplist, ccu);

            if (cr.Errors.HasErrors)
            {
                StringBuilder sb = new StringBuilder();

                foreach (CompilerError ce in cr.Errors)
                {
                    sb.Append(ce);

                    sb.Append(Environment.NewLine);
                }

                throw new Exception(sb.ToString());
            }

            //生成代理实例,并调用方法

            Assembly assembly = cr.CompiledAssembly;

            Type t = assembly.GetType(@namespace + "." + classname, true, true);

            object obj = Activator.CreateInstance(t);

            MethodInfo mi = t.GetMethod(methodname);

            if (args == null)
            {
                return mi.Invoke(obj, null);
            }
            else
            {
                return mi.Invoke(obj, args);
            }
        }

        private static string GetClassName(string url)
        {
            string[] parts = url.Split('/');

            string[] pps = parts[parts.Length - 1].Split('.');

            return pps[0];
        }
    }
}