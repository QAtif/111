$(function() {
	$('button').tooltip({
		container: 'body'
		});	
		 $('#dragger').unbind('click');
	
	// below this all are defer function
	//__________________________________________________________________________________________________________________________________________________________________//
	
	//close all menus
	$('html').click(function() {
	  $('.XProMenu').slideUp();
	   $('#xprofile-menu>div>a').removeClass('active');
	   $('.xHiddenTable2,.xHiddenTable').fadeOut();
	});
	
	$('select,input,textarea').click(function(eve) {
		eve.stopPropagation();
	});
	// notification bar comes in after 2 secs	
	var notification = setTimeout(function(){$('.notification').slideDown();},2000);
	
	// click to hide the notification bar.
	$('.xclose').on('click',function() {
		$(this).parent('div').slideUp();
		
	});
	
	// show/hide profile menu
	$('#xprofile-menu>div>a').click(function(event) {
		event.stopPropagation();
		$(this).next('div.XProMenu').slideToggle();
		$(this).toggleClass('active');
	});
	
	//show Profile Display Picture menu
	$('.XdpMneuactivate').click(function(event) {
		event.stopPropagation();
		$(this).next('div.XdpMneu').slideToggle();
	});
	
	//hide profile hd menu 
	$('#xdp').mouseleave(function() {
		$(this).children('.XdpMneu').hide();
	});
	
	//show Cover Photo menu
	$('.XcoverMneuactivate').click(function(event) {
		event.stopPropagation();
		$(this).next('div.XdpMneu').slideToggle();
	});
	
	//hide Cover Photo menu
	$('#xcover').mouseleave(function() {
		$(this).children('.XdpMneu').hide();
	});
	
	//Initiate reposition sequence
	var theclick =0;
	
	$('#reposition').click(function(event) {
		event.stopPropagation();
		$('#dragger').fadeIn();
		theclick =1;		 
		 if(theclick==1){
			$( "#xcoverInner img" ).draggable( "option", "disabled", false);
		 }		 
	});
	
	// reposition my cover
	
	
	$("#xcoverInner img").draggable({		
		stop: function(ev, ui) {
			var hel = ui.helper, pos = ui.position;
			//horizontal
			var h = -(hel.outerHeight() - $(hel).parent().outerHeight());
			if (pos.top >= 0) {
				hel.animate({ top: 0 });
			} else if (pos.top <= h) {
				hel.animate({ top: h });
			}
			// vertical
			var v = -(hel.outerWidth() - $(hel).parent().outerWidth());
			if (pos.left >= 0) {
				hel.animate({ left: 0 });
			} else if (pos.left <= v) {
				hel.animate({ left: v });
				
			}
			$('#dragger').hide();
			$('#dragger').css({
				'top':'155px',
				'left':'342px'
				});
			$( "#xcoverInner img" ).draggable( "option", "disabled", true );
		}
	});
	$( "#xcoverInner img" ).draggable( "option", "disabled", true );

	/* Modal Forms */

	$('.step-button-half').click(function(event) {
		event.stopPropagation();
		$('.step-button-half').removeClass('active');
		if($(this).hasClass('business')) {
			$('#Change-cat').attr('data-target','#myModal_StepB2');
		}
		else if($(this).hasClass('normal')) {
			$('#Change-cat').attr('data-target','#myModal_Step2');
		}
		$(this).addClass('active');
		$('#step-bar .bar').animate({ width: '33%' }, 500);
	});
 //$("#thepassword").complexify();
  

  $('.EditPro').click(function(event) {
	  event.stopPropagation();
	  $(window).scrollTop(0);
  		var offset = $(this).offset();
  		//alert(offset.left + 'top' + offset.top);
  		$('.xHiddenTable2,.xHiddenTable').fadeOut();
  		if($(this).hasClass('xRight')){
	  		$('.xHiddenTable2.xbox').css({
	  			'left': offset.left ,
	  			'top': offset.top ,
	  			'display':'block'
	  		});
	  	}
	  	else if($(this).hasClass('xLeft')){
	  		$('.xHiddenTable.xbox').css({
	  			'left': offset.left ,
	  			'top': offset.top ,
	  			'display':'block'
	  		});

	  	}
  });

		$("#thepassword").complexify({}, function (valid, complexity) {
            if (!valid) {
                $('#progress').css({'width':complexity + '%'}).removeClass('progressbarValid').addClass('progressbarInvalid');
            } else {
                $('#progress').css({'width':complexity + '%'}).removeClass('progressbarInvalid').addClass('progressbarValid');
            }
            $('#complexity').html(Math.round(complexity) + '% Strong');
        });
		
		$('.edit-profile').click(function() {
			$(window).scrollTop(0);
		})

});
 

function UpdateProBar(percent) {
	$('.bar').animate({ width: percent+'%' }, 500);
}