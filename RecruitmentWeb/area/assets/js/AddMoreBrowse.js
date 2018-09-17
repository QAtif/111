var Opera = navigator.userAgent.toLowerCase().indexOf("opera") != -1 ? true : false;
var Opera8 = navigator.userAgent.toLowerCase().indexOf("opera 8") != -1 ? true : false;
var Opera7 = navigator.userAgent.toLowerCase().indexOf("opera 7") != -1 ? true : false;
var Opera6 = navigator.userAgent.toLowerCase().indexOf("opera 6") != -1 ? true : false;
var Opera5 = navigator.userAgent.toLowerCase().indexOf("opera 5") != -1 ? true : false;
var Opera4 = navigator.userAgent.toLowerCase().indexOf("opera 4") != -1 ? true : false;
var Netscape4 = navigator.userAgent.toLowerCase().indexOf("mozilla/4.79") != -1 ? true : false;
var Netscape6 = navigator.userAgent.toLowerCase().indexOf("netscape6") != -1 ? true : false;
var Netscape7 = navigator.userAgent.toLowerCase().indexOf("netscape/7") != -1 ? true : false;
var Netscape8 = navigator.userAgent.toLowerCase().indexOf("netscape/8") != -1 ? true : false;
var MozillaFireFoxRev0 = (navigator.userAgent.toLowerCase().indexOf("mozilla") != -1 ? true : false) && (navigator.userAgent.toLowerCase().indexOf("gecko") != -1 ? true : false) && (navigator.userAgent.toLowerCase().indexOf("rv:0") != -1 ? true : false);

var MozillaFireFoxRev10 = (navigator.userAgent.toLowerCase().indexOf("mozilla") != -1 ? true : false) && (navigator.userAgent.toLowerCase().indexOf("gecko") != -1 ? true : false) && (navigator.userAgent.toLowerCase().indexOf("rv:1.0") != -1 ? true : false);

var MozillaFireFoxRev11 = (navigator.userAgent.toLowerCase().indexOf("mozilla") != -1 ? true : false) && (navigator.userAgent.toLowerCase().indexOf("gecko") != -1 ? true : false) && (navigator.userAgent.toLowerCase().indexOf("rv:1.1") != -1 ? true : false);

var MozillaFireFoxRev12 = (navigator.userAgent.toLowerCase().indexOf("mozilla") != -1 ? true : false) && (navigator.userAgent.toLowerCase().indexOf("gecko") != -1 ? true : false) && (navigator.userAgent.toLowerCase().indexOf("rv:1.2") != -1 ? true : false);

var MozillaFireFoxRev13 = (navigator.userAgent.toLowerCase().indexOf("mozilla") != -1 ? true : false) && (navigator.userAgent.toLowerCase().indexOf("gecko") != -1 ? true : false) && (navigator.userAgent.toLowerCase().indexOf("rv:1.3") != -1 ? true : false);

var MozillaFireFoxRev14 = (navigator.userAgent.toLowerCase().indexOf("mozilla") != -1 ? true : false) && (navigator.userAgent.toLowerCase().indexOf("gecko") != -1 ? true : false) && (navigator.userAgent.toLowerCase().indexOf("rv:1.4") != -1 ? true : false);

var MozillaFireFoxRev15 = (navigator.userAgent.toLowerCase().indexOf("mozilla") != -1 ? true : false) && (navigator.userAgent.toLowerCase().indexOf("gecko") != -1 ? true : false) && (navigator.userAgent.toLowerCase().indexOf("rv:1.5") != -1 ? true : false);

var MozillaFireFoxRevOlder15 = MozillaFireFoxRev0 || MozillaFireFoxRev10 || MozillaFireFoxRev11 || MozillaFireFoxRev12 || MozillaFireFoxRev13 || MozillaFireFoxRev14 || MozillaFireFoxRev15;
var IE4 = navigator.userAgent.toLowerCase().indexOf("msie 4") != -1 ? true : false;


/////////////////////////////////////////////////////////////////////////////////////
//Variable to store last BrowseFile input Index
var PowUploadLastFileIndex = 1;

var controlIDPrefix;
function SetControlIDPrefix(controlID) {
    controlIDPrefix = controlID;
}

