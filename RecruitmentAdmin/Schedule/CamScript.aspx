﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CamScript.aspx.cs" Inherits="Schedule_CamScript" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
	<head>
		<script language="JavaScript" src="//ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript"></script>
		<script language="JavaScript" src="//ajax.googleapis.com/ajax/libs/swfobject/2.2/swfobject.js" type="text/javascript"></script>

    <script src="../assets/js/scriptcam.js" type="text/javascript"></script>

		<script language="JavaScript"  type="text/javascript">
		    $(document).ready(function () {
		        $("#webcam").scriptcam({
		            showMicrophoneErrors: false,
		            onError: onError,
		            cornerRadius: 20,
		            cornerColor: 'e3e5e2',
		            onWebcamReady: onWebcamReady,
		            uploadImage: 'upload.gif',
		            onPictureAsBase64: base64_tofield_and_image
		        });
		    });
		    function base64_tofield() {
		        $('#formfield').val($.scriptcam.getFrameAsBase64());
		    };
		    function base64_toimage() {
		        $('#image').attr("src", "data:image/png;base64," + $.scriptcam.getFrameAsBase64());
		    };
		    function base64_tofield_and_image(b64) {
		        $('#formfield').val(b64);
		        $('#image').attr("src", "data:image/png;base64," + b64);
		    };
		    function changeCamera() {
		        $.scriptcam.changeCamera($('#cameraNames').val());
		    }
		    function onError(errorId, errorMsg) {
		        $("#btn1").attr("disabled", true);
		        $("#btn2").attr("disabled", true);
		        alert(errorMsg);
		    }
		    function onWebcamReady(cameraNames, camera, microphoneNames, microphone, volume) {
		        $.each(cameraNames, function (index, text) {
		            $('#cameraNames').append($('<option></option>').val(index).html(text))
		        });
		        $('#cameraNames').val(camera);
		    }
		</script> 
	</head>
	<body style=" background-color:#555;">
		<div style="width:330px;float:left;">
			<div id="webcam">
			</div>
			<div style="margin:5px;">
				<img src="webcamlogo.png" style="vertical-align:text-top"/>
				<select id="cameraNames" size="1" onChange="changeCamera()" style="width:245px;font-size:10px;height:25px;">
				</select>
			</div>
		</div>
		<div style="width:135px;float:left;">
			<p><button class="btn btn-small" id="btn1" onclick="base64_tofield()">Snapshot to form</button></p>
			<p><button class="btn btn-small" id="btn2" onclick="base64_toimage()">Snapshot to image</button></p>
		</div>
		<div style="width:200px;float:left;">
			<p><textarea id="formfield" style="width:190px;height:70px;"></textarea></p>
			<p><img id="image" style="width:200px;height:153px;"/></p>
		</div>
	</body>
</html>
