<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ExportManagementSystem.Views.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [ShipmentDetail]"></asp:SqlDataSource>
            <br />
            Welcome to Export Management System<br />
            ****************************************************<br />
            <br />
            <br />
            Shipment ID&nbsp;&nbsp;&nbsp; :<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
            <br />
            Import Date&nbsp;&nbsp;&nbsp; :<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            Import Time&nbsp;&nbsp;&nbsp; :<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            Import Location&nbsp; :<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            <br />
            Export Date&nbsp;&nbsp;&nbsp; :<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            Export Time&nbsp;&nbsp;&nbsp; :<asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <br />
            Export Location&nbsp; :<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;<br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add New Shipment" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Log out" />
            <br />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ShipmentID" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display.">
                <Columns>
                    <asp:BoundField DataField="ShipmentID" HeaderText="ShipmentID" ReadOnly="True" SortExpression="ShipmentID" />
                    <asp:BoundField DataField="ShipmentDate" HeaderText="ImportDate" SortExpression="ShipmentDate" />
                    <asp:BoundField DataField="ShipmentTime" HeaderText="ImportTime" SortExpression="ShipmentTime" />
                    <asp:BoundField DataField="ShipmentLocation" HeaderText="ImportLocation" SortExpression="ShipmentLocation" />
                    <asp:BoundField DataField="DestinationDate" HeaderText="ExportDate" SortExpression="DestinationDate" />
                    <asp:BoundField DataField="DestinationTime" HeaderText="ExportTime" SortExpression="DestinationTime" />
                    <asp:BoundField DataField="DestinationLocation" HeaderText="ExportLocation" SortExpression="DestinationLocation" />
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
