// JavaScript Document

$(function(){
			$('form').jqTransform({imgPath:'assets/jqtransformplugin/img/'});
		});
function MM_jumpMenu(targ,selObj,restore){ //v3.0
  eval(targ+".location='"+selObj.options[selObj.selectedIndex].value+"'");
  if (restore) selObj.selectedIndex=0;
}

$(function() {

    
            $("#tabs").organicTabs({
                "speed": 200
            });
            
            $("#tabs2").organicTabs({
                "speed": 200
            });
    
            $("#tabs3").organicTabs({
                "speed": 200
            });
    
            $("#tabs4").organicTabs({
                "speed": 200
            });
          });
		  

$(document).ready(function(){
		$(".formInfo").tooltip({tooltipcontentclass:"mycontent"})
});;


		$(document).ready(function() {
			/*
			 *  Simple image gallery. Uses default settings
			 */

			$('.fancybox').fancybox();

			/*
			 *  Different effects
			 */

			// Change title type, overlay closing speed
			$(".fancybox-effects-a").fancybox({
				helpers: {
					title : {
						type : 'outside'
					},
					overlay : {
						speedOut : 0
					}
				}
			});
		
		
		$('#accordian .single .achead table td:gt(0)').click(function(){
			$(this).parent().parent().parent().parent().next().slideDown();		
		});
		
		$('.close').click(function() {
			$(this).parent().parent().parent().parent().parent().slideUp()
		});
});




$(function() {
 $('.searchtop').hover(function() {
  $(".searchshow").show();
 }), $(".searchtop").hover(function() {
  //do nothing if hovered over
 }, function(){
  //hide on hover out
  $(".searchshow").hide();
 });
});
