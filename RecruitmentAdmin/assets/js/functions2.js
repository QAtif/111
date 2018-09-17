// JavaScript Document

$(document).ready(function(){
			$('ul.accordion').accordion();
			
			$('ul.menu ul').accordion();
		
			if($('.pointparent').length){
					$('.pointparent').parent().addClass('addme');
			};
			
			$('#scrollbar1').tinyscrollbar({ axis: 'x', size: 600 , sizethumb: 200  });	
			$('#scrollbar2').tinyscrollbar({ axis: 'y', size: 200 , sizethumb: 50  });	
			
			$(".openframe").fancybox({
					fitToView	: false,
					width		: '70%',
					height		: '90%',
					autoSize	: false,
					openEffect	: 'none',
					closeEffect	: 'none',
					type		: 'iframe'
				});
				$(".openframesmall").fancybox({
					fitToView	: true,	
height		: '40%',					
					autoSize	: false,
					openEffect	: 'none',
					closeEffect	: 'none',
					type		: 'iframe'
				});
				
				$(".openframemini").fancybox({
					fitToView	: false,
					width		: '30%',
					height		: '60%',
					autoSize	: false,
					openEffect	: 'none',
					closeEffect	: 'none',
					type		: 'iframe'
				});
				
				$(".openframelarge").fancybox({
					fitToView	: false,
					width		: '90%',
					height		: '90%',
					autoSize	: false,
					openEffect	: 'none',
					closeEffect	: 'none',
					type		: 'iframe'
				});
				
			//$('form').jqTransform({imgPath:'/assets/jqtransformplugin/img/'});
			
	    	
    
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
      


		$(".formInfo").tooltip({tooltipcontentclass:"mycontent"});
		
		$('#accordian .single .achead table td:gt(0)').click(function(){
			$(this).parent().parent().parent().parent().next().slideDown();		
		});
		
		$('.close').click(function() {
			$(this).parent().parent().parent().parent().parent().slideUp()
		});

 $('.searchtop').hover(function() {
  $(".searchshow").show();
 }), $(".searchtop").hover(function() {
  //do nothing if hovered over
 }, function(){
  //hide on hover out
  $(".searchshow").hide();
 });
 
});
