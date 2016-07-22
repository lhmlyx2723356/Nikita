using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Nikita.Assist.FileLoader
{
    public class MyXmlFactory
    {
        public IDictionary<string, Files> definedFiles = new Dictionary<string, Files>();

        public MyXmlFactory(string configPath)
        {
            this.InitializeFileTypes(configPath);
        }

        private void InitializeFileTypes(string configPath)
        {
            try
            {
                XElement root = XElement.Load(configPath);
                foreach (var item in root.Elements("object"))
                {
                    // 通过反射动态创建具体类型实例
                    string className = item.FirstAttribute.Value;
                    string classPath = item.LastAttribute.Value;
                    Files file = (Files)System.Reflection.Assembly.Load(classPath).CreateInstance(classPath + "." + className);
                    definedFiles.Add(new KeyValuePair<string, Files>(
                            className,
                            file
                        ));
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
           
        }
    }
}
