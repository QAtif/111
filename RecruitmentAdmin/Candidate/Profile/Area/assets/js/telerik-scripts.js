var $ = $telerik.$;
        var uploadsInProgress = 0;

        function onFileSelected(sender, args) {
            if (!uploadsInProgress)
                $("#SaveButton").attr("disabled", "disabled");

            uploadsInProgress++;

            var row = args.get_row();

            $(row).addClass("file-row");
        }

        function onFileUploaded(sender, args) {
            decrementUploadsInProgress();
        }

        function onUploadFailed(sender, args) {
            decrementUploadsInProgress();
        }

        function decrementUploadsInProgress() {
            uploadsInProgress--;

            if (!uploadsInProgress)
                $("#SaveButton").removeAttr("disabled");


        }


function UploadFiles()
{


$("#ContentContainer_btnUpload").click();
}


function onFileUploaded(sender, args) {
        var spanTag = document.createElement("span");
    spanTag.className = "ruFileProgressWrap";
    var spanTagInner = document.createElement("span");
    spanTagInner.className = "ruFileProgress ruProgressStarted";
    spanTag.appendChild(spanTagInner);
     
    var $span = window.$telerik.$(".ruUploadProgress", args.get_row());
    var text = $span.text();
    if (text.length > 15) {
        var newString = text.substring(0, 15) + '...';
        $span.text(newString);
        $span.append(spanTag);
    }
    }




function fileSelected(sender, args)
 {
    var $span = $(".ruUploadProgress", args.get_row());
    var name = $span.text();
    if (name.length > 15)
    {
        var newString = name.substring(0, 15) + '...';
        $span.text(newString);
    }
      // to add tooltip
    //var radToolTip = $find("<%= tooltip1.ClientID %>");
    //var RadAsyncUpload1 = $find("<%=RadAsyncUpload1.ClientID%>");
    //radToolTip.set_targetControlID("RadAsyncUpload1");
    //radToolTip.set_text(name);
}