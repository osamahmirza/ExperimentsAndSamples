<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucPersonInfo.ascx.cs" Inherits="RegistrationStep1" %>
<div id="contents">
    <table>
        <tr>
            <td>
                <div class="label">
                    First Name*<asp:RequiredFieldValidator ID="rfvFirstName" 
                        runat="server" ControlToValidate="tbFirstName" 
                        ErrorMessage="First Name is required." SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:TextBox ID="tbFirstName" runat="server" Width="225px" MaxLength="128"></asp:TextBox></div>
            </td>
            <td>
                &nbsp;</td>
            <td>
               <div class="label">
                    Street Address*<asp:RequiredFieldValidator ID="rfvUserName0" 
                        runat="server" ControlToValidate="tbStreetAddress" 
                        ErrorMessage="Street Address is required." SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:TextBox ID="tbStreetAddress" runat="server" Width="225px" MaxLength="256"></asp:TextBox>
                </div></td>
        </tr>
        <tr>
            <td>
                <div class="label">
                    Middle Initials
                </div>
                <div>
                    <asp:TextBox ID="tbMiddleInitial" runat="server" Width="225px" MaxLength="1"></asp:TextBox>
                </div>
            </td>
            <td>
                &nbsp;</td>
            <td>
                 <div class="label">
                    Apt / Building / FI / Rm
                </div>
                <div>
                    <asp:TextBox ID="tbAppartment" runat="server" Width="225px" MaxLength="128"></asp:TextBox>
                </div></td>
        </tr>
        <tr>
            <td>
                <div class="label">
                    Last Name*<asp:RequiredFieldValidator ID="rfvLastName" 
                        runat="server" ControlToValidate="tbLastName" 
                        ErrorMessage="Last Name is required." SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:TextBox ID="tbLastName" runat="server" Width="225px" MaxLength="128"></asp:TextBox>
                </div>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <div class="label">
                    Country*<asp:RequiredFieldValidator ID="rfvCountry" 
                        runat="server" ControlToValidate="ddlCountry" 
                        ErrorMessage="Country is required." SetFocusOnError="True" 
                        InitialValue="-1">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:DropDownList ID="ddlCountry" runat="server" Width="224px">
                    </asp:DropDownList>
                </div></td>
        </tr>
        <tr>
            <td>
                <div class="label">
                    Primary Phone*<asp:RequiredFieldValidator ID="rfvPhone" 
                        runat="server" ControlToValidate="tbPhone" 
                        ErrorMessage="Primary Phone is required." SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:TextBox ID="tbPhone" runat="server" Width="225px" MaxLength="13"></asp:TextBox>
                </div>
            </td>
            <td>
                &nbsp;</td>
            <td>
                 <div class="label">
                    State/Province/Region*<asp:RequiredFieldValidator ID="rfvRegion" 
                        runat="server" ControlToValidate="tbRegion" 
                        ErrorMessage="Region is required." SetFocusOnError="True" InitialValue="-1">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:TextBox ID="tbRegion" runat="server" Width="225px" MaxLength="64"></asp:TextBox>
                </div></td>
        </tr>
        <tr>
            <td>
                <div class="label">
                    Secondry Phone
                </div>
                <div>
                    <asp:TextBox ID="tbPhone2" runat="server" Width="225px" MaxLength="13"></asp:TextBox>
                </div>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <div class="label">
                    City*<asp:RequiredFieldValidator ID="rfvCity" 
                        runat="server" ControlToValidate="tbCity" 
                        ErrorMessage="City is required." SetFocusOnError="True" InitialValue="-1">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:TextBox ID="tbCity" runat="server" Width="225px" MaxLength="64"></asp:TextBox>
                </div></td>
        </tr>
        <tr>
            <td>
                <div class="label">
                    Fax
                </div>
                <div>
                    <asp:TextBox ID="tbFax" runat="server" Width="225px" MaxLength="13"></asp:TextBox>
                </div>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <div class="label">
                    Zip/Postal Code*<asp:RequiredFieldValidator ID="rfvZip" 
                        runat="server" ControlToValidate="tbZip" 
                        ErrorMessage="Postal Code is required." SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:TextBox ID="tbZip" runat="server" Width="112px" MaxLength="10"></asp:TextBox>
                </div></td>
        </tr>
    </table>
</div>
