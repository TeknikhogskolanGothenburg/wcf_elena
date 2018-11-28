<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="EmployeeWebClient.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table style="font-family: Arial; border: 1px solid black;">
            <tr>
                <td colspan="2">
                    <strong>Get Car</strong>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Type Car Id or Registration nr</b>
                </td>
                <td>
                    <asp:TextBox ID="txtGetCar" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnGetCarById" runat="server" Text="Get Car By Id" OnClick="btnGetCarById_Click" />
                </td>
                <td>
                     <asp:Button ID="btnGetCarByReg" runat="server" Text="Get Car By Reg" OnClick="btnGetCarByReg_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <strong>Add new costumer</strong>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Firstname</b>
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Lastname</b>
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>
                    <b>Phone number</b>
                </td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>
                    <b>Email</b>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSaveCostumer" runat="server" Text="Save Costumer" OnClick="btnSaveCostumer_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

