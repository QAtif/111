// GOTO by Scroll
function goToByScroll(e) {
//    $("html,body").animate({ scrollTop: $(e).offset().top }, 1e3, "", function () { $(this).stop(true, true) })
}

// Global Variables
var eas = '',
	anmdur = 500;
$(document).ready(function (e) {
	
	$('.tabs_btns li a').click(function(){
			if($('.xjcarousel ul li').length <= 4){
			console.log('less 4');
			$('.perform-next').addClass('inactive');	
		}else{
			console.log('above 4');
			$('.perform-next').removeClass('inactive');	
		}	
		});
    // All Accosrdian
	$('body').delegate('.accord .acchead', 'click', function (e) {
        debugger
	    if (!$(e.target).hasClass('switchaccord')) {
	        if (!$(this).parent().hasClass('active')) {
	            $(this).parent('.accord').siblings().children('.accinside').slideUp(300);
	            $(this).parent().addClass('active').siblings().removeClass('active');
	            $(this).parent().children(".accinside").delay(300).stop(true, true).slideDown(anmdur, eas, function () { goToByScroll($(this)) });
	        } else {
	            $(this).parent().removeClass('active').find(".accord").removeClass('active');
	            $(this).parent().find(".accinside").stop(true, true).slideUp(anmdur, eas, function () { goToByScroll($(this)) });
	        }
	    }
	});
	
$("#demo-input-facebook-theme,#demo-input-facebook-theme1,#demo-input-facebook-theme2,#demo-input-facebook-theme3,#demo-input-facebook-theme4,#demo-input-facebook-theme5,#demo-input-facebook-theme6,.dift").tokenInput("http://shell.loopj.com/tokeninput/tvshows.php", {
						theme: "facebook"
		});	
		
		$('.skillsettoken').tokenInput("http://shell.loopj.com/tokeninput/tvshows.php", {
				theme: "facebook",
				placeholder: 'Enter Skill set..'
		});	
		
		$('.locationtoken').tokenInput("http://shell.loopj.com/tokeninput/tvshows.php", {
				theme: "facebook",
				placeholder: 'Select location'
		});	
	
	//$('.wrapit.topmenu.offeraproval input[type="text"]').hide();
var resetvar = 0;
$('.showsearchtxt').click(function(){
	var getli = $(this).closest('li.searchhidden');
   // alert(getli);
   
   
	if(resetvar == 0){
		$('.wrapit.topmenu.offeraproval input[type="text"]').fadeIn();
	getli.animate({
		'width': '272px'	
	},350).find('.placeholderWrap').fadeIn('slow');
	resetvar = 1;   
	}else{
		$('.wrapit.topmenu.offeraproval input[type="text"]').fadeOut();
	getli.animate({
		'width': '58px'	
	}).find('.placeholderWrap').fadeOut('fast');
	resetvar = 0;
	getli.find('.placeholderWrap').removeClass('placeholder-changed');
		getli.find('input[type="text"]').val('');
	}
     return false;
});






/*var tglview1 = 0;
$('.showsrchbox').click(function(){
	if(tglview1 == 0){
		$('.searcharea').stop(0,0).slideDown('slow');
		tglview1 = 1;
	}else{
		$('.searcharea').stop(0,0).slideUp('slow');
		tglview1 = 0;
	}
});*/

$('#selectall').change(function () {
	if ($(this).prop('checked')) {
		$('input').prop('checked', true);
	}else{
		$('input').prop('checked', false);
	}
});

$('.main-accrodian input, .user-detail input').change(function(){
	if($('#selectall').prop('checked')){
		$('#selectall').prop('checked', false);
	}
});

$('.accordsec .accordian-btn input[type="checkbox"]').change(function(){
	var gtprnt = $(this).closest('li').find('.accrodian-content input[type="checkbox"]');
	if($(this).prop('checked')){
		gtprnt.prop('checked',true);		
	}else{
		gtprnt.prop('checked',false);	
	}
	//gtprnt.prop('checked', true);
});

$('.accrodian-content input[type="checkbox"]').change(function(){
	if(!$(this).prop('checked')){
		$(this).closest('li').find('.accordian-btn input[type="checkbox"]').prop('checked', false);		
	}
});


$('#selectall').trigger('change');


$('#ShowOwnerContent').change(function () {

    $('.ActionBtns').hide();

    $('.ShowAllDataGrid').append('<div class="BodyLoader"><div class="LoaderAjaxImg"><img src="assets/images/ajax-loader.gif" alt="" /> </div></div>');
    setTimeout(function () {
        $('.main-wrapper').fadeIn();
        $('.BodyLoader').hide();
        $('.ShowAllDataGrid').css({
            'background': 'none'
        });
        $('.ActionBtns').fadeIn();
    }, 1000);

});

$(".ShowMainWrapper").click(function () {
    $('.ShowAllDataGrid').append('<div class="BodyLoader"><div class="LoaderAjaxImg"><img src="assets/images/ajax-loader.gif" alt="" /> </div></div>');

    setTimeout(function () {
        $('.main-wrapper').fadeIn();
        $('.BodyLoader').hide();
        $('.ShowAllDataGrid').css({
            'background': 'none'
        });
        $('.ActionBtns').fadeIn();
    }, 1000);
});


$('.accordian-btn').click(function () {
    $(this).closest('li').find('.tabs_btns li').removeClass('active');
    $(this).closest('li').find('.tab-panes > div').hide();
    var objextx = $(this).parent();
    if (!$('.accordian-btn', objextx).hasClass('actived')) {

        $('.user-profile-warpper', objextx).hide();
        $('.profile-tabs-warper', objextx).hide();
        $('.user-profile-main', objextx).append(' <div class="user-profile-warpper-loader"><div class="LoaderAjaxImg"><img src="assets/images/ajax-loader.gif" alt="" />    </div></div> ');
        setTimeout(function () {
            $('.user-profile-warpper-loader', objextx).hide();
            $('.user-profile-warpper', objextx).show();
            $('.profile-tabs-warper', objextx).show();
        }, 1000);

    } else {

    }

});

var tglview = 0;
$('#btnSearchF a').click(function(){
	if(tglview == 0){
		$(this).text('Hide Advanced Search');
		$('#fresh-search-div').stop(0,0).slideDown('slow');
		console.log('fresh');
		tglview = 1;
	}else{
		$(this).text('Show Advanced Search');
		$('#fresh-search-div').stop(0,0).slideUp('slow');
		tglview = 0;
	}
});

var tglview1 = 0;
$('#btnSearchE a').click(function(){
	if(tglview1 == 0){
		$(this).text('Hide Advanced Search');
		$('#experienced-search-div').stop(0,0).slideDown('slow');
				$('#btnSearchF').hide();
				console.log('expe');
		tglview1 = 1;
	}else{
		$(this).text('Show Advanced Search');
		$('#experienced-search-div').stop(0,0).slideUp('slow');
		tglview1 = 0;
	}
});


//$('#btnSearchE').hide();
$('.TopLeftMenu li a').click(function () {
		
		
		//$('.toogleview').text('Show Advanced Search');
        
		$('.advancedsearch').hide();
        $('.TopLeftMenu li a').removeClass('active');
        $(this).addClass('active');
        var getdatarel = $(this).data('rel');
		
		$('.InsideSearchBox #'+getdatarel).hide();
		       
       /* $('#searcharea').find('div').each(function (index, element) { 
            var getid = $(this).attr("id");
            if (getid == 'fresh-search' || getid == 'experienced-search')
            {
				if (getid == getdatarel) {           
					$('#' + getid).show();          
				}else
					$('#' + getid).hide();
				}
			
			
			
        });
		*/
		if(getdatarel == 'fresh-search-div'){
				console.log('f');	
				$('#btnSearchF').show();
				$('#btnSearchE').hide();
				$('#btnSearchF a').text('Show Advanced Search');
				tglview = 0;	
			}else if(getdatarel == 'experienced-search-div'){
				console.log('E');	
				$('#btnSearchF').hide();
				$('#btnSearchE').show();
				$('#btnSearchE a').text('Show Advanced Search');
				tglview1 = 0;
			}
     
    });
	
	$('.TabsBoxes .box .toggle-history').click(function(){
		$(this).parent().find('.historytbl').slideToggle();	
		$(this).toggleClass('activehis');	
	});
	
	
$('.poptheform').fancybox({
	fitToView	: false,
	autoDimensions: true,
	height: 'auto',
	width: 'auto',
	autoSize	: false,
	openEffect	: 'none',
	closeEffect	: 'none',
	padding : 0,
	'closeBtn': false,	
	helpers : {
            title : null            
        }, 
	afterShow: function(){
		$.fancybox.update();
	}
});
	
	
$.fancybox.update(function(){
	width = $('.fancybox-outer').find('.poptheformbody').width();
	height = $('.fancybox-outer').find('.poptheformbody').height();
	$('.fancybox-inner').css('overflow','hidden');
});

$('.tabs_btns li.even a').click( function(){
  	var objextxx = $(this).parent().parent().parent();
  	if (!$('.tabs_btns li', this).hasClass('active')){
	
	$( '.t-performance-trends', objextxx).append('<div class="tabsLoader"><div class="LoaderAjaxImg"><img src="assets/images/ajax-loader.gif" alt="" />    </div></div>');
	$( '.performance-left', objextxx).hide();
	$( '.performance-right', objextxx).hide();
		 setTimeout(function(){
						$('.tabsLoader', objextxx).hide();
						$( '.performance-left', objextxx).show();
						$( '.performance-right', objextxx).show();	
				},1000);
	} else {

	}

});
			
$('.tabs_btns li.odd a').click( function(){
	var objextxx = $(this).parent().parent().parent();
	if (!$('.tabs_btns li', this).hasClass('active')){
		
		$( '.t-growth', objextxx).append('<div class="tabsLoader"><div class="LoaderAjaxImg"><img src="assets/images/ajax-loader.gif" alt="" />    </div></div>');
		$( '.growth-jcarousel-wrapper', objextxx).hide();
		$( '.t-growth h5', objextxx).hide();
		
			 setTimeout(function(){
							$('.tabsLoader', objextxx).hide();
							$( '.growth-jcarousel-wrapper', objextxx).show();
							$( '.t-growth h5', objextxx).show();
							
					},1000);
				
				
		} else {
				
		}

});	

$('.tabs_btns li.even a').click( function(){
				var objextxx = $(this).parent().parent().parent();
				if (!$('.tabs_btns li', this).hasClass('active')){
					
					
					$( '.t-performance-trends', objextxx).append('<div class="tabsLoader"><div class="LoaderAjaxImg"><img src="assets/images/ajax-loader.gif" alt="" />    </div></div>');
					$( '.performance-left', objextxx).hide();
					$( '.performance-right', objextxx).hide();
						 setTimeout(function(){
										$('.tabsLoader', objextxx).hide();
										$( '.performance-left', objextxx).show();
										$( '.performance-right', objextxx).show();	
								},1000);
								
								//$(this).unbind('click');
								
							
					} else {
				
					}

			});
			
			  $('a.view-comment',this).qtip({
         show: 'click',
         hide: 'unfocus',
		 style: {
        tip: {
            corner: true
        }	
    }, position: {
        my: 'bottom left',  // Position my top left...
        at: 'top right', // at the bottom right of...
       
    }
     });



/* Text box input field for IE */
if ($.browser.msie && $.browser.version <= 9) {
    $('input[type="text"], input[type="password"], input[type="email"]').each(function () {
        var txtvalue = $(this).attr('placeholder');
        $(this).attr('value', txtvalue)
    });
    $('input[type="text"], input[type="password"], input[type="email"]').focus(function () {
        var maintxt = $(this).attr('placeholder');
        if ($(this).attr('value') == maintxt) {
            $(this).attr('value', '')
        }
    }).blur(function () {
        var maintxt = $(this).attr('placeholder');
        if ($(this).attr('value') == '') {
            $(this).attr('value', maintxt)
        }
    })
}
/* Text box input field for IE */

var resetbox = 0;
$('.t-comments .carousel-box a').click(function(){
	if(resetbox == 0){
		$(this).closest('.grade-join.right-side').find('.visiblemore').show();
		var gtheight = $(this).closest('.grade-join.right-side').innerHeight();
		$(this).closest('.carousel-box').stop(0,0).animate({ 'height': gtheight+'px' });
		$(this).closest('.xjcarousel li').stop(0,0).animate({ 'height': parseInt(gtheight+20)+'px' });
		//$(this).closest('.growth-jcarousel-wrapper').stop(0,0).animate({ 'height': parseInt(gtheight+40)+'px' });
		//$(this).closest('.t-comments').stop(0,0).animate({ 'height': parseInt(gtheight+52)+'px' });
		$(this).text('less');
		resetbox = 1;
	}else{
		$(this).closest('.grade-join.right-side').find('.visiblemore').hide();
		$(this).closest('.carousel-box').stop(0,0).animate({ 'height': '108px' });
		$(this).closest('.xjcarousel li').stop(0,0).animate({ 'height': '135px' });
		//$(this).closest('.growth-jcarousel-wrapper').stop(0,0).animate({ 'height': '135px' });
		//$(this).closest('.t-comments').stop(0,0).animate({ 'height': '165px' });
		$(this).text('more');
		resetbox = 0;
	}
});

$('nav > ul > li > ul, #autowrap ul').perfectScrollbar();

});