function BindURLData(AllDATA, total) {
    $('#ContentContainer_hdfFileCounter').val(total);

    if (total == 100) {
        $('#BrowseFilediv1').show();
        $('#ContentContainer_MoreFileAdder').hide();
    }
    else if (total < 101) {
        $('#BrowseFilediv1').show();
    }
    else {
        $('#BrowseFilediv1').hide();
    }

    var arr = AllDATA.split('|');
    $.each(arr, function(key, line) {
        var list = line.split('~');
        var title = list[0];
        var url = list[1];
        var newFileIndex = key + 2;
        //alert(key + ' | '+newFileIndex+' | ' + line);
        if (title != "") {
            if (key >= 0) {
                var parentObj = document.getElementById('AddMoreFilesList');
                //var newFileIndex = key + 1;
                var newFileInputID = 'BrowseFilediv' + newFileIndex;
                if (document.getElementById(newFileInputID) == null) {
                    var newFileInput = document.createElement('div');
                    newFileInput.setAttribute("id", newFileInputID);
                    newFileInput.setAttribute("class", "row-fluid item");
                    newFileInput.innerHTML = '<div class="span3 offset1"><input type="text" name="txtTitle' + newFileIndex + '" id="txtTitle' + newFileIndex + '" class="jqtranformdone" placeholder="Title" /></div><div class="span6"><input name="txtURL' + newFileIndex + '" id="txtURL' + newFileIndex + '" class="jqtranformdone" value="" placeholder="URL" type="text" /></div><div class="span1"><button title="" data-original-title="" class="btn btn-small " type="button" onclick="javascript: RemoveFileInput(\'' + newFileInputID + '\', 100);"><img src="/Area/assets/img/minus.jpg" alt=""></button></div>';
                    parentObj.appendChild(newFileInput);

                    var hdnFileControlIDs = document.getElementById(controlIDPrefix + 'hdnFileControlIDs');
                    hdnFileControlIDs.value += "txtTitle" + newFileIndex + ":";
                }
            }
            var titleID = 'txtTitle' + newFileIndex;
            var urlID = 'txtURL' + newFileIndex;
            $('#' + titleID).val(title);
            $('#' + urlID).val(url);
        }
    });
}

