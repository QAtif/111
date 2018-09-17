

        var element = document.getElementById('lnkUpload');
        var oldimgElement = document.getElementById('imgProfileImage').src;
        var fileExt = '.jpg';

        upclick2(
        {
            element: element,
            action: 'UploadProfileImage.aspx',
            onstart:
            function (filename) {
                fileExt = filename.substring(filename.lastIndexOf('.'), filename.length);
                oldimgElement = document.getElementById('imgProfileImage').src;
                //document.getElementById('imgProfileImage').width = 16;
                //document.getElementById('imgProfileImage').height = 16;
                document.getElementById('imgProfileImage').style.paddingTop = 64;
                document.getElementById('imgProfileImage').style.paddingLeft = 64;
                document.getElementById('imgProfileImage').className = 'ProfileImage';
                document.getElementById('imgProfileImage').src = 'filesforAccountArea/loading-profile.gif';
            },
            oncomplete:
            function (response_data) {
                if (response_data.indexOf('1Error:') != -1) {
                    //alert(response_data.substring(response_data.indexOf('Error:') + 6, response_data.indexOf('</SPAN>')));
                    alert('Please select an image file');
                    document.getElementById('imgProfileImage').src = oldimgElement;
                }
                else if (response_data.indexOf('2Error:') != -1) {
                    //alert(response_data.substring(response_data.indexOf('Error:') + 6, response_data.indexOf('</SPAN>')));
                    alert('Please Select file size between 2 Kb to 2 Mb.');
                    document.getElementById('imgProfileImage').src = oldimgElement;
                }
                else {
                    ////var imageURL = response_data.substring(response_data.indexOf('lblImage>') + 9, response_data.indexOf('</SPAN>'));
                    ////document.getElementById('imgProfileImage').src = imageURL;
                    //var lastNum = oldimgElement.substring(oldimgElement.lastIndexOf('/') + 1, oldimgElement.lastIndexOf('.'));
                    //var imageNum = parseInt(lastNum) + 1;
                    //var imageNum = parseInt(lastNum);
                    //if (isNaN(imageNum))
                    var imageNum = 1;

                    //var imageURL = document.getElementById('profileImagePath').value + imageNum + oldimgElement.substring(oldimgElement.lastIndexOf('.'), oldimgElement.length);
                    var imageURL = document.getElementById('profileImagePath').value + imageNum + fileExt;

                    document.getElementById('imgProfileImage').width = 145;
                    document.getElementById('imgProfileImage').height = 145;
                    document.getElementById('imgProfileImage').style.paddingTop = 0;
                    document.getElementById('imgProfileImage').style.paddingLeft = 0;
                    //document.getElementById('imgProfileImage').src = "";
                    document.getElementById('imgProfileImage').src = imageURL;
                    document.getElementById('imgProfileImage').className = 'ProfileImage';
                    /////////////////////////////// document.getElementById('imgProfileImageSmall').src = imageURL;
                    // for refresh the page
                    window.location.reload();
                }

            }
        }
    );
        var element2 = document.getElementById('lnkUpload2');
        var oldimgElement2 = document.getElementById('imgCoverImage').src;
        var fileExt2 = '.jpg';

        upclick(
        {
            element: element2,
            action: 'UploadCoverImage.aspx',
            onstart:
            function (filename) {
                //alert('Starting upload Covert Photo: ' + filename);
                fileExt2 = filename.substring(filename.lastIndexOf('.'), filename.length);
                oldimgElement2 = document.getElementById('imgCoverImage').src;
                //document.getElementById('imgCoverImage').width = 16;
                //document.getElementById('imgCoverImage').height = 16;
                document.getElementById('imgCoverImage').style.paddingTop = 0;
                document.getElementById('imgCoverImage').style.paddingLeft = 0;
                document.getElementById('imgCoverImage').src = 'filesforAccountArea/loading-cover.gif';
                document.getElementById('imgCoverImage').className = 'CoverImage';

                $('.change-profile-pic').hide();
                $('.change-cover').hide();
                $('.change-profile-pic').removeClass('active')
            },
            oncomplete:
            function (response_data) {
                //alert(response_data);
                if (response_data.indexOf('1Error:') != -1) {
                    //alert(response_data.substring(response_data.indexOf('Error:') + 6, response_data.indexOf('</SPAN>')));
                    alert('Please select an image file');
                    document.getElementById('imgCoverImage').src = oldimgElement2;
                }
                else if (response_data.indexOf('2Error:') != -1) {
                    //alert(response_data.substring(response_data.indexOf('Error:') + 6, response_data.indexOf('</SPAN>')));
                    alert('Please Select file size between 2 Kb to 4 Mb.');
                    document.getElementById('imgCoverImage').src = oldimgElement;
                }
                else {
                    //var imageURL = response_data.substring(response_data.indexOf('lblImage>') + 9, response_data.indexOf('</SPAN>'));
                    //document.getElementById('imgCoverImage').src = imageURL;

                    var lastNum = oldimgElement2.substring(oldimgElement2.lastIndexOf('/') + 1, oldimgElement2.lastIndexOf('.'));
                    var imageNum = parseInt(lastNum) + 1;
                    if (isNaN(imageNum))
                        imageNum = 1;

                    //var imageURL = document.getElementById('profileImagePath').value + 'CovertPhotos/' + imageNum + oldimgElement2.substring(oldimgElement2.lastIndexOf('.'), oldimgElement2.length);
                    var imageURL = document.getElementById('profileImagePath').value + 'CovertPhotos/' + imageNum + fileExt2;

                    document.getElementById('imgCoverImage').width = 977;
                    document.getElementById('imgCoverImage').height = 313;
                    document.getElementById('imgCoverImage').style.paddingTop = 0;
                    document.getElementById('imgCoverImage').style.paddingLeft = 0;
                    document.getElementById('imgCoverImage').src = imageURL;
                    document.getElementById('imgCoverImage').className = 'CoverImage';
                }

            }
        }
    );



        function closeBPopup() { $('#popup2').bPopup().close(); }
        // function closeBPopup() { $('.fancybox.iframe').close(); }
        // function closeBPopup() { $('.fancybox.iframe').close(); }

        function cover() {
            //a.enabled=false;
            var location = '~/assets3/images/personal/cover.jpg';
            $("#imgCoverImage").attr("src", location);
            $('.change-profile-pic li+li a').removeClass('pop2');
            $('.change-profile-pic li+li a').removeClass('small');
        }
        function profile() {
            //a.enabled=false;
            $('.edit-option li+li a').removeClass('pop2');
            $('.edit-option li+li a').removeClass('small');
            var location = '~/assets3/images/personal/profile.jpg';
            $("#imgProfileImage").attr("src", location);
            //////////////////$("#imgProfileImageSmall").attr("src", location);
        }