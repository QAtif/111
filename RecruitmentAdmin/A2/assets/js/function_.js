$(document).ready(function(e) {
	
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
	
var resetvar = 0;
$('.showsearchtxt').click(function(){
	var getli = $(this).closest('li.searchhidden');
   // alert(getli);
   
	if(resetvar == 0){
	getli.animate({
		'width': '272px'	
	},350).find('.placeholderWrap').fadeIn('slow');
	resetvar = 1;   
	}else{
		
	getli.animate({
		'width': '58px'	
	}).find('.placeholderWrap').fadeOut('fast');
	resetvar = 0;
	getli.find('.placeholderWrap').removeClass('placeholder-changed');
		getli.find('input[type="text"]').val('');
	}
     return false;
});



var tglview = 0;
$('#toogleviewF').click(function(){
	if(tglview == 0){
		$(this).text('Hide Advanced Search');
		$('#fresh-search').stop(0,0).slideDown('slow');
		tglview = 1;
	}else{
		$(this).text('Show Advanced Search');
		$('#fresh-search').stop(0,0).slideUp('slow');
		tglview = 0;
	}
});
var tglview = 0;
$('#toogleviewE').click(function(){
	if(tglview == 0){
		$(this).text('Hide Advanced Search');
		$('#experienced-search').stop(0,0).slideDown('slow');
		tglview = 1;
	}else{
		$(this).text('Show Advanced Search');
		$('#experienced-search').stop(0,0).slideUp('slow');
		tglview = 0;
	}
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

$('.TopLeftMenu li a').click(function () {
		tglview = 0;
		//tglview1 = 0;
		$('.toogleview').text('Show Advanced Search');
        $('.advancedsearch').hide();
        $('.TopLeftMenu li a').removeClass('active');
        $(this).addClass('active');
        var getdatarel = $(this).data('rel');       
        $('#searcharea').find('div').each(function (index, element) { 
            var getid = $(this).attr("id");
            if (getid == 'fresh-search' || getid == 'experienced-search')
            {
            if (getid == getdatarel) {           
                $('#' + getid).show();               
            }
            else
            $('#' + getid).hide();
            }

            if (getid=='fresh-search')
            {
             $('#btnSearchF').show();
              $('#btnSearchE').hide();
             }
             else
              if (getid=='experienced-search'){
             $('#btnSearchE').show();
              $('#btnSearchF').hide();
             }
          //   $('#fresh-search').hide();
           //  $('#experienced-search').hide();
        });
     
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
	'closeBtn' : false,
	helpers : {
            title : null            
        }, 
	afterShow: function(){
		$.fancybox.update();
	}
});
	
	
$.fancybox.update(function(){
	this.width = $('.fancybox-outer').find('.poptheformbody').width();
	this.height = $('.fancybox-outer').find('.poptheformbody').height();
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