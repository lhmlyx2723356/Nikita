using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Nikita.Core.XML
{
    public class LinqToXmlHelper
    {
        /// <summary>找到一个节点，插到该节点后面
        ///
        /// </summary>
        /// <param name="path">xml地址</param>
        /// <param name="category">要插入节点的前一个几点类别</param>
        /// <param name="categoryName">要插入节点的前一个几点类别名称</param>
        /// <param name="addCa">要插入节点的类别</param>
        /// <param name="addValue">要插入节点的类别名称</param>
        public static void AddAfterSelf(string path, string category, string categoryName, string addCa, string addValue)
        {
            XDocument root = XDocument.Load(path);
            var xElement = root.Element(category);
            if (xElement != null)
            {
                XElement xele = xElement.Element(categoryName);
                if (xele != null) xele.AddAfterSelf(new XElement(addCa, addValue));
            }
            root.Save(path);
        }

        /// <summary>找到一个节点，插到该节点前面
        ///
        /// </summary>
        /// <param name="path">xml地址</param>
        /// <param name="category">要插入节点的前一个几点类别</param>
        /// <param name="categoryName">要插入节点的前一个几点类别名称</param>
        /// <param name="addCa">要插入节点的类别</param>
        /// <param name="addValue">要插入节点的类别名称</param>
        public static void AddBeforeSelf(string path, string category, string categoryName, string addCa, string addValue)
        {
            XDocument root = XDocument.Load(path);
            var xElement = root.Element(category);
            if (xElement != null)
            {
                XElement xele = xElement.Element(categoryName);
                if (xele != null) xele.AddBeforeSelf(new XElement(addCa, addValue));
            }
            root.Save(path);
        }

        /// <summary>找到一个节点来删除
        ///
        /// </summary>
        /// <param name="path"></param>
        /// <param name="category"></param>
        /// <param name="categoryName"></param>
        public static void DeleteOneNodeAll(string path, string category, string categoryName)
        {
            XDocument root = XDocument.Load(path);
            var xElement = root.Element(category);
            if (xElement != null)
            {
                XElement xele = xElement.Element(categoryName);
                if (xele != null) xele.RemoveAll();
            }
        }

        /// <summary>获取路径下的xml文件夹的节点value值
        ///
        /// </summary>
        /// <param name="path"></param>
        /// <param name="category"></param>
        /// <param name="categoryName"></param>
        ///// <?xml version="1.0" encoding="utf-8" ?>
        ///// <appsetting>
        ///// <!-- 当前系统名称 -->
        ///// <SystemName value="友联金达软件开发有限公司"> </SystemName>
        ///// </appsetting>
        public static string GetXmlNodeValue(string path, string category, string categoryName)
        {
            string res = string.Empty;
            XDocument root = XDocument.Load(path);
            var xElement = root.Element(category);
            if (xElement != null)
            {
                XElement xele = xElement.Element(categoryName);
                //foreach (var item in root.Elements(Category))
                //{
                //    res =  (item.Element(CategoryName).Value).ToString();
                //}
                if (xele != null) return xele.Value;
            }
            return res;
        }

        /// <summary>把xml文件下的某一个节点category 的值改掉成新的CategoryName
        ///
        /// </summary>
        /// <param name="path"></param>
        /// <param name="category"></param>
        /// <param name="categoryName"></param>
        public static void UpdateNode(string path, string category, string categoryName)
        {
            XDocument root = XDocument.Load(path);
            var xElement = root.Element(category);
            if (xElement != null)
            {
                XElement xele = xElement.Element(categoryName);
                if (xele != null) xele.SetElementValue(category, categoryName);
            }
            root.Save(path);
        }
    }
}