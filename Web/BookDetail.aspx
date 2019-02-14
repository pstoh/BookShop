<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookDetail.aspx.cs" Inherits="BookShop.Web.BookDetail" MasterPageFile="~/MainMaster/MasterPage.Master" %>

<asp:Content ID="content1" ContentPlaceHolderID="head" runat="server">
                    <style type="text/css">

.new_F4 {
	FONT-SIZE: 14px ;color:#404042; font-weight: bold;
}
</style>
      
                    <style type="text/css">

.samesortgoods_L17 {
	LINE-HEIGHT: 230%
}
.samesortgoods_F3 {
	FONT-SIZE: 12px ;color:#A8A7A7; 
}
A.samesortgoods_A1:link {
	FONT-SIZE: 12px; COLOR: #554F4F; TEXT-DECORATION: none
}
A.samesortgoods_A1:active {
	FONT-SIZE: 12px; COLOR: #554F4F; TEXT-DECORATION: underline
}
A.samesortgoods_A1:visited {
	FONT-SIZE: 12px; COLOR: #554F4F; TEXT-DECORATION: none
}
A.samesortgoods_A1:hover {
	FONT-SIZE: 12px; COLOR: #554F4F; TEXT-DECORATION: underline
}
</style>

        <style type="text/css">

.samesortgoods_L17 {
	LINE-HEIGHT: 230%
}
.samesortgoods_F3 {
	FONT-SIZE: 12px ;color:#A8A7A7; 
}
.new_F4 {
	FONT-SIZE: 14px ;color:#404042; font-weight: bold;
}

/*修改编辑器的样式*/
        #cke_txtComment {
        width:650px;
        }

        </style>

        <link href="/css/index.css" rel="stylesheet" type="text/css">
    <link href="/Template/css.css" rel="stylesheet" />
    <link href="/Template/css1.css" rel="stylesheet" />
    <link href="/Css/themes/ui-lightness/jquery.ui.all.css" rel="stylesheet" />
                    <script src="/Scripts/jquery-1.8.2.js"></script>
    <script src="/Scripts/jquery-ui-1.8.2.custom.min.js"></script>
    <script src="/Scripts/ckeditor/ckeditor.js"></script>
    <script  type="text/javascript">
        $(function () {
            //家在评论内容
            loadComment();
            loadUBBCode();
            //判断用户是否登陆
            checkUserState();
            $("#btnAddComment").click(function () {
                addComment();//添加评论
            });
            //跳转登录页面
            $('#locationLoginUrl').click(function(){
                showLoginUrl();
            });

        });

        //跳转登录页面
        function showLoginUrl(){


            var url=location.href;
            location.href='/account/Login.aspx?returnurl='+url;
        }

        //添加评论
        function addComment(){
            var oEditer=CKEDITOR.instances.txtComment;
            var msg = oEditor.getData();
            if (msg==''){
                alert('评论内容不能为空!');
                return;
            }
            $.post('/ashx/CheckUserLogin.ashx',{},function(data){
                var serverData=data.split(':');
                if (serverData[0]!='OK'){
                    return;
                }

                $.post('/ashx/ProcessComment.ashx',{'msg':msg,'bookId':<%=Book.Id%>,'action':'add'},function(data)){
                var serverData=data.split(':');
                if (serverData[0]=='OK'){
                    $("#commentList li").remove();
                    //$("#txtComment").val("");
                    oEditor.setData("");
                    loadComment();
                }else {
                    alert(serverData[1]);
                }
}
            });


        }

        //检查用户登录状态
        function checkUserState(){
            $.post('/ashx/CheckUserLogin.ashx',{},function(data){
                var serverData=data.split(':');
                if (serverData[0]=='OK'){
                    $('#showUserName').val(serverData[1]);
                }else {
                    $('#showLoginInfo').css('display','block');
                }
            });
        }
        //家在评论内容
        function loadComment() {
            $.post('/ashx/ProcessComment.ashx', { 'bookId': <%=Book.Id %>, 'action': 'load' }, function (data) {
                var serverData = $.parseJSON(data);
                for (var i = 0; i < serverData.length; i++) {
                    $('<li style="float:none;text-align:left;font-size:14px">' + serverData[i].CreateDateTime + ':' + serverData[i].Msg + '</li>').appendTo('#commentList');
                }
            });
        }
        //加载富文本编辑器
        function loadUBBCode() {
            CKEDITOR.replace('txtComment',
	{
	    extraPlugins: 'bbcode',
	    removePlugins: 'bidi,button,dialogadvtab,div,filebrowser,flash,format,forms,horizontalrule,iframe,indent,justify,liststyle,pagebreak,showborders,stylescombo,table,tabletools,templates',
	    toolbar:
		[
			['Source', '-', 'Save', 'NewPage', '-', 'Undo', 'Redo'],
			['Find', 'Replace', '-', 'SelectAll', 'RemoveFormat'],
			['Link', 'Unlink', 'Image'],
			'/',
			['FontSize', 'Bold', 'Italic', 'Underline'],
			['NumberedList', 'BulletedList', '-', 'Blockquote'],
			['TextColor', '-', 'Smiley', 'SpecialChar', '-', 'Maximize']
		],
	    smiley_images:
		[
			'regular_smile.gif', 'sad_smile.gif', 'wink_smile.gif', 'teeth_smile.gif', 'tounge_smile.gif',
			'embaressed_smile.gif', 'omg_smile.gif', 'whatchutalkingabout_smile.gif', 'angel_smile.gif', 'shades_smile.gif',
			'cry_smile.gif', 'kiss.gif'
		],
	    smiley_descriptions:
		[
			'smiley', 'sad', 'wink', 'laugh', 'cheeky', 'blush', 'surprise',
			'indecision', 'angel', 'cool', 'crying', 'kiss'
		]
	});
        }
    </script>
    

    


