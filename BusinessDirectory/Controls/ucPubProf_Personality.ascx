<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucPubProf_Personality.ascx.cs"
    Inherits="Controls_ucPubProf_Personality" %>
<div>
    <asp:Label ID="lblMyPersonality" runat="server" Text=""></asp:Label></div>
<div>
    <table>
        <tr>
            <td>
                <asp:Label ID="lblGenderCap" runat="server" Text="Gender:"></asp:Label><asp:Label ID="lblGender" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblRelationshipCap" runat="server" Text="Relationship:"></asp:Label><asp:Label ID="lblRelationship" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblGrewUpCap" runat="server" Text="Grewup in:"></asp:Label><asp:Label ID="lblGrewup" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblAgeCap" runat="server" Text="Age:"></asp:Label><asp:Label ID="lblAge" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMissionStatementCap" runat="server" Text="Mission Statement:"></asp:Label><asp:Label ID="lblMissionStatement" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblFavQuoteCap" runat="server" Text="Favourite Quote:"></asp:Label><asp:Label ID="lblFavQoute" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblHobbiesCap" runat="server" Text="Hobbies:"></asp:Label><asp:Label ID="lblHobbies" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblSportsCap" runat="server" Text="Sports:"></asp:Label><asp:Label ID="lblSports" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblFavBooksCap" runat="server" Text="Favourite Books:"></asp:Label><asp:Label ID="lblFavBooks" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblFavMovieCap" runat="server" Text="Favourite Movies:"></asp:Label><asp:Label ID="lblFavMovie" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblFavTvShowCap" runat="server" Text="Favourite TV Shows:"></asp:Label><asp:Label ID="lblFavTvShow" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</div>
