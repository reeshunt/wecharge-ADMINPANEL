	$("#AddUserList").click(function(){
		var arr="";
		var y=0;
		var element=document.getElementsByClassName("user");
		for(var i=0;i < element.length;i++){
			if(element[i].checked){
				if(y==0){
                   arr=element[i].value;
				}
				else{
					arr=arr + "," + element[i].value;
				}
				y++;
			}
		}	
		$("#To").val(arr);
	});
	$("#SelectAll").click(function(){
		  if($("#SelectAll").prop('checked')==true){   
			$(".user").prop("checked",true)
		}
		else{
       $(".user").prop("checked",false);
	      $("#To").val("");
		}		
	});

