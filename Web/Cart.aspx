<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="BookShop.Web.Cart" MasterPageFile="~/MainMaster/MasterPage.Master" %>
<%@ Import Namespace="BookShop.Model" %>

<asp:Content ID="content1" ContentPlaceHolderID="head" runat="server">

<script type="text/javascript">
    $(function () {
        GetTotalMoney();
    });
    //计算购物车总价
    function GetTotalMoney() {
        var totalMoney = 0;
        $('.align_Center:gt(0)').each(function () {
            var Price = $(this).find('.price').text();
            var count = $(this).find('input').val();
            totalMoney = totalMoney + parseFloat(Price) * parseInt(count);
        });
        $('#showTotalMoney').text(fMoney(totalMoney,2));
    }

    function fMoney(s, n) {
        n = n > 0 && n <= 20 ? n : 2;
        s = parseFloat((s + "").replace(/[^\d\.-]/g, "")).toFixed(n) + "";//更改这里n数也可确定要保留的小数位  
        var l = s.split(".")[0].split("").reverse(),
       r = s.split(".")[1];
        t = "";
        for (i = 0; i < l.length; i++) {
            t += l[i] + ((i + 1) % 3 == 0 && (i + 1) != l.length ? "," : "");
        }
        return t.split("").reverse().join("") + "." + r.substring(0, 2);//保留2位小数  如果要改动 把substring 最后一位数改动就可  
    }
</script>
    </asp:Content>

<asp:Content ID="content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <table cellpadding="0" cellspacing="0" width="98%">
            <tr>
                <td colspan="2">
                    <img height="27" src="images/shop-cart-header-blue.gif" width="206" /><img alt="" src="Images/png-0170.png" /><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/myorder.aspx">我的订单</asp:HyperLink>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" width="98%">
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr class="align_Center Thead">
                            <td style="height: 30px" width="7%">图片</td>
                            <td>图书名称</td>
                            <td width="14%">单价</td>
                            <td width="11%">购买数量</td>
                            <td width="7%">删除图书</td>
                        </tr>


                        <%foreach (Cart cartModel in CartList)
                          {%>

                        <!--一行数据的开始 -->
                        <tr class="align_Center">
                            <td style="padding: 5px 0 5px 0;">
                                <img border="0" height="50" src="/images/bookcovers/<%=cartModel.Book.ISBN %>.jpg" width="40" /></td>
                            <td class="align_Left"><%=cartModel.Book.Title %></td>
                            <td><span class="price"><%=cartModel.Book.UnitPrice.ToString("0.00") %></span> </td>
                            <td><a href="#none" onclick="changeBar('-',<%=cartModel.Book.Id%>,<%=cartModel.Id%>)" style="margin-right: 2px;" title="减一">
                                <img border="none" height="9" src="Images/bag_close.gif" style="display: inline" width="9" /></a>
                                <input id="txtCount<%=cartModel.Book.Id%>" maxlength="3" name="txtCount<%=cartModel.Book.Id%>" onblur="changeTextOnBlur(<%=cartModel.Id%>,this);" onfocus="changeTxtOnFocus(this);" onkeydown="if(event.keyCode == 13) event.returnValue = false" size="20" style="width: 30px" type="text" value="<%=cartModel.Count %>" />
                                <a href="#none" onclick="changeBar('+',<%=cartModel.Book.Id%>,<%=cartModel.Id%>)" style="margin-left: 2px;" title="加一">
                                    <img border="none" height="9" src="images/bag_open.gif" style="display: inline" width="9" /></a> </td>
                            <td><a id="btn_del_1000357315" href="#none" onclick="removeProductOnShoppingCart(<%=cartModel.Id%>,this)">删除</a></td>
                        </tr>
                        <!--一行数据的结束 -->
                        <%} %>

                        <tr>
                            <td class="align_Right Tfoot" colspan="5" style="height: 30px">&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">&nbsp;&nbsp;&nbsp; 商品金额总计：<span id="showTotalMoney" style="font-size: 25px; color: red; font-weight: bold">0</span>元</td>
                <td>&nbsp; <a href="booklist.aspx">
                    <img alt="" border="0" height="36" src="Images/gobuy.jpg" width="103" />
                </a><a href="OrderConfirm.aspx">
                    <img border="0" src="images/balance.gif" /></a> </td>
            </tr>
        </table>
    </div>

</asp:Content>
