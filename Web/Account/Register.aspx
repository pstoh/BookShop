
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BookShop.Web.Account.Register" MasterPageFile="~/MainMaster/MasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        input {
            vertical-align: middle;
            height: 16px;
            line-height: 16px;
            margin: 0;
            border: 1px #ccc solid;
            padding: 10px 0 10px 5px;
            width: 250px;
            margin-right: 8px;
            float: left;
        }

        .regnow {
            width: 300px;
            margin-left: 150px;
            height: 40px;
            background: #db2f2f;
            border: none;
            color: #FFF;
            font-size: 15px;
            font-weight: 700;
            cursor: pointer;
        }
    </style>

    <script type="text/javascript">
        $(function () {
            //验证用户名
            $('#txtUserName').blur(function () {
                checkUserName();
            });

            //校验邮箱
            $('#txtUserMail').blur(function () {
                checkMail();
            });

            //切换验证码
            $('#validateCode').click(function () {
                $("#imgCode").attr("src", $("#imgCode").attr("src") + 1);
            });

            //校验验证码
            $('#txtValidateCode').blur(function () {
                checkCode(); 
            });

        //用户注册
            $('#btnReg').click(function () {
                //alert('注册');
                if (!($('#userNameMsg').text() == 'OK' || $('#userMailMsg').text() == 'OK' || $('#validateCodeMsg').textS() == 'OK')) {
                    return false;
                }
                //校验密码省略
                var pars = $('#aspnetForm').serializeArray();
                //alert(pars);
                $.post('/ashx/RegisterUser.ashx', pars, function (data) {
                    var msg = data.split(':');
                    if (msg[0] == 'yes') {
                        alert('注册成功');
                        location.href = '/Index.aspx';
                    } else {
                        alert(msg[1]);
                        $('#userCodeMsg').text(msg[1]);
                    }
                });


        });
        });

        //校验验证码
        function checkCode() {
            var vcObj = $('#txtValidateCode');
            if (vcObj.val() != '') {
                $.post('/ashx/CheckValidateCode.ashx', {'ValidateCode': vcObj.val()
                }, function (data) {
                    if (data == 'yes') {
                        $('#validateCodeMsg').text('OK');
                    } else {
                        $('#validateCodeMsg').text('验证码错误!');
                    }
                });
            } else {
                $('#validateCodeMsg').text('验证码不能为空!');
            }
        }

            //校验用户名
            function checkUserName() {
                var userNameObj = $('#txtUserName');
                if (userNameObj.val() != '') {
                    var regex = /^\w+$/;
                    if (regex.test(userNameObj.val())) {
                        $.post('/ashx/CheckUserName.ashx', { 'userName': userNameObj.val() }, function (data) {
                            if (data == 'yes') {
                                $('#userNameMsg').text('OK');
                            } else {
                                $('#userNameMsg').text('用户名已被注册!');
                            }
                        });
                    } else {
                        $('#userNameMsg').text('用户名格式不对!');
                    }
                } else {
                    $('#userNameMsg').text('用户名不能为空!');
                }
            }

            //校验邮箱
            function checkMail() {
                var mailObj = $('#txtUserMail');
                if (mailObj.val() != '') {
                    var regex = /\w+@\w+(\.\w+)+/;
                    if (regex.test(mailObj.val())) {
                        $.post('/ashx/CheckMail.ashx', { 'mail': mailObj.val() }, function (data) {
                            if (data == 'yes') {
                                $('#userMailMsg').text('OK');
                            } else {
                                $('#userMailMsg').text('邮箱已被注册!');
                            }
                        });
                    } else {
                        $('#userMailMsg').text('邮箱无效!');
                    }
                } else {
                    $('#userMailMsg').text('邮箱不能为空!');
                }
            }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="font-size: small">
        <table width="80%" height="22" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 10px">
                    <img src="../Images/az-tan-top-left-round-corner.gif" width="10" height="28" /></td>
                <td bgcolor="#DDDDCC"><span class="STYLE1">注册新用户</span></td>
                <td width="10">
                    <img src="../Images/az-tan-top-right-round-corner.gif" width="10" height="28" /></td>
            </tr>
        </table>


        <table width="80%" height="22" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="2" bgcolor="#DDDDCC">&nbsp;</td>
                <td>
                    <div align="center">
                        <table height="61" cellpadding="0" cellspacing="0" style="height: 332px">
                            <tr>
                                <td height="33" colspan="6">
                                    <p class="STYLE2" style="text-align: center">注册新帐户方便又容易</p>
                                </td>
                            </tr>
                            <tr>
                                <td width="24%" align="center" valign="top" style="height: 26px">用户名</td>
                                <td valign="top" width="37%" align="left" style="height: 26px">
                                    <input type="text" name="txtName" id="txtUserName" placeholder="请输入用户名" /><span style="font-size: 14px; color: red" id="userNameMsg"></span></td>
                            </tr>
                            <tr>
                                <td width="24%" height="26" align="center" valign="top">真实姓名：</td>
                                <td valign="top" width="37%" align="left">
                                    <input type="text" name="txtRealName" /></td>
                            </tr>
                            <tr>
                                <td width="24%" height="26" align="center" valign="top">密码：</td>
                                <td valign="top" width="37%" align="left">
                                    <input type="password" name="txtPwd" placeholder="请输入密码" /></td>
                            </tr>
                            <tr>
                                <td width="24%" height="26" align="center" valign="top">确认密码：</td>
                                <td valign="top" width="37%" align="left">
                                    <input type="password" name="txtConfirmPwd" /></td>
                            </tr>
                            <tr>
                                <td width="24%" height="26" align="center" valign="top">Email：</td>
                                <td valign="top" width="37%" align="left">
                                    <input type="text" name="txtMail" id="txtUserMail" /><span style="font-size: 14px; color: red" id="userMailMsg"></span></td>
                            </tr>
                            <tr>
                                <td width="24%" height="26" align="center" valign="top">地址：</td>
                                <td valign="top" width="37%" align="left">
                                    <input type="text" name="txtAddress" /></td>
                            </tr>
                            <tr>
                                <td width="24%" height="26" align="center" valign="top">手机：</td>
                                <td valign="top" width="37%" align="left">
                                    <input type="text" name="txtPhone" /></td>
                            </tr>
                            <tr>
                                <td width="24%" height="26" align="center" valign="top">验证码：</td>
                                <td valign="top" width="37%" align="left">
                                    <input type="text" name="ValidateCode" id="txtValidateCode" /><a href="javascript:void(0)" id="valiateCode"><img src="/ashx/ValidateCode.ashx?id=1" id="imgCode" /></a><span style="font-size: 14px; color: red" id="validateCodeMsg"></span></td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <input type="button" id="btnReg" value="同意协议并注册" class="regnow" /></td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">&nbsp;</td>
                            </tr>
                        </table>
                        <div class="STYLE5">---------------------------------------------------------</div>
                    </div>
                </td>
                <td width="2" bgcolor="#DDDDCC">&nbsp;</td>
            </tr>
        </table>

        <table width="80%" height="3" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td height="3" bgcolor="#DDDDCC">
                    <img src="../Images/touming.gif" width="27" height="9" /></td>
            </tr>
        </table>
    </div>

</asp:Content>
