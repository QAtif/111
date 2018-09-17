 function onFileUploading(sender, args) {
            var spanTag = document.createElement("span");
            spanTag.className = "ruFileProgressWrap";
            var spanTagInner = document.createElement("span");
            spanTagInner.className = "ruFileProgress ruProgressStarted";
            spanTag.appendChild(spanTagInner);

            var $span = window.$telerik.$(".ruUploadProgress", args.get_row());
            var text = $span.text();

            var newString = 'Uploading selected file';
            $span.text(newString);
            $span.append(spanTag);       
        }
        function onFileUploaded(sender, args) {

            var $span = $(".ruUploadProgress", args.get_row());
            var name = $span.text();

            var newString = 'Uploaded file';
            $span.text(newString);
        }
        function onValidationFail(sender, args) {

            var $span = $(".ruUploadProgress", args.get_row());
            var name = $span.text();

            var newString = 'Invalid file format';
            $span.text(newString);
        }
function UploadFiles()
{
$("#ContentContainer_btnUpload").click();
}

