<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Src="Controls/ucSearch_MainSearch.ascx" TagName="ucSearch_MainSearch" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="text-align: center;padding-bottom:20px; padding-top:100px">
        <asp:Image runat="server" ID="imgLogo" AlternateText="GoProGo Logo" 
            ImageUrl="~/App_Themes/Default/Images/Logo/GoProGoOrange.png" />
    </div>
    <uc1:ucSearch_MainSearch ID="ucSearch_MainSearch1" runat="server" />
</asp:Content>
