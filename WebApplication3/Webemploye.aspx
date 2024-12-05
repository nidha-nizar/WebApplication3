<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Webemploye.aspx.cs" Inherits="WebApplication3.Webemploye" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        NAME<asp:TextBox ID="Textname" runat="server"></asp:TextBox>
        <p>
            ADDRESS<asp:TextBox ID="Textadd" runat="server"></asp:TextBox>
        </p>
        AGE<asp:TextBox ID="Textage" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="SUBMIT" />
        </p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="name" HeaderText="NAME" />
                <asp:BoundField DataField="address" HeaderText="ADDRESS" />
                <asp:BoundField DataField="age" HeaderText="AGE" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" CommandArgument='<%# Eval("id") %>' runat="server">EDIT</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click" CommandArgument='<%# Eval("id") %>'  runat ="server">DELETE</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
