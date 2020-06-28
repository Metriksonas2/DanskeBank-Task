<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="DanskeBank_Task.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button"/>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" MaxLength="3"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button"/>
        <br />
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" accept=".json" ErrorMessage="Only JSON files allowed"/>
        <br />
        <br />
        <asp:Label ID="successMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
        <asp:Label ID="errorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="gvArrays" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="5">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID"/>
                <asp:BoundField DataField="Array" HeaderText="Array"/>
                <asp:BoundField DataField="Reachable" HeaderText="Is reachable"/>
                <asp:BoundField DataField="Path" HeaderText="Path"/>
            </Columns>
        </asp:GridView>
    </div>
</form>
</body>
</html>
