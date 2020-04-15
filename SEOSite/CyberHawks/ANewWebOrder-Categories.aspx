<%@ Page Title="" Language="C#" MasterPageFile="~/Directory-SubHead.master" AutoEventWireup="true" CodeFile="ANewWebOrder-Categories.aspx.cs" Inherits="ANewWebOrder_Categories" %>

<%@ Register Src="~/UserControls/ucCategories.ascx" TagPrefix="uc1" TagName="ucCategories" %>


<%@ Register src="~/UserControls/ucRecentlyAdded.ascx" tagname="ucRecentlyAdded" tagprefix="uc2" %>
<%@ Register src="~/UserControls/ucRecentlyUpdated.ascx" tagname="ucRecentlyUpdated" tagprefix="uc3" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="contents">
        <div class="clear">
        </div>
        <div id="addiv">
            <h2>Recently Added</h2>
            <p>
                <uc2:ucRecentlyAdded ID="ucRecentlyAdded1" runat="server" />
            </p>
            <h2>Recently Updated</h2>
            <p>
                <uc3:ucRecentlyUpdated ID="ucRecentlyUpdated1" runat="server" />
            </p>
            <h2>External Ads</h2>
            <p>
                balabla bla
            </p>
        </div>
        <div id="catcontent">
            <h2>Website Categories</h2>
            <p>
                <uc1:ucCategories runat="server" ID="ucCategories" />
            </p>
        </div>
        <div class="clear">
        </div>
        &nbsp;
    </div>
</asp:Content>

