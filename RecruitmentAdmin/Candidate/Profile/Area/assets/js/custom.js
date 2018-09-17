var verification_skip;
verification_skip=0;

$(function () {	
debugger;
    var hdnVal = $("#hdnValue").val();
	//if(verification_skip==1) {
    if(hdnVal=="1") {
		//alert('asdasd');
		$('#verification_skip').removeAttr('data-step');
		$('#verification_skip').removeAttr('data-position');
		$('#verification_skip').removeAttr('data-intro');
		$('.process-steps .crumbs li:nth-child(8)').remove();
	}
	
	//setting the side bar 
  $(document).scroll(function(){		  
		  var docHeight = $(document).height();
		  var bodyHeight = $('body').height();
		  var asideHeight = $('.aside').height();
		  

	  $(window).scroll(function(){		  
		  var docHeight = $(window).height();
		  var bodyHeight = $('body').height();
		  var asideHeight  = $('.aside').height();
		  //alert(asideHeight);
		  var XCrollPositon = $('#xnav').offset();
		  if(! XCrollPositon){
				  if($(this).scrollTop()>= 79){
					$('aside').css({
						'top':'0px',
						 'position': 'fixed',
						 'width': '303px',
						 'z-index': '550'
					});
					  }
				  
				 else {
					  $('aside').css({
						'top':'auto',
						 'position': 'relative',
						 'width':'auto'
					});
					
				  }
				  return;
		  }
			  XCrollPositon  = XCrollPositon.top+30;

		  		  
		  if($(this).scrollTop()>=XCrollPositon ){
			  if(docHeight >=672) return;
			  if(asideHeight <= docHeight){
			$('aside').css({
				'top':'80px',
				 'position': 'fixed',
				 'width': '302px',
				 'z-index': '550'
			});
			  }
			$('#xnavSc').fadeIn();
		  }
		 else if($(this).scrollTop()<=XCrollPositon){
			  $('aside').css({
				'top':'auto',
				 'position': 'relative',
				 'width':'auto'
			});
			$('#xnavSc').hide();
		  }
		  
		  

	});
	

	});
	//alert($('.notification').outerHeight());
	// Lockers carousal
		//$('.mycarousel').jcarousel();
		var thispos ;
	//tabs area 
	$('#myTab a').click(function (e) {
		e.preventDefault();
		$(this).tab('show');
	});
	
	$('form.xStyledForm').jqTransform({imgPath:'/Area/assets/css/img/'});
	$(window.location.hash).modal('show');
    $('button,a').tooltip({
        container: 'body'
    });
	$('span.xCustomTip').tooltip({
		delay: 0,
		animation: false,
		template: '<div class="tooltip myTip"><div class="tooltip-arrow"></div><div class="tooltip-inner"></div></div>'
		    });
    $('#dragger').unbind('click');

    // below this all are defer function
    //__________________________________________________________________________________________________________________________________________________________________//
	
	//xnav active classs 
	if(xPageELEM!=undefined && xPageELEM!='' ){
	$('#xnav li:nth-child('+xPageELEM+')').addClass('active');
	}

    //close all menus
    $('html').click(function () {
        $('.XProMenu').slideUp();
        $('#xprofile-menu>div>a').removeClass('active');
        $('.xHiddenTable2,.xHiddenTable').fadeOut();
    });
	$('.jqTransformSelectWrapper div span,label').click(function(eve) {
		 eve.stopPropagation();
	});

    $('select,input,textarea').click(function (eve) {
        eve.stopPropagation();
    });
    // notification bar comes in after 2 secs	
   /* var notification = setTimeout(function () {
        $('.notification').slideDown();
    }, 2000);   */

    // click to hide the notification bar.
    $('.xclose').click(function (event) {
		  event.stopPropagation();
        $(this).closest('div').slideUp();
    });

    // show/hide profile menu
    $('#xprofile-menu>div>a').click(function (event) {
		  event.stopPropagation();
        $(this).next('div.XProMenu').slideToggle();
        $(this).toggleClass('active');
    });

    //show Profile Display Picture menu
    $('.XdpMneuactivate').click(function (event) {
        event.stopPropagation();
        $(this).next('div.XdpMneu').slideToggle();
    });

    //hide profile hd menu 
    $('#xdp').mouseleave(function () {
        $(this).children('.XdpMneu').hide();
    });

    //show Cover Photo menu
    $('.XcoverMneuactivate').click(function (event) {
        event.stopPropagation();
        $(this).next('div.XdpMneu').slideToggle();
    });

    //hide Cover Photo menu
    $('#xcover').mouseleave(function () {
        $(this).children('.XdpMneu').hide();
    });

    //Initiate reposition sequence
    var theclick = 0;

    $('#reposition').click(function (event) {
        event.stopPropagation();
        $('#dragger').fadeIn();
		$('#xoptions,.XdpMneu').hide();
		$('#xCoverOptions').show();
		$('header > div:lt(2),#xnav,#main > div.row-fluid').not('#xdp *').fadeTo('slow', 0.5);
        theclick = 1;
        if (theclick == 1) {
            $("#xcoverInner img").draggable("option", "disabled", false);
        }
    });

    // reposition my cover
	var topValue;
	  var leftValue ;
    $("#xcoverInner img").draggable({
		 "axis": "y",
        stop: function (ev, ui) {
            var hel = ui.helper,
                pos = ui.position;
            //horizontal
            var h = -(hel.outerHeight() - $(hel).parent().outerHeight());
            if (pos.top >= 0) {
                hel.animate({
                    top: 0
                },function() {
					 topValue = $('#profileArea_draggable').position().top;
					 leftValue = $('#profileArea_draggable').position().left;
					$('#profileArea_coverImageTopPosition').attr('value', topValue);
					$('#profileArea_coverImageleftPosition').attr('value', leftValue);
				});
            } else if (pos.top <= h) {
                hel.animate({
                    top: h
                },function() {
					topValue = $('#profileArea_draggable').position().top;
					leftValue = $('#profileArea_draggable').position().left;
					$('#profileArea_coverImageTopPosition').attr('value', topValue);
					$('#profileArea_coverImageleftPosition').attr('value', leftValue);
				});
            }
			
					topValue = pos.top;
					leftValue =pos.left;
					$('#profileArea_coverImageTopPosition').attr('value', topValue);
					$('#profileArea_coverImageleftPosition').attr('value', leftValue);
					
            // vertical
            var v = -(hel.outerWidth() - $(hel).parent().outerWidth());
            if (pos.left >= 0) {
                hel.animate({
                    left: 0
                });
            } else if (pos.left <= v) {
                hel.animate({
                    left: v
                });

            }
            
			
            $('#dragger').css({
                'top': '155px',
                'left': '342px'
            });
		
           
        }
    });
    $("#xcoverInner img").draggable("option", "disabled", true);
	
	$('.edit-xCover').click(function(eve){
		eve.stopPropagation();
		$('#xoptions').show();
		$('header > div:lt(2),#xnav,#main > div.row-fluid').fadeTo('slow', 1);
		$('#xCoverOptions,#dragger').hide();
		 $("#xcoverInner img").draggable("option", "disabled", true);
		 $('#dragger').hide();
	});

    /* Modal Forms */

    $('.step-button-half').click(function (event) {
        event.stopPropagation();
        $('.step-button-half').removeClass('active');
        if ($(this).hasClass('business')) {
            $('#Change-cat').attr('data-target', '#myModal_StepB2');
        } else if ($(this).hasClass('normal')) {
            $('#Change-cat').attr('data-target', '#myModal_Step2');
        }
        $(this).addClass('active');
        $('#step-bar .bar').animate({
            width: '33%'
        }, 500);
    });
    //$("#thepassword").complexify();


    $('.EditPro').click(function (event) {
        event.stopPropagation();
        $(window).scrollTop(0);
        var offset = $(this).offset();
        //alert(offset.left + 'top' + offset.top);

        $('.xHiddenTable2,.xHiddenTable').fadeOut();
        if ($(this).hasClass('xRight')) {
            $('.xHiddenTable2.xbox').css({
                'left': offset.left,
                'top': offset.top,
                'display': 'block'
            });
        } else if ($(this).hasClass('xLeft')) {
            $('.xHiddenTable.xbox').css({
                'left': offset.left,
                'top': offset.top,
                'display': 'block'
            });

        }
    });

    $("#thepassword").complexify({}, function (valid, complexity) {
        if (!valid) {
            $('#progress').css({
                'width': complexity*3 + '%'
            }).removeClass('progressbarValid').addClass('progressbarInvalid');
        } else {
            $('#progress').css({
                'width': complexity*3 + '%'
            }).removeClass('progressbarInvalid').addClass('progressbarValid');
        }
		if(complexity*3 >= 100) {
			$('#complexity').html('100' + '% Strong');
		}
		else {
			$('#complexity').html(Math.round(complexity*3) + '% Strong');
		}
		
        
    });

    $('.edit-profile').click(function () {
        $(window).scrollTop(0);
    });
	
	$('.activeSearch,#searchBar button.close').click(function(event){
		  event.stopPropagation();
		$('#searchBar').fadeToggle();
	});
	

    $('#xFriendSearch').focus(function() {
        $(".xtext-search-hint").slideDown();
        //alert('khalid');
    }).blur(function() {
		$(".xtext-search-hint").slideUp();
	});
		$('#profeExpList li a.loadExp').click(function(eve) {
			eve.stopPropagation();			
			$(this).parent().addClass('active');
			$(this).parent().siblings().removeClass('active');
			$(".LoadingImage").fadeIn();
			$('#profeExp').removeClass('hidden');
			$('#profeExpCheck').slideUp();
			$('#XExpForm input[name=cname]').val(applicantProfessionalExp[0].cname);
			$('#XExpForm input[name=cweb]').val(applicantProfessionalExp[0].cweb);
			$('#XExpForm input[name=cadd]').val(applicantProfessionalExp[0].cadd);
			$('#XExpForm input[name=jtitle]').val(applicantProfessionalExp[0].jtitle);
			$('#XExpForm input[name=jstatus]').prop('checked',false);
			
			$('#XExpForm input[name="jstatus"][value="'+applicantProfessionalExp[0].jstatus+'"]').attr('checked',true).prev().addClass('jqTransformChecked');
			
			$('#XExpForm textarea[name=responsibilities]').val(applicantProfessionalExp[0].responsibilities);
			$('#XExpForm input[name=csalary]').val(applicantProfessionalExp[0].csalary);
			$('#XExpForm input[name=isalary]').val(applicantProfessionalExp[0].isalary);

			$('#XExpForm input[name="cashowance"][value="'+applicantProfessionalExp[0].cashowance.fuel+'"]').attr('checked',true).prev().addClass('jqTransformChecked');
			$('#XExpForm input[name="cashowance"][value="'+applicantProfessionalExp[0].cashowance.mobile+'"]').attr('checked',true).prev().addClass('jqTransformChecked');
			$('#XExpForm input[name="cashowance"][value="'+applicantProfessionalExp[0].cashowance.vacations+'"]').attr('checked',true).prev().addClass('jqTransformChecked');
			$('#XExpForm input[name="cashowance"][value="'+applicantProfessionalExp[0].cashowance.other+'"]').attr('checked',true).prev().addClass('jqTransformChecked');
			
			$(".LoadingImage").fadeOut();
			
		});
		
		//Profile EDUCATION AREA
		$('#profeEduList li a.loadEDU').click(function(eve) {
			eve.stopPropagation();			
			$(this).parent().addClass('active');
			$(this).parent().siblings().removeClass('active');
			$(".LoadingImage").fadeIn();
			$('#profeExp').slideUp().slideDown().removeClass('hidden');
			$(".LoadingImage").fadeOut();
			
		});
		
		//Profile Diploma  AREA
		$('#profeDipList li a.loadDip').click(function(eve) {
			eve.stopPropagation();			
			$(this).parent().addClass('active');
			$(this).parent().siblings().removeClass('active');
			$(".LoadingImage").fadeIn();
			$('#profeDip').slideUp().slideDown().removeClass('hidden');
			$(".LoadingImage").fadeOut();
			
		});
		
		//Profile CERTIFICATION  AREA
		$('#profeCerList li a.loadCer').click(function(eve) {
			eve.stopPropagation();			
			$(this).parent().addClass('active');
			$(this).parent().siblings().removeClass('active');
			$(".LoadingImage").fadeIn();
			$('#profeCer').slideUp().slideDown().removeClass('hidden');
			$(".LoadingImage").fadeOut();
			
		});
		
		// ADD  MORE TO FOLIO LINKS\
		var PortItem = ' <div class="row-fluid item">\
                      <div class="span3 offset1">\
                        <input type="text" class="jqtranformdone" value="Blogger Portfolio" >\
                      </div>\
                      <div class="span6">\
                        <input type="text" class="jqtranformdone" value="blogspot.com/aradoswriting" >\
                      </div>\
                      <div class="span1">\
                         <button class="btn btn-small xAddMore" type="button"><img src="/Area/assets/img/plus.png" alt=""></button>\
                      </div>\
                    </div>';
	
		$('.item').delegate('button.xAddMore',"click",function (eve) {
			eve.stopPropagation();	
			$(this).empty().html('<img alt="" src="/Area/assets/img/minus.jpg">').addClass('xRemove').removeClass('xAddMore');
			$(this).parent().after(PortItem);
			//$('#xportArea').append(PortItem);
		});
		$('.item').on('click','button.xRemove', function() {
			//alert($(this).parent().parent().html());
			$(this).parent().parent().remove();
			
		});
		
		
//	//INput Focus Script
//	$('input:text,textarea,input:password').each(function() 
//	//find ALL 'input', 'textarea' and 'password' fields on the page
//	{
//		var txtvalue = this.value; //save default value in variable
//		$(this).delegate($(this),'focus',function() {
//			if(this.value == txtvalue) //if field is focused
//		{
//			this.value = ''; //then hide text on focus
//		}
//	});
//	$(this).delegate($(this),'blur',function() //if field is unfocused,
//	{
//		if(this.value == '') //and value is empty
//		{
//		this.value = txtvalue; //then fill back the default value.
//		}
//	});
//	});
	
	$('#thefriends li').hover(function() {
		$(this).find('.xFdetail').fadeIn();
	},function() {
		$(this).find('.xFdetail').hide();		
	});
	
	$('#thefriends2 li .btn-primary').click(function() {
		$(this).next('.xFdetail').fadeToggle();
	});
	
	$('.taglinks a').on('click',function(){
		$(this).parent().remove();
	});
	
	
	//Skill Script 
	
	$('#xTypeSkill').keydown(function() {
		$('#xSelectSkill').slideDown();
	})
	
	$('#xAddSkill').click(function() {
			$('#xSelectSkill').slideUp();
			$('#xSkillArea').append(' <span class="taglinks">Graphic Design <a href="javascript:;" title="" ></a></span> <span class="taglinks">Web Design <a href="javascript:;" title=""></a></span> <span class="taglinks">Motion Graphics <a href="javascript:;" title=""></a></span>');
	});
	//$('#xSkillArea')
	
	$('input[name=profe]').click(function() {
		if($(this).attr('rel') == '1') { 
			 $('#profeExp').removeClass('hidden');
		} else {	
				$('#profeExp').addClass('hidden');				
		}
	});
	
	$('input[name=dip]').click(function() {
		if($(this).attr('rel') == '1') { 
			 $('#profeDip').removeClass('hidden');
		} else {	
				$('#profeDip').addClass('hidden');				
		}
	});
	
	$('input[name=expercer]').click(function() {
		if($(this).attr('rel') == '1') { 
			 $('#profeCer').removeClass('hidden');
		} else {	
				$('#profeCer').addClass('hidden');				
		}
	});
	
	
	$('input[name=portf]').click(function() {
		if($(this).attr('rel') == '1') { 
			 $('#profePort').removeClass('hidden');
		} else {	
				$('#profePort').addClass('hidden');				
		}
	});
	
	$('input[name=medium]').click(function() {
		if($(this).attr('rel') == '1') { 
			 $('#xAxactian').removeClass('hidden');
			 $('#xRefDetails').addClass('hidden');
		} else 	if($(this).attr('rel') == '2') {	
			 $('#xAxactian').addClass('hidden');
			 $('#xRefDetails').removeClass('hidden');			
		}else {
			 $('#xAxactian').addClass('hidden');
			 $('#xRefDetails').addClass('hidden');	
		}
	});
	
$('#xSelectEduLevel').change(function() {
		$('#xMasrksArea > div').hide(); $('#xMasrksArea > div:nth-child('+$(this).val()+')').show();
		if($(this).val()==2) {
			$('.xBoardName').show();
		}
		else {
				$('.xBoardName').hide();
		}
	});
	
	$('.xTypeToShow').focus(function() {
		$('#xMajorsArea').show();
	});
	
});




