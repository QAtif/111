      $(document).ready(function() {
       
	   $(".click").click(function(){
       $('#joyRideTipContent').joyride();
	   $(".demo1").css("display","none");
	   $(".demo").css("display","block");
	   });
     });
	 
		
  	$(function() { 
		
		var $curr = $("#1");
		var $zurr = $(".num-1");
		$curr.css("display", "block");
		$zurr.css("z-index", "10001");
		
    $('a.joyride-next-tip').live("click", function(){ 
	
       $curr = $curr.next();
       $("ol li").css("display", "none");
       $curr.css("display", "block");

       $zurr = $zurr.next();
       $("#example1 li").css("z-index", "9999");
       $zurr.css("z-index", "10005");


		//$("#joyRideTipContent2 li").css("display","block");
		//alert("hellow");

		/*if (($('ol li').hasClass('last')) && ($('ol li').css('display') == 'block')) {
			
			$(".demo").css("display","none");
			$(".demo1").css("display","block");
			
		}*/
		
	$('.joyride-tip-guide.tip4').live("click", function(){ 
			
			$(".blueslashbg").addClass("show");
			
		});

	$('.joyride-tip-guide.tip6').live("click", function(){ 
			
			$(".demo").css("display","none");
			$(".demo1").css("display","block");
			
	});

	//	alert("hellow");
		});
});


	$(document).ready(function(){
		

$('#example1 li .hd2').click(function(){
			$(this).parent().children('.panel').toggle(250);
			$(this).parent().toggleClass('active');
		});

$('ul.panel li a').click(function() {
		$('.panes > div').hide();
        var relvalue = $(this).attr('rel'); 
		$('.panes .'+relvalue).show();
		//$('iframe').reload();
		
		//var gethref = $(this).attr('rel');
		//$('#frame1').attr('src',gethref);
		
		$('.panel li').removeClass('activeit');
			$(this).parent().addClass('activeit');
			$(this).parent().siblings().removeClass('activeit');
		
    });
	

});

/*function resizeIframe(dynheight)
{
	//document.getElementById("frame1").height=parseInt(dynheight);
}*/


