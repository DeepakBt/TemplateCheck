<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemplateCheck.aspx.cs" Inherits="TemplateCheck.TemplateCheck" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="txtCpId" runat="server"></asp:TextBox>
        <asp:Button ID="btnLoadTemplate" runat="server" Text="Load Template" OnClick="btnLoadTemplate_Click" />
        <div runat="server" id="divTemplate">

    </div>
    </div>
    </form>
</body>
</html>