function UpdateProBar(percent) {
    $('.bar').animate({
        width: percent + '%'
    }, 500);
	$('#XproGWidth').width($('.bar').width());
}

// SCRIPTING FOR HIDE/SHOW FORMS UNIVERSAL FUNCTION

function checkmate(tohandle,query) {
	if(query =='hide') {
	   $('#'+tohandle).addClass('hidden');
	     console.log(query);
	}
	else {
			  console.log(query);
		$('#'+tohandle).removeClass('hidden');
	}
	
}

function targetTab(tabID,tabnumber) {
	UpdateProBar(tabnumber*10);
	$('.tab-content .tab-pane ').removeClass('active');
	$('#'+tabID).addClass('active');
	$('#myTab li').removeClass('active');
	$('#myTab li:nth-child('+tabnumber+')').addClass('active');
	tabnumber = tabnumber-1;
	$('#myTab li:nth-child('+tabnumber+')').addClass('completed');
	
}

function showEditables(edit){
	$('#'+edit).fadeIn();
	$('#'+edit).removeClass('hidden');
}

////JSON DATA STARTS HERE ############################# DONOT EDIT BELOW THIS LINE ########################


var applicantProfessionalExp = [ {
	'cname' : 'Axact',
	'cweb':'http://www.axact.com',
	'cadd' : 'Axact House Karachi',
	'jtitle' : 'Engineer',
	'jstatus':'1',
	'responsibilities' : 'Making ERP',
	'durationFM' : '3',
	'durationFY' : '2012',
	'durationTm' :'4',
	'durationTY' :'2013',
	'csalary' : '5000',
	'csalary' : '5000',
	'isalary' : '5000',
	'cashowance' : {
		'fuel':'0',
		'mobile':'1',
		'vacations':'2',
		'other':'0',
		},
	'lstyle' : '5000',
	'odays' : '7',
}
]