function AddFileInput(parentObjID, maxFiles) {
    //debugger; 

    var hdfFileCounterValue;
    if (document.getElementById(controlIDPrefix + 'hdfFileCounter')) {
        hdfFileCounterValue = document.getElementById(controlIDPrefix + 'hdfFileCounter').value;
    }

    if (hdfFileCounterValue < 100) {
        if (Opera7 || Opera6 || Opera5) {
            window.alert("This feature not supported in your browser!");
            return;
        };
        var parentObj = document.getElementById(parentObjID);
        PowUploadLastFileIndex = hdfFileCounterValue;
        PowUploadLastFileIndex++;
        var newFileIndex = PowUploadLastFileIndex;
        var newFileInputID = 'BrowseFilediv' + newFileIndex;
        var newFileInput = document.createElement('div');
        newFileInput.setAttribute("id", newFileInputID);
        newFileInput.setAttribute("class", "row-fluid item");
        newFileInput.innerHTML = '<div class="span3 offset1"><input type="text" name="txtTitle' + newFileIndex + '" id="ContentContainer_txtTitle' + newFileIndex + '" class="jqtranformdone" placeholder="Title" runat="server" /></div><div class="span6"><input name="txtURL' + newFileIndex + '" id="ContentContainer_txtURL' + newFileIndex + '" class="jqtranformdone" value="" placeholder="URL" type="text" runat="server" /></div><div class="span1"><button title="" data-original-title="" class="btn btn-small " type="button" onclick="javascript: RemoveFileInput(\'' + newFileInputID + '\', ' + maxFiles + ');"><img src="/Area/assets/img/minus.jpg" alt=""></button></div>';

        //newFileInput.innerHTML += '&nbsp;&nbsp;<a href="javascript:;" onClick="javascript: RemoveFileInput(\'' + newFileInputID + '\', ' + maxFiles + ');">Remove</a>';
        //newFileInput.innerHTML += '&nbsp;&nbsp;<a href="#" onClick="javascript: ClearInputField(\'txtTitle' + newFileIndex + '\');">Clear</a>';
        //newFileInput.innerHTML += '<br>';
        parentObj.appendChild(newFileInput);
        //newFileInput.scrollTop = newFileInput.offsetTop;
        //window.scrollTo(0,newFileInput.offsetTop);

        var hdnFileControlIDs = document.getElementById(controlIDPrefix + 'hdnFileControlIDs');
        hdnFileControlIDs.value += "txtTitle" + newFileIndex + ":";

        //+ var sl_off=$('#'+controlIDPrefix+'txtTitle1').offset();
        //+  var sl_t=sl_off.top - 200;
        //+  $('html').animate({scrollTop:sl_t},1500);


        document.getElementById(controlIDPrefix + 'hdfFileCounter').value = parseInt(hdfFileCounterValue) + parseInt(1);
        if (document.getElementById(controlIDPrefix + 'hdfFileCounter').value == maxFiles)
            document.getElementById(controlIDPrefix + 'MoreFileAdder').style.display = "none";

    }
	document.getElementById('ContentContainer_txtTitle'+(newFileIndex)).value=document.getElementById('txtTitle1').value;
	document.getElementById('ContentContainer_txtURL'+(newFileIndex)).value=document.getElementById('txtURL1').value;

	document.getElementById('txtTitle1').value='';
	document.getElementById('txtURL1').value='';

    //Uncomment line below to add new FileInput in front of other inputs.
    //parentObj.insertBefore(newFileInput, parentObj.firstChild);     
}
/////////////////////////////////////////////////////////////////////
// Function to remove BrowseFile input
function RemoveFileInput(objToRemoveID, maxFiles) {
    if (Opera6 || Opera5) {
        window.alert("This feature not supported in your browser!");
        return;
    };
    var ObjToRemove = document.getElementById(objToRemoveID);
    var parentObj = ObjToRemove.parentNode;
    parentObj.removeChild(ObjToRemove);

    var hdnFileControlIDs = document.getElementById(controlIDPrefix + 'hdnFileControlIDs');
    hdnFileControlIDs.value = hdnFileControlIDs.value.replace(objToRemoveID + ':', '');

    //+  var sl_off=$('#'+controlIDPrefix+'txtTitle1').offset();
    //+      var sl_t=sl_off.top - 200;
    //+      $('html').animate({scrollTop:sl_t},1500);

    /*var hdfFileCounterValue = document.getElementById(controlIDPrefix + 'hdfFileCounter').value;
    document.getElementById(controlIDPrefix + 'hdfFileCounter').value = parseInt(hdfFileCounterValue) - parseInt(1);
    if (document.getElementById(controlIDPrefix + 'hdfFileCounter').value < maxFiles)
        document.getElementById(controlIDPrefix + 'MoreFileAdder').style.display = "inline";

    if (document.getElementById(controlIDPrefix + 'hdfFileCounter').value == 100) {
        $('#BrowseFilediv1').show();
        $('#ContentContainer_MoreFileAdder').hide();
    }
    else if (document.getElementById(controlIDPrefix + 'hdfFileCounter').value < 101) {
        $('#BrowseFilediv1').show();
    }
    else {
        $('#BrowseFilediv1').hide();
    }*/
}

// Function to clear BrowseFile input
function ClearInputField(inputID) {
    if (Opera4 || Opera5 || Opera6 || Opera7 || Netscape4 || Netscape6) {
        window.alert("This feature not supported in your browser!");
        return;
    };
    var inputObj = document.getElementById(inputID);
    var parentObj = inputObj.parentNode;
    var nextObj = inputObj.nextSibling;
    var EmptyFileInput;

    if (!Opera && inputObj.outerHTML) {

        EmptyFileInput = document.createElement(inputObj.outerHTML);
        parentObj.removeChild(inputObj);
        parentObj.insertBefore(EmptyFileInput, nextObj);

    }
    else //for FireFox that doesn't supports outerHTML property
    {
        var tmpParentObj = document.createElement('font');
        tmpParentObj.appendChild(inputObj);
        var innerHTMLCode = tmpParentObj.innerHTML;
        tmpParentObj.removeChild(inputObj);
        EmptyFileInput = document.createElement('font');
        EmptyFileInput.innerHTML = innerHTMLCode;
        parentObj.insertBefore(EmptyFileInput.childNodes[0], nextObj);

    }
    var sl_off = $('#' + EmptyFileInput.id).offset();
    var sl_t = sl_off.top - 200;
    $('html').animate({ scrollTop: sl_t }, 1500)

}
