<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Nikita.Assist.IconLibarary.Web.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
  <body>
        <form id="form1" runat="server">
            <fieldset style="width: 285px">
                <legend>Static Icon</legend>
                <table border="1" cellpadding="2" cellspacing="0">
                    <tr>
                        <td>By</td>
                        <td>Icon 16x16</td>
                        <td>Icon 32x32</td>
                    </tr>
                    <tr>
                        <td>Css Class</td>
                        <td><asp:Label ID="uiCssClass16" runat="server" Style="display: block; height: 16px; width: 16px;"></asp:Label></td>
                        <td><asp:Label ID="uiCssClass32" runat="server" Style="display: block; height: 32px; width: 32px;"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Url</td>
                        <td><asp:Image ID="uiUrl16" runat="server"/></td>
                        <td><asp:Image ID="uiUrl32" runat="server"/></td>
                    </tr>
                    <tr>
                        <td>Web Resource Url</td>
                        <td><asp:Image ID="uiWebResourceUrl16" runat="server"/></td>
                        <td><asp:Image ID="uiWebResourceUrl32" runat="server"/></td>
                    </tr>
                </table>
            </fieldset>
            <fieldset style="width: 285px">
                <legend>Dynamic Icon</legend>
                Choose Icon: <asp:DropDownList ID="uiIcon" runat="server" AutoPostBack="True"/>
                <br/><br/>
                <table border="1" cellpadding="2" cellspacing="0">
                    <tr>
                        <td>By</td>
                        <td>Icon 16x16</td>
                        <td>Icon 32x32</td>
                    </tr>
                    <tr>
                        <td>Css Class</td>
                        <td><asp:Label ID="uiDynamicCssClass16" runat="server" Style="display: block; height: 16px; width: 16px;"></asp:Label></td>
                        <td><asp:Label ID="uiDynamicCssClass32" runat="server" Style="display: block; height: 32px; width: 32px;"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Url</td>
                        <td><asp:Image ID="uiDynamicUrl16" runat="server"/></td>
                        <td><asp:Image ID="uiDynamicUrl32" runat="server"/></td>
                    </tr>
                    <tr>
                        <td>Web Resource Url</td>
                        <td><asp:Image ID="uiDynamicWebResourceUrl16" runat="server"/></td>
                        <td><asp:Image ID="uiDynamicWebResourceUrl32" runat="server"/></td>
                    </tr>
                </table>
            </fieldset>
        </form>
    </body>
</html>