var applicantEducationExp = [ {
	'iname' : 'KU',
	'education':'I.Com',
	'cadd' : 'Axact House Karachi',
	'fstudy' : 'BA',
	'majors' : 'marketing',
	'durationF' : '2012',
	'durationT' :'2013',
	'mscored' : '0% 3.9',
	'grades' : 'A',
	'position' : 'No',
	'eca' : 'playing and doing nothing',
}
]

var applicantDiplomaExp = [ {
	'iname' : 'KU',
	'education':'I.Com',
	'cadd' : 'Axact House Karachi',
	'fstudy' : 'BA',
	'majors' : 'marketing',
	'durationF' : '2012',
	'durationT' :'2013',

}
]

var applicantCertificationExp = [ {
	'iname' : 'KU',
	'ctitle':'CS',
	'fstudy' : 'BSCS',
	'durationFM' : 'March',
	'durationF' : '2012',
	'durationTm' :'April',
	'durationT' :'2013',

}
]

var applicantCertificationExp = [ {
	'Aysoe' : 'graphic Design',
}
]

var applicantportfolioExp = [ {
	'Atfile' : 'writing.docx',
	'AddUrlBehancePortfolio':'behance.net/aradosmarkachanda',
	'AddUrlBloggerPortfolio':'blogspot.com/aradoswriting',
	'Title':'URL',

}
]

