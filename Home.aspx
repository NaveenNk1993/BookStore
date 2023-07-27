<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<%@ Register Src="~/DetailControl.ascx" TagPrefix="uc1" TagName="DetailControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="lblBookId" runat="server" Text="Book Id"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtBookId" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblBookname" runat="server" Text="Book Name"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtBookname" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblAuthorname" runat="server" Text="Author Name"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtAuthorname" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblQuantity" runat="server" Text="Number Of Book"></asp:Label>&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <div class="row">
                <asp:Button ID="btnadd" runat="server" Text="Add" OnClick="btnadd_Click" />
                <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnclear_Click" />
            </div>
            <br />
            <br />

            <uc1:DetailControl runat="server" ID="DetailControl" />

        </div>
    </form>
</body>
</html>
