<!--CoverPage-->
<script type="text/javascript" src="/accountarea/jquery.js"></script>
<script type="text/javascript" src="/accountarea/upclick-min.js"></script>
<script type="text/javascript">
    var element = document.getElementById('lnkUpload');
    var oldimgElement = document.getElementById('profileArea_imgProfileImage').src;
    var fileExt = '.jpg';
    var fileNameValidation;
    upclick2(
        {
            element: element,
            action: '../Area/Socialmedia/UploadProfileImage.aspx',
            onstart:
            function(filename) {
                fileExt = filename.substring(filename.lastIndexOf('.'), filename.length);
                fileNameValidation = filename;
                oldimgElement = document.getElementById('profileArea_imgProfileImage').src;
                document.getElementById('profileArea_imgProfileImage').style.paddingTop = 0;
                document.getElementById('profileArea_imgProfileImage').style.paddingLeft = 0;
                document.getElementById('profileArea_imgProfileImage').className = 'ProfileImage';
                document.getElementById('profileArea_imgProfileImage').src = '../Area/Socialmedia/filesforAccountArea/loading-profile.gif';
            },
            oncomplete:
            function(response_data) {
                if (response_data.indexOf('1Error:') != -1) {
                    alert('Please select an image file');
                    document.getElementById('profileArea_imgProfileImage').src = oldimgElement;
                }
                else if (response_data.indexOf('2Error:') != -1) {
                    alert('Please Select file size between 2 Kb to 2 Mb.');
                    document.getElementById('profileArea_imgProfileImage').src = oldimgElement;
                }
                else {
                    var lastNum = oldimgElement.substring(oldimgElement.lastIndexOf('/') + 1, oldimgElement.lastIndexOf('.'));
                    var imageNum = parseInt(lastNum) + 1;
                    if (isNaN(imageNum))
                        imageNum = 1;
                    // for validate image file
                    var currentFileExt = fileNameValidation.substring(fileNameValidation.lastIndexOf('.'), fileNameValidation.length);
                    if (currentFileExt == ".gif" || currentFileExt == ".GIF" || currentFileExt == ".JPEG" || currentFileExt == ".jpeg" || currentFileExt == ".jpg" || currentFileExt == ".JPG" || currentFileExt == ".png" || currentFileExt == ".PNG" || currentFileExt == ".bmp" || currentFileExt == ".BMP") {
                        var imageURL = document.getElementById('profileArea_profileImagePath').value + '/ProfilePhotos/' + imageNum + fileExt;
                        imageURL = imageURL.replace("~", "..");
                        document.getElementById('profileArea_imgProfileImage').width = 145;
                        document.getElementById('profileArea_imgProfileImage').height = 145;
                        document.getElementById('profileArea_imgProfileImage').style.paddingTop = 0;
                        document.getElementById('profileArea_imgProfileImage').style.paddingLeft = 0;
                        document.getElementById('profileArea_imgProfileImage').src = imageURL;
                        document.getElementById('profileArea_imgProfileImage').className = 'ProfileImage';
                        document.getElementById('profileArea_imgProfileImageSmall').src = imageURL;
                        document.getElementById('profileArea_imgNavImageSmall').src = imageURL;
                        // for refresh the page
                        //window.location.reload();   height: 0px;
                        document.getElementById('profileArea_removeProfilePict').style.visibility = 'visible';
                        document.getElementById('profileArea_removeProfilePict').style.height = 'auto';
                    }
                    else {
                        document.getElementById('profileArea_imgProfileImage').src = '../Area/SocialMedia/UserImagePath/profile.jpg';
                        alert("Please select an image file.");
                        element.focus();
                    }
                }

            }
        }
    );
    var element2 = document.getElementById('lnkUpload2');
    var oldimgElement2 = document.getElementById('profileArea_draggable').src;
    var fileExt2 = '.jpg';
    var fileNameValidationCov;

    upclick(
        {
            element: element2,
            action: '../Area/Socialmedia/UploadCoverImage.aspx',
            onstart:
            function(filename) {
                fileExt2 = filename.substring(filename.lastIndexOf('.'), filename.length);
                fileNameValidationCov = filename;
                oldimgElement2 = document.getElementById('profileArea_draggable').src;
                document.getElementById('profileArea_draggable').style.paddingTop = 0;
                document.getElementById('profileArea_draggable').style.paddingLeft = 0;
                document.getElementById('profileArea_draggable').src = '/Area/Socialmedia/filesforAccountArea/loading-cover.gif';
                document.getElementById('profileArea_draggable').className = 'CoverImage';

                $('.change-profile-pic').hide();
                $('.change-cover').hide();
                $('.change-profile-pic').removeClass('active')
            },
            oncomplete:
            function(response_data) {

                if (response_data.indexOf('1Error:') != -1) {
                    alert('Please select an image file');
                    document.getElementById('profileArea_draggable').src = oldimgElement2;
                }

                else if (response_data.indexOf('2Error:') != -1) {
                    alert('Please Select file size between 2 Kb to 4 Mb.');
                    document.getElementById('profileArea_draggable').src = oldimgElement;
                }

                else {
                    var lastNum = oldimgElement2.substring(oldimgElement2.lastIndexOf('/') + 1, oldimgElement2.lastIndexOf('.'));
                    var imageNum = parseInt(lastNum) + 1;
                    if (isNaN(imageNum))
                        imageNum = 1;

                    // for validate image file
                    var currentFileExt = fileNameValidationCov.substring(fileNameValidationCov.lastIndexOf('.'), fileNameValidationCov.length);

                    if (currentFileExt == ".gif" || currentFileExt == ".GIF" || currentFileExt == ".JPEG" || currentFileExt == ".jpeg" || currentFileExt == ".jpg" || currentFileExt == ".JPG" || currentFileExt == ".png" || currentFileExt == ".PNG" || currentFileExt == ".bmp" || currentFileExt == ".BMP") {
                        var imageURL = document.getElementById('profileArea_profileImagePath').value + '/CoverPhotos/' + imageNum + fileExt2;
                        // document.getElementById('profileArea_draggable').width = 977;
                        // document.getElementById('profileArea_draggable').height = 313;
                        document.getElementById('profileArea_draggable').style.paddingTop = 0;
                        document.getElementById('profileArea_draggable').style.paddingLeft = 0;
                        document.getElementById('profileArea_draggable').src = imageURL.replace("~", "..");
                        document.getElementById('profileArea_draggable').className = 'CoverImage';
                        //window.location.reload();
                        document.getElementById('profileArea_removeCoverPict').style.visibility = 'visible';
                        document.getElementById('profileArea_removeCoverPict').style.height = 'auto';

                        var theclick = 0;

                        $('#dragger').fadeIn();
                        $('#xoptions,.XdpMneu').hide();
                        $('#xCoverOptions').show();
                        $('header > div:lt(2),#xnav,#main > div.row-fluid').not('#xdp *').fadeTo('slow', 0.5);
                        theclick = 1;
                        if (theclick == 1) {
                            $("#xcoverInner img").draggable("option", "disabled", false);
                        }

                    }
                    else {
                        document.getElementById('profileArea_draggable').src = '../Area/SocialMedia/UserImagePath/cover.jpg';
                        alert("Please select an image file.");
                        element2.focus();
                    }


                }
             
            }




        }




    );

    function cover() {
        var location = '~/assets/images/personal/cover.jpg';
        $("#profileArea_draggable").attr("src", location);
        $('.change-profile-pic li+li a').removeClass('pop2');
        $('.change-profile-pic li+li a').removeClass('small');
    }
    function profile() {
        $('.edit-option li+li a').removeClass('pop2');
        $('.edit-option li+li a').removeClass('small');
        var location = '~/assets/images/personal/profile.jpg';
        $("#profileArea_imgProfileImage").attr("src", location);
    }
