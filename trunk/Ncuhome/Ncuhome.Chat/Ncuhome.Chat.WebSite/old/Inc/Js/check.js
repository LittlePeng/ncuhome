 function DeleteM(id)
     {
    
       $.ajax({
              url: "../CheckService.asmx/DeleteM",             
             type:"post",
              data:"{id:"+id+"}",
              //dataType:"html", 
              contentType:"application/json;utf-8", 
              success: function(msg){ 
              DeleteHtml(id);                     
             
              },
            error:function(){
                alert("error DeleteM");
            }
            
            });   
     }
     
     function SendM(id)
     {
 
       $.ajax({
              url: "../CheckService.asmx/SendM",  
              cache: false,
              type:"POST",
              data:"{id:"+id+"}",
              //dataType:"html",
              contentType:"application/json;utf-8",
              success: function(msg){ 
               DeleteHtml(id);   
              },
            error:function(){
                alert("error SendM");
            }
             
            });   
     }
     
     function DeleteHtml(id)
     {
     document.getElementById("chat_"+id).style.display="none";
     }