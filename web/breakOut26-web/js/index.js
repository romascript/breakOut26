$(document).ready(function() {
	$('#fullpage').fullpage({
	    sectionsColor: ['#000000','#df4953','#4BBFC3','#ff9966','#0df20d'],
	    scrollOverflow: true
	});

	$('body').hide();
	$('body').fadeIn(3000);
});