</asp:Content>

<asp:Content ID="content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <center>

<div id="main_box">
    <table align="center" border="0" cellpadding="0" cellspacing="0" width="800">
        <tr>
            
    
	<!-- 中间占位的空单元格 -->
            
    
	<!-- 中间占位的空单元格 -->
            <td align="center" valign="top" width="924">
     <!-- 装右侧内容的单元格 -->

                <style type="text/css">

.new_F4 {
	FONT-SIZE: 14px ;color:#404042; font-weight: bold;
}
</style>
                <table bgcolor="#F3F3F5" border="0" cellpadding="5" cellspacing="0" height="41" width="100%">
                    <tr>
                        <td valign="middle" width="10">&nbsp;</td>
                        <td valign="middle">
                            <h1 class="new_F4" style="margin-bottom:0px;"><%=Book.Title %> <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="right" valign="middle"><a class="A21" href="javascript:void(0)" 推荐给朋友</a></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table border="0" cellpadding="8" cellspacing="0" width="100%">
                    <tr>
                        <td align="center" valign="top" width="152">
                            <table border="0" cellpadding="0" cellspacing="0" height="216" width="150">
                                <tr>
                                    <td>
                                        <img alt="<%=Book.Title %>" border="1" height="216"  src="/Images/BookCovers/$isbn.jpg" style="border:1px   solid   #B0B0B0" title="$title" width="150" /></td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top" width="564">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td height="31" valign="bottom"><font class="F24"><del>定价：￥42.0</del><table border="0" cellpadding="4" cellspacing="0" width="100%">
                                <tr>
                                    <td align="left" class="L14" valign="top" width="50%"><font class="F24">作者：<%=Book.Author %>
                                        <br />
                                        书名：<%=Book.Title %><br />
                                        字数：<%=Book.WordsCount %><br />
                                        出版时间：<%=Book.PublishDate.ToString() %><br />
                                        版&nbsp;&nbsp;&nbsp;&nbsp;次： 
                                        <br />
		                <!-- 印刷时间： 2008/03/01<br>  -->
		                                印&nbsp;&nbsp;&nbsp;&nbsp;次：<br />
                                        I S B N ： <%=Book.ISBN %><br />
                                        <font color="#CC3300">本网价：<strong>￥<%=Book.UnitPrice %></strong></font></font></td>
                                    <td align="left" class="L14" valign="top" width="50%">
                                        <p>
                                            <br />
                                            <br />
                                            <font class="F24">&nbsp;<br />
                                            页&nbsp;&nbsp;&nbsp;&nbsp;数： 
                                            <br />
                                            开&nbsp;&nbsp;&nbsp;&nbsp;本： 
                                            <br />
                                            纸&nbsp;&nbsp;&nbsp;&nbsp;张： 
                                            <br />
                                            包&nbsp;&nbsp;&nbsp;&nbsp;装： </font>
                                        </p>
                                    </td>
                                </tr>
                            </table>
                                        &nbsp;&nbsp; </font> </td>
                                </tr>
                                <tr>
                                    <td height="43">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left" valign="middle"><a href="javascript:void(0)" name="buy_book">
                                                    <img border="0" height="20" src="/Template/image/7.jpg" style="cursor:hand" width="69" /></a> &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
       <table border="0" cellpadding="0" cellspacing="0" width="100%">
                  
                </table>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="center" valign="middle" width="20">
                            <img height="7" src="/Template/image/11x.jpg" /></td>
                        <td align="left" class="F25" valign="middle">心田服务承诺</td>
                    </tr>
                    <tr>
                        <td colspan="2" height="10"></td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">&nbsp;</td>
                        <td align="left" class="L14" valign="top"><font class="F24">正品：心田只做正品 假一赔一<br />
                            供货：商品均由品牌商或一级经销商供货<br />
                            送货：全国送达<br />
                            运费：全中国各省市地区全部免运费<br />
                            退换货：签收15日内，商品及包装保持本网站出售时原状且配件齐全，不影响二次销售，全款退货 </font></td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td background="/Template/image/12.jpg" height="39">&nbsp;</td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" valign="middle" width="10">
                            <img height="7" src="/Template/image/11.jpg" width="4" /></td>
                        <td align="left" class="F25" valign="middle">目录内容</td>
                    </tr>
                    <tr>
                        <td align="left" height="25" valign="top">&nbsp;</td>
                        <td align="left" class="L15" valign="top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">&nbsp;</td>
                        <td align="left" class="L15" valign="top"><%=Book.Title %> </td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td background="/Template/image/12.jpg" height="39">&nbsp;</td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" valign="middle" width="10">
                            <img height="7" src="/Template/image/11.jpg" width="4" /></td>
                        <td align="left" class="F25" valign="middle">内容简介</td>
                    </tr>
                    <tr>
                        <td align="left" height="25" valign="top">&nbsp;</td>
                        <td align="left" class="L15" valign="top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">&nbsp;</td>
                        <td align="left" class="L15" valign="top"><%=Book.ContentDescription %> </td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td background="/Template/image/12.jpg" height="39">&nbsp;</td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" valign="middle" width="10">
                            <img height="7" src="/Template/image/11.jpg" width="4" /></td>
                        <td align="left" class="F25" valign="middle">作者简介</td>
                    </tr>
                    <tr>
                        <td align="left" height="25" valign="top">&nbsp;</td>
                        <td align="left" class="L15" valign="top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">&nbsp;</td>
                        <td align="left" class="L15" valign="top"><%=Book.AurhorDescription %></td>
                    </tr>
                </table>
                <style type="text/css">

