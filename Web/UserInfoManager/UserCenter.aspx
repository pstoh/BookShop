<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserCenter.aspx.cs" Inherits="BookShop.Web.UserInfoManager.UserCenter" MasterPageFile="~/MainMaster/UserMaster.Master" %>

<asp:Content ID="content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
        #divCut {
            background-position: top left
        }
    </style>
    <link href="/Css/imgareaselect-default.css" rel="stylesheet" />
    <script src="/Scripts/jquery.imgareaselect.min.js"></script>
    <script src="/Scripts/SWFUpload/swfupload.js"></script>
    <script src="/Scripts/SWFUpload/handlers.js"></script>
    <script type="text/javascript">
        onload=function () {
            var swfu;
            swfu = new SWFUpload({
                // Backend Settings
                upload_url: "/ashx/Upload.ashx?action=up",
                post_params: {
                    "ASPSESSID": "<%=Session.SessionID %>"
                },

                // File Upload Settings
                file_size_limit: "2 MB",
                file_types: "*.jpg;*.gif",
                file_types_description: "JPG Images",
                file_upload_limit: 0,    // Zero means unlimited

                // Event Handler Settings - these functions as defined in Handlers.js
                //  The handlers are not part of SWFUpload but are part of my website and control how
                //  my website reacts to the SWFUpload events.
                swfupload_preload_handler: preLoad,
                swfupload_load_failed_handler: loadFailed,
                file_queue_error_handler: fileQueueError,
                file_dialog_complete_handler: fileDialogComplete,
                upload_progress_handler: uploadProgress,
                upload_error_handler: uploadError,
                upload_success_handler: showImage,
                upload_complete_handler: uploadComplete,

                // Button settings
                button_image_url: "/Scripts/SWFUpload/images/XPButtonNoText_160x22.png",
                button_placeholder_id: "spanButtonPlaceholder",
                button_width: 160,
                button_height: 22,
                button_text: '<span class="button">请选择上传图片<span class="buttonSmall">(2 MB Max)</span></span>',
                button_text_style: '.button { font-family: Helvetica, Arial, sans-serif; font-size: 14pt; } .buttonSmall { font-size: 10pt; }',
                button_text_top_padding: 1,
                button_text_left_padding: 5,

                // Flash Settings
                flash_url: "/Scripts/SWFUpload/swfupload.swf",	// Relative to this file
                flash9_url: "/Scripts/SWFUpload/swfupload_FP9.swf",	// Relative to this file

                custom_settings: {
                    upload_target: "divFileProgressContainer"
                },

                // Debug Settings
                debug: false

            });
        };
        //上传成功吊用此方法
        function showImage(file, data) {
            var datas = data.split(':');
            if (datas[0] == 'OK') {
                $('#selectbanner').attr('src', datas[1]);
                $('#selectbannet').imgAreaSelect({
                    selectionColor: 'blue', x1: 0, y1: 0, x2: 150, y2: 100,

                    //maxWidth: 950, minWidth: 950,  minHeight: 400, maxHeight: 400,

                    selectionOpacity: 0.2, onSelectEnd: preview
                });
                $('#imagePath').val(datas[1]);
            } else {
                alert(datas[1]);
            }

        }
        //选择结束以后调用该方法(确定出要截取头像的范围，并且通过data方法存储要截取头像范围的数据)
        function preview(img, selection) {
            $('#selectbanner').data('x', selection.x1);
            $('#selectbanner').data('y', selection.y1);
            $('#selectbanner').data('w', selection.width);
            $('#selectbanner').data('h', selection.height);
        }
        $(function () {
            $('#btnPhotoCut').click(function () {
                var pars = {
                    x: $('#selectbannet').data('x'),
                    y: $('#selectbannet').data('y'),
                    w: $('#selectbannet').data('w'),
                    h: $('#selectbannet').data('h'),
                    imagePath: $('#imagePath').val(),
                    action: 'cut'
                };
                $.post('/ashx/Upload.ashx', pars, function (data) {
                    $('#imgSrc').attr('src', data);
                });
            });
        });

    </script>
</asp:Content>

<asp:Content ID="content2" ContentPlaceHolderID="cphContent" runat="server">
        <div id="content">
	    <div id="swfu_container" style="margin: 0px 10px;">
		    <div>
				<span id="spanButtonPlaceholder"></span>
		    </div>
		    <div id="divFileProgressContainer" style="height: 75px;"></div>
		    <div id="thumbnails"></div>
           <%-- <div id="divContent" style="width:300px; height:300px">
                <div id="divCut" style="width:100px; height:100px;border:solid 1px red">

                </div>
            </div>--%>
            <img id="selectbanner"/>
            <input type="button" value="头像截取" id="btnPhotoCut" />
            <input type="hidden" id="imagePath" />
            <br />
            <img id="imgSrc" />
	    </div>
		</div>


</asp:Content>
