        var cnum = 0;
        var sender ="";
        var sendto="";
        
        function Prepare()
        {
          cnum = document.getElementById("chatNumber").value;  
          sender = document.getElementById("sender").value;  
          GetChat();
          GetUserList();
          CheckUserStatus();
        }
        
        function CheckUserStatus()
        {
            $.ajax({
            url:"ChatService.asmx/CheckUserStatus",
            cache: false,
            type:"POST",
            data:"{userName:\""+sender+"\"}",
            contentType:"application/json;utf-8",
            success:function(data){
                try
                {
                    json=eval('(' + data + ')');
                    if(json.d!="")
                    {
                        alert(json.d);
                        window.location="logout.aspx?user="+sender;
                    }
                }
                catch(e)
                {
                   return;
                }
            },
            error:function(){
                //alert("error CheckUserStatus");
            }
            });
            
            setTimeout("CheckUserStatus()",15000);  //刷新时间
        }
        
        function GetSendTo()
        {
            sendto =  document.getElementById('Sendto').innerHTML;
            return sendto;
        }
        
        function ChangeTalkTo(sendto)
        {
            document.getElementById('Sendto').innerHTML = sendto;
        }
        
        function GetUserList()
        {
            //调取在线用户数量
            $.ajax({
            url:"ChatService.asmx/GetOnlineUserCount",
            cache: false,
            type:"POST",
            data:"{}",
            contentType:"application/json;utf-8",
            success:function(data){
                try
                {
                    json=eval('(' + data + ')');
                    $("#OnlineUserCount").html(json.d);
                }
                catch(e)
                {
                   return;
                }
            },
            error:function(){}
            });
            
            
            $.ajax({
            url:"ChatService.asmx/GetOnlineGuestCount",
            cache: false,
            type:"POST",
            data:"{}",
            contentType:"application/json;utf-8",
            success:function(data){
                try
                {
                    json=eval('(' + data + ')');
                    $("#OnlineGuestCount").html(json.d);
                }
                catch(e)
                {
                   return;
                }
            },
            error:function(){}
            });
            
            
            //调取用户列表
            $.ajax({
              url: "UserList.ashx?mode=User",
              cache: false,
              success: function(html){
              //alert(html);
              document.getElementById('UserList').innerHTML = html;
              },
              error:function(){
	                //alert('error user');
              }
            }); 
            
            //调取嘉宾列表
            $.ajax({
            url: "UserList.ashx?mode=Guest",
            cache: false,
            success: function(html){
            document.getElementById('GuestList').innerHTML = html;
            },
            error:function(){
                //alert('error guest');
            }
            }); 
            
            setTimeout("GetUserList()",15000);  //刷新时间
        }
		
        function GetChat()
        {
            //调取公聊信息
            $.ajax({
              url: "chat.ashx?cid=1&cnum="+cnum+"&mode=public&sendto="+sender+"&sender="+sender,
              cache: false,
              success: function(html){
              //alert(html);
              document.getElementById('PublicChatResults').innerHTML = html;
              },
              error:function(){
	                //alert('error public');
              }
            }); 
            var userid=document.getElementById('userID').innerHTML;
            
            //调取私聊信息
            sendto = GetSendTo();
            $.ajax({
              url: "chat.ashx?cid=1&userid="+userid+"&cnum="+cnum+"&mode=private",
              cache: false,
              success: function(html){
              document.getElementById('PrivateChatResults').innerHTML = html;
              },
              error:function(){
	                
              }
            }); 
            
            setTimeout("GetChat()",4000);  //刷新时间
        }
      
      function SendChatInfo()
      {        
        var content = $("#ChatContent").val();
        content = content.replace(/"/g,"'");
        var isPrivate =$("#isPrivate").get(0).checked;
        var color = "black";
        
        $("input").each(function(i){
            var elem  = $("input").get(i)
            if(elem.type=="radio"&&elem.checked)
            {
                color = elem.value;
            }
        });
        
        $.ajax({
            url:"ChatService.asmx/SendChat",
            timeout :3000,
            cache: false,
            type:"POST",
            data:"{sender:\""+sender+"\",sendto:\""+sendto+"\",content:\""+content+"\",chatnum:"+cnum+",isPrivate:"+isPrivate+",color:\""+color+"\"}",
            contentType:"application/json;utf-8",
            success:function(data){
                $("#ChatContent").val("");
                
            },
            error:function(){
				//alert('发送超时，请重试');
				}
        });
      }