function CloseModal() {
    $('.popcls').trigger('click');
    $('.ShowAllDataGrid').append('<div class="BodyLoader"><div class="LoaderAjaxImg"><img src="assets/images/ajax-loader.gif" alt="" /> </div></div>');
    setTimeout(function () {
        $('.main-wrapper').fadeIn();
        $('.BodyLoader').hide();
        $('.ShowAllDataGrid').css({
            'background': 'none'
        });
        $('.ActionBtns').fadeIn();
    }, 1000);

}
/* Close frame and open uploaded files  */
function CloseModalUpload() {
    $('.popcls').trigger('click');

    setTimeout(function () {

        $('.UploadButton').trigger('click');
    }, 500);

}




 $('.popnewform').live("click", function () {
        var e = $(this).attr("data-rel");
        $.fancybox({
            autoScale: false,
            width: 1000,
            minHeight: 490,
            openSpeed: 500,
            type: "iframe",
            overlayColor: "#000",
            padding: 0,
            href: e,
            centerOnScroll: false
        })
    });

/*$('.poptheform').fancybox({
	fitToView	: false,
	autoDimensions: true,
	height: 'auto',
	width: 'auto',
	autoSize	: false,
	openEffect	: 'none',
	closeEffect	: 'none',
	padding : 0,
	'closeBtn' : false,
	helpers : {
            title : null            
        }, 
	afterShow: function(){
		$.fancybox.update();
	}
});*/
	
	
$.fancybox.update(function(){
	width = $('.fancybox-outer').find('.poptheformbody').width();
	height = $('.fancybox-outer').find('.poptheformbody').height();
	$('.fancybox-inner').css('overflow','hidden');
});

$('.controllers li a').click(function(){
	$('.TabsBoxes .box').removeClass('active');
	$('.controllers li a').removeClass('active');
	
	$(this).addClass('active');
	var getdiv = $(this).data('rel');
	$('.TabsBoxes').find('.box-'+getdiv).addClass('active');
});

$('.innController li a').click(function(){
	$('.innContainer .innBox').removeClass('active');
	$('.innController li a').removeClass('active');
	
	$(this).addClass('active');
	var getdiv = $(this).data('rel');
	$('.innContainer').find('.box-'+getdiv).addClass('active');
});