var applicantCertificationExp = [ {
	'Yname' : 'Asan',
	'Gender':'M',
	'DOB' : 'march 2 1987',
	'MStatus' : 'Single',
	'Nationality' : 'Pakistani',
	'CNIC' :'1234512345678',
	'Religion' :'Muslim',
	'SAvailability' :'Morning',
	'Mnumber' :'0300 889 7789',
	'LandlineNumber' :'0213-4445557',
	'EmailAddress' :'asan@axact.com',
	'Address' :'xyz',

}
]
var applicantWDYHAaxactExp = [ {
	'SMedium' : 'Axact website',
	'AxactN':'asan',
	'Department' : 'UI',
	'Rcode' : 'D2',
	'Nationality' : 'Pakistani',
	'CNIC' :'1234512345678',
	'Religion' :'Muslim',
	'SAvailability' :'Morning',
	'Mnumber' :'0300 889 7789',
	'LandlineNumber' :'0213-4445557',
	'EmailAddress' :'asan@axact.com',
	'Address' :'xyz',

}
]



////JSON DATA ENDS HERE


//Drag Element Fucntionallity
var newval;
var oldvar;
 $(document).ready(function () { 
 
  $('.timeline ul').jcarousel({
	      scroll:1
	  });
  
	$('.timeline .jcarousel-prev').append('<div style="display:block; width:100%; height:100%;" class="xTheclickPrev" ></div>');
	$('.timeline .jcarousel-next').append('<div style="display:block; width:100%; height:100%;" class="xTheclickNext" ></div>');
	
  $('.timeline .jcarousel-next .xTheclickNext').hover(function() {
	  if($(this).parent().siblings('.jcarousel-clip').children(' ul').children('li').size()>3){
	  $(this).parent().siblings('.jcarousel-clip').children(' ul').stop().stop().animate({'margin-left':-20});	  
	  }
   },function() {	  
	 $(this).parent().siblings('.jcarousel-clip').children(' ul').stop().stop().animate({'margin-left':0});
   });
   
   $('.timeline .jcarousel-prev .xTheclickPrev').hover(function() {
    if($(this).parent().siblings('.jcarousel-clip').children(' ul').children('li').size()>3){
	 $(this).parent().siblings('.jcarousel-clip').children(' ul').stop().stop().animate({'margin-left':20});
	  }
   },function() {	  
	 $(this).parent().siblings('.jcarousel-clip').children(' ul').stop().stop().animate({'margin-left':0});
   });

   
 	/*	$('.suggestmore ul').width($(this).innerWidth()+540);
        $('.timeline').mousedown(function (event) {
            $(this)
                .data('down', true)
                .data('x', event.clientX)
                .data('scrollLeft', this.scrollLeft);
                
            return false;
        }).mouseup(function (event) {
            $(this).data('down', false);
        }).mousemove(function (event) {
            if ($(this).data('down') == true) {
                this.scrollLeft = $(this).data('scrollLeft') + $(this).data('x') - event.clientX;
            }
        }).mousewheel(function (event, delta) {
            this.scrollLeft -= (delta * 30);
        });
    });
  
   
    $(window).mouseout(function (event) {
        if ($('.timeline').data('down')) {
            try {
                if (event.originalTarget.nodeName == 'BODY' || event.originalTarget.nodeName == 'HTML') {
                    $('.timeline').data('down', false);
                }                
            } catch (e) {}
        }  */
		
		
		$('#chkPresent').click(function(eve) {
			eve.stopPropagation();
			if($(this).attr('checked')=='checked'){
				$('.xSetDisableExp').show();
				$('.xSetDisableExp2').hide();
			}
			else {
				$('.xSetDisableExp').hide();
				$('.xSetDisableExp2').show();
			}
		});
		
		
		$('#chkEducationStatus').click(function(eve) {
			eve.stopPropagation();
			if($(this).attr('checked')=='checked'){
				$('.xSetDisable select').removeAttr('disabled');
				$('.xSetDisable .jqTransformSelectWrapper').removeClass('xDisallow');
			}
			else {
				$('.xSetDisable select').attr('disabled','disabled');
				$('.xSetDisable .jqTransformSelectWrapper').addClass('xDisallow');
				
			}
		});
		
		$('.xCheckDipCurrent').click(function(eve) {
			eve.stopPropagation();
			if($(this).attr('checked')=='checked'){
				$('.xSetDisableDip select').removeAttr('disabled');
				$('.xSetDisableDip .jqTransformSelectWrapper').removeClass('xDisallow');
			}
			else {
				$('.xSetDisableDip select').attr('disabled','disabled');
				$('.xSetDisableDip .jqTransformSelectWrapper').addClass('xDisallow');
				
			}
		});
		
		$('.xCheckCerCurrent').click(function(eve) {
			eve.stopPropagation();
			if($(this).attr('checked')=='checked'){
				$('.xSetDisableCer select').removeAttr('disabled');
				$('.xSetDisableCer .jqTransformSelectWrapper').removeClass('xDisallow');
			}
			else {
				$('.xSetDisableCer select').attr('disabled','disabled');
				$('.xSetDisableCer .jqTransformSelectWrapper').addClass('xDisallow');
				
			}
		})
		
		
		
    });
	
	// infrkandjkbashmnkd bnasjdv asd
	
	$(document).ready(function() {		 
		 $("#start-demo").click(function(){
				 $(".hide-tour-div").fadeIn('fast'); 
				 $('.notification').hide();
				setTimeout(function() {			
				introJs().start();
				},500);
		  }); 
			  
		 $(".xend-tour").click(function(){
			 introJs().exit();
			 $(".hide-tour-div").hide(); 
		 });
		
		$('ul.crumbs li a').on('click', changeClass);		 
});
function changeClass() {
    $('ul.crumbs li').removeClass('selected');
    $(this).parent().addClass('selected');
}

function setDelaybet(itemindex) {
	introJs().exit();
	setTimeout(function() {
		introJs().goToStep(itemindex).start();
	},1000);
}


$(document).ready(function() {	
	$("#start-demo").click(function(){
		$("html,body").animate({
			scrollTop: $(window).scrollTop() + 185
		});		
	});
});	

