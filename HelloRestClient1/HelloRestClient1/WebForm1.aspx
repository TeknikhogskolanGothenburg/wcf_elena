<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="HelloRestClient1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 346px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <table style="font-family: Arial; border: 1px solid black;">
             <tr>
                 <td colspan="2" class="auto-style1">
                     <strong>Get All Cars</strong>
                 </td>
             </tr>
             <tr>
                 <td colspan="2" class="auto-style1">
                     <asp:ListBox ID="lstCars" runat="server" Width="289px"></asp:ListBox>
                 </td>
             </tr>
             <tr>
                 <td colspan="2" class="auto-style1">
                     <asp:Button ID="btnGetAllCars" runat="server" Text="Get cars" OnClick="btnGetAllCars_Click" Width="285px" />
                 </td>
             </tr>
             <tr>
                 <td>
                     <asp:Label ID="lblAllCars" runat="server"></asp:Label>
                 </td>
             </tr>
           </table>
         <table style="font-family: Arial; border: 1px solid black;">
             <tr>
                 <td colspan="2">
                     <strong>Car example</strong>
                 </td>
             </tr>
            <tr>
                <td>
                    <b>Car id</b>
                </td>
                <td>
                    <asp:TextBox ID="txtCarId" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                 <td>
                     <b>Brand</b>

                 </td>
                 <td>
                     <asp:TextBox ID="txtBrand" runat="server"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>
                     <b>Model</b>
                 </td>
                 <td>
                     <asp:TextBox ID="txtModel" runat="server"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>
                     <b>Year</b>
                 </td>
                 <td>
                     <asp:TextBox ID="txtYear" runat="server"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>
                     <b>Registrationnumber</b>
                 </td>
                 <td>
                     <asp:TextBox ID="txtReg" runat="server"></asp:TextBox>
                 </td>
             </tr>
            
             <tr>
                 <td>
                     <asp:Label ID="lblResult" runat="server"></asp:Label>
                 </td>
             </tr>
             <tr>
                 <td>
                     <asp:Button ID="btnAddReservation" runat="server" Text="Delete car" OnClick="btnAddReservation_Click" Width="232px" />
                 </td>
                 <td>
                     <asp:Button ID="btnGetReservation" runat="server" Text="Get Car By id" OnClick="btnGetReservation_Click" />
                 </td>
             </tr>
          </table>
        <table style="font-family: Arial; border: 1px solid black;">
            <tr>
                <td colspan="2">
                    <strong>Customer</strong>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
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
                    <asp:TextBox ID="txtLastname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Phonenumber</b>
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
                    <asp:Button ID="btnGetCustomer" runat="server" Text="Get Customer" OnClick="btnGetCustomer_Click" />
                </td>
                <td>
                    <asp:Button ID="btnUpdateCustomer" runat="server" Text="Update Customer" OnClick="btnUpdateCustomer_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCustomerResult" runat="server"></asp:Label>
                </td>
            </tr>
            </table>
    </form>
</body>
</html>
