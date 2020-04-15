<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucPayment.ascx.cs" Inherits="UserControls_ucPayment" %>
<asp:Panel runat="server" ID="pnlHiddenVariables">

<%--
<input type="hidden" name="cmd" value="_xclick">
<input type="hidden" name="business" value="7ZNZUNB2553S8">
<input type="hidden" name="lc" value="CA">
<input type="hidden" name="item_name" value="1 Year">
<input type="hidden" name="item_number" value="1">
<input type="hidden" name="amount" value="187.80">
<input type="hidden" name="currency_code" value="CAD">
<input type="hidden" name="button_subtype" value="services">
<input type="hidden" name="tax_rate" value="0.000">
<input type="hidden" name="shipping" value="0.00">
<input type="hidden" name="bn" value="PP-BuyNowBF:btn_buynowCC_LG.gif:NonHosted">--%>



</asp:Panel>
<div id="contents">
    <table>
        <tr>
            <td>
                <div class="label">
                    Payment options:
                </div>
                <div>
                </div>
            </td>
            <td>
                <div>
                    <asp:DropDownList ID="ddlPaymentOption" runat="server" Width="413px" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlPaymentOption_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                    You will pay
                    <asp:Label ID="lblTotal" runat="server" />
                    &nbsp;in total for
                    <asp:Label ID="lblMonths" runat="server" />
                    &nbsp;months.<br />
                    Your campaign
                    <asp:Label ID="lblCampaign" runat="server" />
                    will expire on
                    <asp:Label ID="lblEstimatedExpirationDate" runat="server" />
                    <br />
                    <asp:ImageButton ID="imgbtnBuyNow" runat="server" name="submit" ImageUrl="https://www.paypalobjects.com/WEBSCR-640-20110306-1/en_US/i/btn/btn_buynowCC_LG.gif" AlternateText="PayPal - The safer, easier way to pay online!" onclick="imgbtnBuyNow_Click" />
                    <asp:Button ID="btnApplyFreeOffer" runat="server" Text="Apply" Visible="false" 
                        onclick="btnApplyFreeOffer_Click"/>
                </div>
            </td>
        </tr>
    </table>
</div>

