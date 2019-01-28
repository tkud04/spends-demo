( function ( $ ) {
	"use strict";

    
	 //LinqTest Chart
	 var ctxLinqTest = document.getElementById("linqtest-chart");
     let lcs = document.getElementById('c-s');
     let ctype = ctxLinqTest.getAttribute('data-ctype');
	 
	 let cd = serializeChartForm(lcs);
	 console.log(cd.x);
	 console.log(cd.y);
	 console.log(ctype);
	 console.log(ctxLinqTest);
	 
	var myChart = new Chart(ctxLinqTest, {
		type: ctype,
		data: {
			//labels: [ "January", "February", "March", "April", "May", "June", "July" ],
			labels: cd.x,
			datasets: [
				{
					label: "My First dataset",
					//data: [ 65, 59, 80, 81, 56, 55, 40 ],
					data: cd.y,
					borderColor: "rgba(0, 123, 255, 0.9)",
					borderWidth: "0",
					backgroundColor: "rgba(0, 123, 255, 0.5)"
                }
                     ]
		},
		options: getChartOptions(ctype)
	} );
     
} )( jQuery );	 
	 
	
