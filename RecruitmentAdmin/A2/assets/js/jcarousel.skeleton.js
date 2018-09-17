(function($) {
    $(function() {
        /*
        Carousel initialization
        */
        $('.growth-jcarousel, .perform-jcarousel')
            .jcarousel({
                // Options go here
        });

        /*
         Prev control initialization
         */
        $('.growth-prev, .perform-prev')
            .on('jcarouselcontrol:active', function() {
                $(this).removeClass('inactive');
            })
            .on('jcarouselcontrol:inactive', function() {
                $(this).addClass('inactive');
            })
            .jcarouselControl({
                // Options go here
                target: '-=1'
            });

        /*
         Next control initialization
         */
        $('.growth-next, .perform-next')
            .on('jcarouselcontrol:active', function() {
                $(this).removeClass('inactive');
            })
            .on('jcarouselcontrol:inactive', function() {
                $(this).addClass('inactive');
            })
            .jcarouselControl({
                // Options go here
                target: '+=1'
            });
		
		
        
    });
})(jQuery);
