<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="HelloWebClient2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 210px;
        }
    </style>
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
                    <b>Search car id or regnumber</b>
                </td>
                <td>
                    <asp:TextBox ID="txtGetCar" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Brand</b>
                </td>
                <td>
                    <asp:TextBox ID="lblBrand" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Model</b>
                </td>
                <td>
                    <asp:TextBox ID="lblModel" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Year</b>
                </td>
                <td>
                    <asp:TextBox ID="lblYear" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Registration number</b>
                </td>
                <td>
                    <asp:TextBox ID="lblReg" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnGetCarById" runat="server" Text="Get car by ID" OnClick="btnGetCarById_Click" />
                </td>
                <td>
                    <asp:Button ID="btnGetCarByReg" runat="server" Text="Get car by reg" OnClick="btnGetCarByReg_Click" />
                </td>
                <td>
                    <asp:Button ID="btnDeleteCar" runat="server" Text="Delete Car" OnClick="btnDeleteCar_Click" />
                </td>
                <td>
                    <asp:Button ID="btnSaveCar" runat="server" Text="Save Car" OnClick="btnSaveCar_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
        <table style="font-family: Arial; border: 1px solid black;">
            <tr>
                <td colspan="2">
                    <strong>Add new customer</strong>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Firstname</b>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtCustomFirstName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Lastname</b>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtCustomLastName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Phone number</b>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Email</b>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnGetCustomer" runat="server" Text="Get Customer by lastname" OnClick="btnGetCustomer_Click" Width="218px" />
                </td>
                <td class="auto-style1">
                    <asp:Button ID="btnSaveCustomer" runat="server" Text="Save Customer" OnClick="btnSaveCustomer_Click" />
                </td>
                <td>
                    <asp:Button ID="btnDeleteCustomer" runat="server" Text="Delete Customer" OnClick="btnDeleteCustomer_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblCustomer" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
        <table style="font-family: Arial; border: 1px solid black;">
            <tr>
                <td colspan="2">
                    <strong>Search for reservations</strong>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Brand</b>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtResBrand" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Model</b>
                </td>
                <td class="auto-style1">
                    <asp:Label ID="lblResModel" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Regnumber</b>
                </td>
                <td class="auto-style1">
                    <asp:Label ID="lblResReg" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Start Date</b>
                </td>
                <td class="auto-style1">
                    <asp:Label ID="lblStartDate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <b>End date</b>
                </td>
                <td class="auto-style1">
                    <asp:Label ID="lblEndDate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnGetReservationByBrand" runat="server" Text="Get reservation" OnClick="btnGetReservationByBrand_Click" />
                </td>
            </tr>

            <tr>
                <td colspan="2">
                    <asp:Label ID="lblResMessage" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td colspan="2">
                    <b>Get Reservations By Date</b>
                    <asp:Label ID="lblLabelReservations" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <b>From</b>
                    <asp:Label ID="lblDateFrom" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Calendar ID="calStartdate" runat="server"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td>
                    <b>To</b>
                    <asp:Label ID="lblDateTo" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Calendar ID="calEnddate" runat="server"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Car: </b>
                </td>
                <td>
                    <asp:Label ID="lblCarBrand" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Model: </b>
                </td>
                <td>
                    <asp:Label ID="lblCarModel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Registrationnumber: </b>
                </td>
                <td>
                    <asp:Label ID="lblCarReg" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Yearmodel: </b>
                </td>
                <td>
                    <asp:Label ID="lblCarYear" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Date: </b>
                </td>
                <td>
                    <asp:Label ID="lblBookingStart" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnGetBookedCars" runat="server" OnClick="btnGetBookedCars_Click" Text="Get booked cars" />
                </td>
                <td>
                    <asp:Button ID="btnGetAvailableCars" runat="server" OnClick="btnGetAvailableCars_Click" Text="Get available cars" />
                </td>
                <td>
                    <asp:Button ID="btnClearSearch" runat="server" Text="Clear Search" OnClick="btnClearSearch_Click" />
                </td>
                 <td>
                    <asp:Button ID="btnMakeReservation" runat="server" Text="Make reservation" Visible="false" OnClick="btnMakeReservation_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblReservationResult" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="txtAvailableRegCar" runat="server" Visible="false" Text="Enter registration number of the car"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAvailableModel" runat="server" Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblAvailableBrand" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server" Text="Enter your firstname" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server" Text="Enter your lastname" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtPhonenumber" runat="server" Text="Enter you phone" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtEmailAddress" runat="server" Text="Enter your email" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtBookStartDate" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtBookuntil" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSaveBook" runat="server" Text="Save reservation" Visible="false" OnClick="btnSaveBook_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
