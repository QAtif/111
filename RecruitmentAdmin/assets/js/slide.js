
	$(document).ready(function(){
//References
		var sections = $("#knockOut li");
		var loading = $("#loading");
		var content = $("#content1");
		
		//Manage click events
		sections.click(function(){
			//show the loading bar
			showLoading();
			//load selected section
			switch(this.id){
				case "my_plan":
					content.load("slides-content.asp #section_my_plan", hideLoading);
					content.fadeIn("slow");
					break;
				case "crm":
					content.load("slides-content.asp #section_crm", hideLoading);
					content.fadeIn("slow");
					break;			
									
				default:
					//hide loading bar if there is no selected section
					hideLoading();
					break;
			}
		});
	
		//show loading bar
		function showLoading(){
			loading
				.css({visibility:"visible"})
				.css({opacity:"1"})
				.css({display:"block"})
			;
		}
		//hide loading bar
		function hideLoading(){
			loading.fadeTo(1000, 0);
		};		

		$('#knockOut li').click(function() {
		$("#knockOut li").removeClass('active'); //Remove class of 'active' on all list-items
			$(this).addClass('active');  //Add class of 'active' on the selected list
			return false; 


		});

	});
