<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RequireJsDemo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Uploadfile</title>
    <link href="Assets/Css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
	            font: 13px Arial, Helvetica, Sans-serif;
            }
        #queue {
            background-color: #FFF;
            border-radius: 3px;
            box-shadow: 0 1px 3px rgba(0,0,0,0.25);
            height: 103px;
            margin-bottom: 10px;
            overflow: auto;
            padding: 5px 10px;
            width: 300px;
        }         
    </style>
    <script src="Assets/Js/Libs/jquery-2.0.3.min.js" type="text/javascript"></script>
    <script src="Assets/Js/Plugins/uploadify/jquery.uploadify.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="Assets/Js/Plugins/uploadify/uploadify.css" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>Uploadify Demo</h1>
        <div id="queue"></div>
		<input id="file_upload" name="file_upload" type="file" multiple="true" class="btn btn-danger btn-sm">
    </form>
    <script type="text/javascript">
        $(function() {
            $('#file_upload').uploadify({
                queueID: 'queue',
                swf: 'Assets/Js/Plugins/uploadify/uploadify.swf',
                uploader: 'UploadFile.ashx',                
                buttonText: 'BROWSE'
            });
        });
    </script>
</body>
</html>