</script>
<script type="text/javascript">


    function FillPCountryCode() {
        var txtTelephoneCodeId = 'profileArea_txtPPhoneCode';
        var ddlCountryCodeId = 'profileArea_ddlPCountry';
        var hdCountryCodeStrId = 'profileArea_hdCountryCodeString';
        var hdPhoneCodeId = 'profileArea_hdPhoneCode';
        var ddlCountries;
        var hdPhoneCode;
        var hdCountryCodeString;
        ddlCountries = document.getElementById(ddlCountryCodeId);
        hdPhoneCode = document.getElementById(hdPhoneCodeId);
        hdCountryCodeString = document.getElementById(hdCountryCodeStrId);
        var arr = ddlCountries[ddlCountries.selectedIndex].value;
        var my_array = arr.split("-");
        hdCountryCodeString.value = my_array[1];
        hdPhoneCode.value = my_array[0];

        var TelePhone_Code = document.getElementById(txtTelephoneCodeId);
        TelePhone_Code.value = my_array[0];
    }


    function FillCCountryCode() {
        var txtTelephoneCodeId = 'profileArea_txtCLPhoneCode';
        var ddlCountryCodeId = 'profileArea_ddlCLocation';
        var hdCountryCodeStrId = 'profileArea_hdCountryCodeString';
        var hdPhoneCodeId = 'profileArea_hdPhoneCode';
        var ddlCountries;
        var hdPhoneCode;
        var hdCountryCodeString;
        ddlCountries = document.getElementById(ddlCountryCodeId);
        hdPhoneCode = document.getElementById(hdPhoneCodeId);
        hdCountryCodeString = document.getElementById(hdCountryCodeStrId);
        var arr = ddlCountries[ddlCountries.selectedIndex].value;
        var my_array = arr.split("-");
        hdCountryCodeString.value = my_array[1];
        hdPhoneCode.value = my_array[0];

        var TelePhone_Code = document.getElementById(txtTelephoneCodeId);
        TelePhone_Code.value = my_array[0];
    }

    function IPersonalInfo() {

        var FName = document.getElementById('profileArea_txtFirstName').value;
        var LName = document.getElementById('profileArea_txtLastName').value;
        var ddlMonth = document.getElementById('profileArea_ddlMonth');
        var ddlMonthValue = ddlMonth[ddlMonth.selectedIndex].value;
        var ddlDay = document.getElementById('profileArea_ddlDay');
        var ddlDayValue = ddlDay[ddlDay.selectedIndex].value;
        var ddlYear = document.getElementById('profileArea_ddlYear');
        var ddlYearValue = ddlYear[ddlYear.selectedIndex].value;


        var validatestring = "";

        if (FName == "First Name*" || FName == "") {
            validatestring += "Please Provide First Name \n"
        }

        if (LName == "Last Name*" || LName == "") {
            validatestring += "Please Provide Last Name \n"
        }

        if (ddlMonthValue == "0" || ddlMonthValue == "-1") {
            validatestring += "Please Provide Month \n"
        }

        if (ddlDayValue == "0" || ddlDayValue == "-1") {
            validatestring += "Please Provide Day \n"
        }

        if (ddlYearValue == "0" || ddlYearValue == "-1") {
            validatestring += "Please Provide Year \n"
        }


        if (validatestring != "") {
            alert(validatestring);
            return false;
        }



        return true;
    }



    function IContactInfo() {


        var ddlPCountry = document.getElementById('profileArea_ddlPCountry');
        var ddlPCountryValue = ddlPCountry[ddlPCountry.selectedIndex].value;
        var PPhoneCode = document.getElementById('profileArea_txtPPhoneCode').value;
        var PPhoneNumber = document.getElementById('profileArea_txtPPhoneNumber').value;



        var validatestring = "";



        if (ddlPCountryValue == "0" || ddlPCountryValue == "") {
            validatestring += "Please Provide Location \n"
        }

        if (PPhoneCode == "Code*" || PPhoneCode == "") {
            validatestring += "Please Provide Phone Code \n"
        }

        if (PPhoneNumber == "Phone Number*" || PPhoneNumber == "") {
            validatestring += "Please Provide Phone Number \n"
        }




        if (validatestring != "") {
            alert(validatestring);
            return false;
        }


        var expRegex = /^\d+$/;
        if (!expRegex.test(PPhoneNumber)) {
            // validatestring += "Your Phone number seems incorrect \n";

            alert("Your Phone number seems incorrect \n");
            return false;
        }

        return true;
    }




    function BContactInfo() {


        var ddlPCountry = document.getElementById('profileArea_ddlCLocation');
        var ddlPCountryValue = ddlPCountry[ddlPCountry.selectedIndex].value;
        var PPhoneCode = document.getElementById('profileArea_txtCLPhoneCode').value;
        var PPhoneNumber = document.getElementById('profileArea_txtCLPhoneNumber').value;



        var validatestring = "";



        if (ddlPCountryValue == "0" || ddlPCountryValue == "") {
            validatestring += "Please Provide Location \n"
        }

        if (PPhoneCode == "Code*" || PPhoneCode == "") {
            validatestring += "Please Provide Phone Code \n"
        }

        if (PPhoneNumber == "Phone Number*" || PPhoneNumber == "") {
            validatestring += "Please Provide Phone Number \n"
        }




        if (validatestring != "") {
            alert(validatestring);
            return false;
        }


        var expRegex = /^\d+$/;
        if (!expRegex.test(PPhoneNumber)) {
            // validatestring += "Your Phone number seems incorrect \n";

            alert("Your Phone number seems incorrect \n");
            return false;
        }

        return true;
    }



    function BPersonalInfo() {

        var CompanyName = document.getElementById('profileArea_txtCompanyName').value;
        var CompanyWebsite = document.getElementById('profileArea_txtCompanyWebsite').value;
        var Industry = document.getElementById('profileArea_txtIndustry').value;
        var RepresentativeName = document.getElementById('profileArea_txtRepresentativeName').value;
        var ddlEstimatedEmployees = document.getElementById('profileArea_ddlEstimatedEmployees');
        var ddlEstimatedEmployeesValue = ddlEstimatedEmployees[ddlEstimatedEmployees.selectedIndex].value;


        var validatestring = "";

        if (CompanyName == "Company Name *" || CompanyName == "") {
            validatestring += "Please Provide Company Name \n"
        }

        if (CompanyWebsite == "Company Website *" || CompanyWebsite == "") {
            validatestring += "Please Provide Company Website \n"
        }

        if (Industry == "Industry *" || Industry == "") {
            validatestring += "Please Provide Industry \n"
        }

        if (RepresentativeName == "Representative Name *" || RepresentativeName == "") {
            validatestring += "Please Provide Representative Name \n"
        }

        if (ddlEstimatedEmployeesValue == "0" || ddlEstimatedEmployeesValue == "-1") {
            validatestring += "Please Provide Estimated Employees \n"
        }


        if (validatestring != "") {
            alert(validatestring);
            return false;
        }


        return true;
    }




    function ResetPassword() {

        var CurrentPassword = document.getElementById('txtCurrentPassword').value;
        var Password = document.getElementById('txtNewPassword').value;
        var ConfirmPassword = document.getElementById('thepassword').value;

        var validatestring = "";

        if (CurrentPassword == "Current Password *" || CurrentPassword == "") {
            validatestring += "Please Provide Current Password \n"
        }

        if (Password == "New Password *" || Password == "") {
            validatestring += "Please Provide New Password \n"
        }

        if (ConfirmPassword == "Confirm Password *" || ConfirmPassword == "") {
            validatestring += "Please Provide Confirm Password \n"
        }



        if (validatestring != "") {
            alert(validatestring);
            return false;
        }

        if (Password.length < 8) {
            alert("Short passwords are easy to guess. Try one with at least 8 characters.");
            return false;
        }

        if (Password != ConfirmPassword) {
            alert("Password does not match");
            return false;
        }


        return true;
    }
		
		
		
		
		
</script>
<!--<script type="text/javascript">
     function ResetPassword() {


              var CurrentPassword = document.getElementById('profileArea_txtCurrentPassword').value;
              var Password = document.getElementById('profileArea_txtNewPassword').value;
              var ConfirmPassword = document.getElementById('profileArea_thepassword').value;

              var validatestring = "";

              if (CurrentPassword == "CurrentPassword*" || CurrentPassword == "") {
                   validatestring += "Please Provide Email \n"
              }

              if (Password == "New Password*" || Password == "") {
                  validatestring += "Please Provide Password \n"
              }

              if (ConfirmPassword == "Confirm Password*" || ConfirmPassword == "") {
                  validatestring += "Please Provide Confirm Password \n"
              }



              if (validatestring != "") {
                  alert(validatestring);
                  return false;
              }

              if (Password != ConfirmPassword) {
                  alert("Password does not match");
                  return false;
              }

              return true;
          }
 </script>
-->
<!--CoverPage -->
