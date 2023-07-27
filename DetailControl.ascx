<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DetailControl.ascx.cs" Inherits="DetailControl" %>


<%--<meta http-equiv="refresh" content="10" />--%><%--use this auto refresh--%>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
 <div>
            <asp:TextBox hidden="true" ID="txtBookId" runat="server"></asp:TextBox>
            <asp:TextBox hidden="true" ID="txtBookname" runat="server"></asp:TextBox>
            <asp:TextBox hidden="true" ID="txtAuthorname" runat="server"></asp:TextBox>
            <asp:TextBox hidden="true" ID="txtQuantity" runat="server"></asp:TextBox>

        </div>
<asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
<%--<asp:Timer ID="Timer1" runat="server" Interval="5000000" OnTick="Timer1_Tick"></asp:Timer>--%><%--use this auto refresh--%>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="BookId" HeaderText="Book Id" />
        <asp:BoundField DataField="BookName" HeaderText="Book Name" />
        <asp:BoundField DataField="AuthorName" HeaderText="Author Name" />
        <asp:BoundField DataField="Quantity" HeaderText="Number Of Books" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnkselect" runat="server" CommandArgument='<%# Eval("BookId") %>' OnClick="lnkuserselect_Click">Edit</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("BookId") %>' OnClick="btndelete_Click">Delete</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>

</asp:GridView>
