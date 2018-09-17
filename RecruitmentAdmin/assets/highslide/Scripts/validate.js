function filter (term, _id, cellNr) // NOT IN USE 
  {
	var suche = term.value.toLowerCase();
	var table = document.getElementById(_id);
	var ele;
	for (var r = 1; r < table.rows.length; r++){
		ele = table.rows[r].cells[cellNr].innerHTML.replace(/<[^>]+>/g,"");
		if (ele.toLowerCase().indexOf(suche)>=0 )
			table.rows[r].style.display = '';
		else table.rows[r].style.display = 'none';
	}
}
function filterCombo(term, _id, cellNr) // NOT IN USE 
  {
  var val;
  if(term.value=='00')
  {
  
   val='';
   }
  else val=term.value;
	var suche = val.toLowerCase();
	var table = document.getElementById(_id);
	var ele;
	for (var r = 1; r < table.rows.length; r++){
		ele = table.rows[r].cells[cellNr].innerHTML.replace(/<[^>]+>/g,"");
		if (ele.toLowerCase().indexOf(suche)>=0 )
			table.rows[r].style.display = '';
		else table.rows[r].style.display = 'none';
	}
}
function filter2(phrase,_id)
{

	var words = phrase.value.toLowerCase().split(" ");
	var table = document.getElementById(_id);
	var ele;
	
	for (var r = 1; r < table.rows.length; r++){
		ele = table.rows[r].innerHTML.replace(/<[^>]+>/g,"");
	        var displayStyle = 'none';
	        for (var i = 0; i < words.length; i++) {
		    if (ele.toLowerCase().indexOf(words[i])>=0)
			displayStyle = '';
		    else {
			displayStyle = 'none';
			break;
		    }
	        }
		table.rows[r].style.display = displayStyle;
	}
}

function updateClock ( )
{ 
  var hr = new Number(document.getElementById("spnHour").firstChild.nodeValue);
  var min = new Number(document.getElementById("spnMin").firstChild.nodeValue);
  var sec = new Number(document.getElementById("spnSec").firstChild.nodeValue);
  
  sec = (sec +1);
  if (sec > 59)
  {  sec = 0;  min = (min +1);  }
    
  if (min > 59)
  {  min = 0;  hr = (hr +1);  }
  
  if (hr > 23)
  {  hr = 0;  }
  
  hr = ( hr < 10 ? "0" : "" ) + hr;
  min = ( min < 10 ? "0" : "" ) + min;
  sec = ( sec < 10 ? "0" : "" ) + sec;
  
 var timeOfDay = ( hr < 12 ) ? "AM" : "PM";
  var hour = hr;
  hour = ( hour > 12 ) ? hour - 12 : hour;
  hour = ( hour == 0 ) ? 12 : hour;

    
  var currentTimeString = hour + ":" + min + ":" + sec + " " + timeOfDay;
  
  // Display Time
  document.getElementById("clock").firstChild.nodeValue = currentTimeString;
  
  document.getElementById("spnHour").firstChild.nodeValue = hr;
  document.getElementById("spnMin").firstChild.nodeValue = min; 
  document.getElementById("spnSec").firstChild.nodeValue = sec;
}