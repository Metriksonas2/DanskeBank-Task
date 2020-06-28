<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="DanskeBank_Task.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Add: Input array (ex.: 1, 5, 7)" ForeColor="#666666"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Remove: Input array ID (ex.: 5)" ForeColor="#666666"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add"/>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Remove"/>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Upload .json file with multiple arrays" ForeColor="#666666"></asp:Label>
        <br />
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" accept=".json" ErrorMessage="Only JSON files allowed"/>
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Add multiple arrays"/>
        <br />
        <br />
        <asp:Label ID="successMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
        <asp:Label ID="errorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="List of all arrays in SQL Database:" ForeColor="#666666"></asp:Label>
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
