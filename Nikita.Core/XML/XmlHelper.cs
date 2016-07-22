using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Nikita.Core.XML
{
    /// <summary> XML操作类
    ///
    /// </summary>
    public class XmlHelper
    {
        #region 变量

        protected XmlDocument ObjXmlDoc = new XmlDocument();
        protected string StrXmlFile;

        #endregion 变量

        #region Constructors

        public XmlHelper(string xmlFile)
        {
            try
            {
                ObjXmlDoc.Load(xmlFile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            StrXmlFile = xmlFile;
        }

        #endregion Constructors

        /// <summary>反序列化
        ///
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static object Deserialize(string path)
        {
            try
            {
                using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    IFormatter formatter = new BinaryFormatter();
                    stream.Seek(0, SeekOrigin.Begin);
                    object obj = formatter.Deserialize(stream);
                    stream.Close();
                    return obj;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>序列化
        ///
        /// </summary>
        /// <param name="path"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Serialize(string path, object obj)
        {
            try
            {
                using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    IFormatter format = new BinaryFormatter();

                    format.Serialize(stream, obj);
                    stream.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        ///  <summary> 反序列化
        ///
        ///  </summary>
        ///  <param name="path"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object XmlDeserialize(string path, Type type)
        {
            try
            {
                using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    XmlSerializer formatter = new XmlSerializer(type);
                    stream.Seek(0, SeekOrigin.Begin);
                    object obj = formatter.Deserialize(stream);
                    stream.Close();
                    return obj;
                }
            }
            catch
            {
                return null;
            }
        }

        ///  <summary> 序列化
        ///
        ///  </summary>
        ///  <param name="path"></param>
        ///  <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool XmlSerialize(string path, object obj, Type type)
        {
            try
            {
                if (!File.Exists(path))
                {
                    FileInfo fi = new FileInfo(path);
                    if (fi.Directory != null && !fi.Directory.Exists)
                    {
                        Directory.CreateDirectory(fi.Directory.FullName);
                    }

                    //File.Create(path);
                }

                using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    XmlSerializer format = new XmlSerializer(type);

                    format.Serialize(stream, obj);
                    stream.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>删除节点
        ///
        /// </summary>
        /// <param name="node"></param>
        public void Delete(string node)
        {
            string mainNode = node.Substring(0, node.LastIndexOf("/", StringComparison.Ordinal));
            var selectSingleNode = ObjXmlDoc.SelectSingleNode(mainNode);
            if (selectSingleNode != null)
                selectSingleNode.RemoveChild(ObjXmlDoc.SelectSingleNode(node));
        }

        /// <summary> 获取节点下的DataSet
        ///
        /// </summary>
        /// <param name="XmlPathNode"></param>
        /// <returns></returns>
        public DataSet GetData(string XmlPathNode)
        {
            DataSet ds = new DataSet();
            StringReader read = new StringReader(ObjXmlDoc.SelectSingleNode(XmlPathNode).OuterXml);
            ds.ReadXml(read);
            return ds;
        }

        /// <summary>插入一个节点带一个属性
        ///
        /// </summary>
        /// <param name="MainNode"></param>
        /// <param name="Element"></param>
        /// <param name="Attrib"></param>
        /// <param name="AttribContent"></param>
        /// <param name="Content"></param>
        public void InsertElement(string MainNode, string Element, string Attrib, string AttribContent, string Content)
        {
            XmlNode objNode = ObjXmlDoc.SelectSingleNode(MainNode);
            XmlElement objElement = ObjXmlDoc.CreateElement(Element);
            objElement.SetAttribute(Attrib, AttribContent);
            objElement.InnerText = Content;
            objNode.AppendChild(objElement);
        }

        /// <summary>插入
        ///
        /// </summary>
        /// <param name="MainNode"></param>
        /// <param name="Element"></param>
        /// <param name="Content"></param>
        public void InsertElement(string MainNode, string Element, string Content)
        {
            XmlNode objNode = ObjXmlDoc.SelectSingleNode(MainNode);
            XmlElement objElement = ObjXmlDoc.CreateElement(Element);
            objElement.InnerText = Content;
            objNode.AppendChild(objElement);
        }

        /// <summary> 插入一节点和此节点的一子节点
        ///
        /// </summary>
        /// <param name="MainNode"></param>
        /// <param name="ChildNode"></param>
        /// <param name="Element"></param>
        /// <param name="Content"></param>
        public void InsertNode(string MainNode, string ChildNode, string Element, string Content)
        {
            XmlNode objRootNode = ObjXmlDoc.SelectSingleNode(MainNode);
            XmlElement objChildNode = ObjXmlDoc.CreateElement(ChildNode);
            objRootNode.AppendChild(objChildNode);
            XmlElement objElement = ObjXmlDoc.CreateElement(Element);
            objElement.InnerText = Content;
            objChildNode.AppendChild(objElement);
        }

        /// <summary>读取节点内容
        ///
        /// </summary>
        /// <param name="xmlPathNode"></param>
        /// <param name="attrib"></param>
        /// <returns></returns>
        public string Read(string xmlPathNode, string attrib)
        {
            string value;
            try
            {
                XmlNode xn = ObjXmlDoc.SelectSingleNode(xmlPathNode);
                value = (attrib.Equals("") ? xn.InnerText : xn.Attributes[attrib].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return value;
        }

        public string ReadValue(string xmlPathNode, string xmlNextPathNode)
        {
            string value = "";
            try
            {
                var selectSingleNode = ObjXmlDoc.SelectSingleNode(xmlPathNode);
                if (selectSingleNode != null)
                {
                    XmlNode xn = selectSingleNode.SelectSingleNode(xmlNextPathNode);
                    value = xn.InnerText;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return value;
        }

        /// <summary>替换某节点的内容
        ///
        /// </summary>
        /// <param name="xmlPathNode"></param>
        /// <param name="content"></param>
        public void Replace(string xmlPathNode, string content)
        {
            var selectSingleNode = ObjXmlDoc.SelectSingleNode(xmlPathNode);
            if (selectSingleNode != null)
                selectSingleNode.InnerText = content;
        }

        public void ReplaceValue(string xmlPathNode, string xmlNextPathNode, string content)
        {
            var selectSingleNode = ObjXmlDoc.SelectSingleNode(xmlPathNode);
            if (selectSingleNode != null)
            {
                var singleNode = selectSingleNode.SelectSingleNode(xmlNextPathNode);
                if (singleNode != null)
                    singleNode.InnerText = content;
            }
        }

        /// <summary>保存XML
        ///
        /// </summary>
        public void Save()
        {
            try
            {
                ObjXmlDoc.Save(StrXmlFile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ObjXmlDoc = null;
        }

        #region XML文件操作

        /// <summary> 从XML文件转换为Object对象类型.
        ///
        /// </summary>
        /// <param name="path">XML文件路径</param>
        /// <param name="type">Object对象类型</param>
        /// <returns></returns>
        public static object LoadObjectFromXml(string path, Type type)
        {
            object obj;
            using (StreamReader reader = new StreamReader(path))
            {
                string content = reader.ReadToEnd();
                obj = XmlConvertor.XmlToObject(content, type);
            }
            return obj;
        }

        /// <summary>保存对象到特定格式的XML文件
        ///
        /// </summary>
        /// <param name="path">XML文件路径.</param>
        /// <param name="obj">待保存的对象</param>
        public static void SaveObjectToXml(string path, object obj)
        {
            string xml = XmlConvertor.ObjectToXml(obj, true);
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(xml);
            }
        }

        #endregion XML文件操作
    }
}