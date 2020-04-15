<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProf_Picture.ascx.cs" Inherits="ucProf_Picture" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<table>
    <tr>
        <td>
            Profile Picture
        </td>
        <td>
            <asp:FileUpload ID="FileUpload1" runat="server" maxlength="716800"/>
            <asp:Button ID="btnUpload" runat="server" Text="Upload" onclick="btnUpload_Click" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            Max File size 1 MB, .jpg or gif only</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Image ID="Image1" runat="server" Visible="False" />
        </td>
    </tr>
</table>

