using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nikita.Core.Literacy;
using Nikita.Core.WinForm;

namespace Nikita.Base.IDAL
{
    /// <summary>实体操作类 
    /// 通过遍历容器控件(tabpage,groupbox等)上的设置了Tag=实体属性名称的子控件，通过Tag值与实体属性字段之间的关系，自动新增实体，修改实体，绑定实体信息到控件上
    /// </summary>
   public class EntityOperateManager
   {
       public static void BindAll<T>(Control controlContainer, T objValue, bool blnAll = true, string[] strNotBindCtrlNames = null)
       {
           foreach (Control control in controlContainer.Controls)
           {
               if (control.Tag == null || control.Tag.ToString()==string.Empty)
               {
                   continue;
               }
               if (blnAll)
               {
                   if (strNotBindCtrlNames != null && strNotBindCtrlNames.Contains(control.Name))
                   {
                       continue;
                   }
               }
               object objPropertyValue = PropertyManager.BsePropertyManager.GetProperty(objValue, control.Tag.ToString());
               ControlManager.BindOne(control, objPropertyValue);
           }
       }

       public static T AddEntity<T>(Control controlContainer,
           bool blnAll = true,
           string[] strNotBindCtrlNames = null,
           bool ignoreCase = true)
       {
           var literacy = ignoreCase ? TypesHelper.GetTypeInfo<T>().IgnoreCaseLiteracy : TypesHelper.GetTypeInfo<T>().Literacy;
           T obj = (T)literacy.NewObject();
           foreach (Control control in controlContainer.Controls)
           {
               if (control.Tag == null ||control.Tag.ToString()==string.Empty || control is System.Windows.Forms.Label)
               {
                   continue;
               }
               if (blnAll)
               {
                   if (strNotBindCtrlNames != null && strNotBindCtrlNames.Contains(control.Name))
                   {
                       continue;
                   }
               }
               literacy.Property[control.Tag.ToString()].SetValue(obj, ControlManager.GetOneValue(control));
           }
           return obj;
       }


       public static T EditEntity<T>(Control controlContainer,
           T obj,
          bool blnAll = true,
          string[] strNotBindCtrlNames = null,
          bool ignoreCase = true)
       {
           var literacy = PropertyManager.BsePropertyManager.GetLiteracy(obj);
           foreach (Control control in controlContainer.Controls)
           {
               if (control.Tag == null || control.Tag.ToString()==string.Empty)
               {
                   continue;
               }
               if (blnAll)
               {
                   if (strNotBindCtrlNames != null && strNotBindCtrlNames.Contains(control.Name))
                   {
                       continue;
                   }
               }
               literacy.Property[control.Tag.ToString()].SetValue(obj, ControlManager.GetOneValue(control));
           }
           return obj;
       }
    }
}
