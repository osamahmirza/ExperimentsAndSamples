<%@ Page Title="" Language="C#" MasterPageFile="~/Members/Members.master" AutoEventWireup="true" CodeFile="RegistrationInfo.aspx.cs" Inherits="Members_RegistrationInfo" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<%@ Register Src="../UserControls/ucPersonInfo.ascx" TagName="PersonInfo" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/ucUserInfo.ascx" TagName="UserInfo" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
        <tr>
            <td style="padding-right: 5px">
                <div class="regular">
                    <h2>
                        Personal Information</h2>
                    <hr />
                </div>
            </td>
            <td style="padding-right: 5px">
                <div class="regular">
                    <h2>
                        User Information</h2>
                    <hr />
                </div>
            </td>
            <td style="padding-right: 5px">
                <div class="regular">
                    <h2>
                        Information</h2>
                    <hr />
                </div>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top">
                <uc1:PersonInfo ID="PersonInfo1" runat="server" IsEdit="true" />
            </td>
            <td style="vertical-align: top">
                <uc2:UserInfo ID="UserInfo1" runat="server" IsEdit="true"/>
            </td>
            <td rowspan="4" class="regular" style="vertical-align: top; padding: 2px">
                <p>
                    1 - All fields marked with '*' are Required</p>
                <p>
                    2 - We will not share your email address with any third parties. We will be using
                    your email address to contact you and to tell you about new offers, we may send
                    you exclusive news about our offerings.</p>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="padding-top:5px">
                <asp:Button ID="btnSave" runat="server" Text="   Save   " 
                    onclick="btnSave_Click"/>
            </td>
        </tr>
    </table>
</asp:Content>