A.new_A8:link {
	FONT-SIZE: 12px; COLOR: #ffffff; TEXT-DECORATION: none
}
A.new_A8:active {
	FONT-SIZE: 12px; COLOR: #ffffff; TEXT-DECORATION: underline
}
A.new_A8:visited {
	FONT-SIZE: 12px; COLOR: #ffffff; TEXT-DECORATION: none
}
A.new_A8:hover {
	FONT-SIZE: 12px; COLOR: #ffffff; TEXT-DECORATION: underline
}

</style>

                <a name="reviewsummary"></a>
                <table border="0" cellpadding="0" cellspacing="0" height="144" width="100%">
                    <tr>
                        <td align="left" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                            <table bgcolor="#639AC3" border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <table 0="" border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td height="26" width="1%">&nbsp;</td>
                                                <td align="left"><span class="F27">顾客评论 </span> </td>
                                                <td align="left" width="75">&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
			    <!---->
                            <table border="0" cellpadding="0" cellspacing="0" height="23" width="100%">
                                <tr>
                                    <td >

                                        <ul id="commentList" >

                                        </ul>

                                    </td>
                                </tr>
                            </table>
                            <table bgcolor="#F5F5F5" border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="center" height="321" valign="middle">
                                        <table border="0" cellpadding="0" cellspacing="0" width="90">
                                            <tr>
                                                <td align="left" height="39">
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td align="left" height="25">我要评论</td>
                                                            <td align="right" valign="bottom">不超过2000字</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <textarea cols="90" name="nr" rows="10" id="txtComment" style="width:600px"></textarea> </td>
                                            </tr>
                                            <tr>
                                                <td align="left" height="35" valign="bottom">
                                                    <span id="userspan">
                                                  
                                                    不需要登录，点发表评论即可！ </span></td>
                                            </tr>
                                            <tr>
                                                <td align="left" height="35">
                                                    <img border="0" height="19" id="btnAddComment" src="/Template/image/12.gif" style="cursor:hand" width="64" /> </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </div>
<div id="footer">
    <table align="center" border="0" cellpadding="0" cellspacing="0" style="BORDER: #DCDADD 1px solid;" width="1100">
        <tr>
            <td height="37" rowspan="2"></td>
            <td align="left" class="style_14_000000" height="32" valign="bottom" width="150"><b>新手上路</b></td>
            <td align="left" class="style_14_000000" valign="bottom" width="150"><b>付款方式</b></td>
            <td align="left" class="style_14_000000" valign="bottom" width="150"><b>配送方式</b></td>
            <td align="left" class="style_14_000000" valign="bottom" width="150"><b>售后服务</b></td>
            <td align="left" class="style_14_000000" valign="bottom" width="150"><b>帮助中心</b></td>
        </tr>
        <tr>
            <td align="left" height="13" valign="middle">
                <img height="1" src="/Template/image/mid10.jpg" width="116" /></td>
            <td align="left" class="style_14_000000" valign="middle" width="150">
                <img height="1" src="/Template/image/mid10.jpg" width="116" /></td>
            <td align="left" class="style_14_000000" valign="middle" width="150">
                <img height="1" src="/Template/image/mid10.jpg" width="116" /></td>
            <td align="left" class="style_14_000000" valign="middle" width="150">
                <img height="1" src="/Template/image/mid10.jpg" width="116" /></td>
            <td align="left" class="style_14_000000" valign="middle" width="150">
                <img height="1" src="/Template/image/mid10.jpg" width="116" /></td>
        </tr>
        <tr>
            <td height="100" width="100">&nbsp;</td>
            <td align="left" class="style_h170" valign="top"><a class="a_12_000000" href="/Account/Register.aspx" target="_blank">新用户注册</a><br />
                <a class="a_12_000000" href="javascript:void(0)" target="_blank">怎样下订单</a><br />
                <a class="a_12_000000" href="javascript:void(0)" target="_blank">关于会员积分</a><br />
                <a class="a_12_000000" href="javascript:void(0)" target="_blank">礼券</a><a class="a_12_000000" href="javascript:void(0)" target="_blank">,礼品卡</a><br />
            </td>
            <td align="left" class="style_h170" valign="top"><a class="a_12_000000" href="javascript:void(0)" target="_blank">支付方式</a><br />
                <a class="a_12_000000" href="javascript:void(0)" target="_blank">支付期限</a><br />
                <a class="a_12_000000" href="javascript:void(0)" target="_blank">退款方式及时间</a> </td>
            <td align="left" class="style_h170" valign="top"><a class="a_12_000000" href="javascript:void(0)" target="_blank">运费收取标准</a><br />
                <a class="a_12_000000" href="javascript:void(0)" target="_blank">配送时间及配送范围</a> </td>
            <td align="left" class="style_h170" valign="top"><a class="a_12_000000" href="javascript:void(0)" target="_blank">服务保障承诺</a><br />
                <a class="a_12_000000" href="javascript:void(0)" target="_blank">退换货政策</a><br />
                <a class="a_12_000000" href="javascript:void(0)" target="_blank">退换货流程</a> </td>
            <td align="left" class="style_h170" valign="top"><a class="a_12_000000" href="javascript:void(0)" target="_blank">常见问题</a><br />
                <a class="a_12_000000" href="javascript:void(0)" target="_blank">找回密码</a><br />
                <a class="a_12_000000" href="javascript:void(0) target="_blank">顾客建议</a><br />
                <a class="a_12_000000" href="javascript:void(0)" target="_blank">顾客投诉</a><br />
            </td>
        </tr>
    </table>
            </div>
</center>
   <!-- 
  
-->
 <div id="dialog-message" title="错误提示!!">
	<span id="showUserLoginMsg" style="font-size:14px;color:red"></span>
     <a href="javascript:void(0)" id="locationLogin">请登录</a>
</div>
</asp:Content>

