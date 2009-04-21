var sender = "";
var sendto = "";
var cnum = watcher = currentPrivateId = currentPublicId = -1;
var userName;

function Prepare() {
    cnum = document.getElementById("chatNumber").value;
    userName = sender = document.getElementById("sender").value;
    Check();
}
function Check() {
    $.ajax({
        url: "/newChatService.asmx/GetNewChatInfo",
        cache: false,
        type: "POST",
        data: makePa(),
        contentType: "application/json;utf-8",
        success: function(data) {
            try {
                op(data);
            }
            catch (e) {
                return;
            }
        },
        error: function(err) {
        }
    });
    setTimeout("Check()", 2000);
}
function makePa() {
    var ret = "";
    if (watcher >= 6 || watcher < 0) {
        ret = "{ChatNum:" + cnum + ",UserName:\"" + userName + "\",IsUserState:true, IsOnlineUserCount:true,IsGuestUserName:true, IsUserUserName:true,IsPublicChatList:true,IsPrivateChatList:true, CurrentChatId:" + currentPublicId + ",CurrentPrivateId:" + currentPrivateId + "}";
        watcher = 1;
    }
    else {
        ret = "{ChatNum:" + cnum + ",UserName:\"" + userName + "\",IsUserState:false, IsOnlineUserCount:false,IsGuestUserName:false, IsUserUserName:false,IsPublicChatList:true,IsPrivateChatList:true, CurrentChatId:" + currentPublicId + ",CurrentPrivateId:" + currentPrivateId + "}";
        watcher++;
    }

    return ret;
}
function op(data) {
    var myObject = JSON.parse(data, null);

    if (myObject.d.IsChange) { /*nothing*/ }

    doUserStatus(myObject.d.UserState);
    doUserList(myObject.d.GuestUser, myObject.d.UserUser);
    doChatList(myObject.d.PublicChatList, myObject.d.PrivateChatList);
}

function doUserStatus(status) {
    if (status == "0")
        return;
    if (status == "2") {
        chatClose(); return;
    }
    kickUser(status);
}

function chatClose() {
    alert("对不起,聊天室已经关闭，谢谢您的参与。");
    window.opener = null;
    window.close();
    window.location = "http://chat.ncuhome.cn/logout.aspx";
}
function kickUser(reason) {
    alert("对不起,您已经被管理员请出了聊天室，谢谢您的参与。");
    window.opener = null;
    window.close();
    window.location = "http://chat.ncuhome.cn/logout.aspx";
}

var oldUserList;
function doUserList(guest, user) {
    var temparr = new Array();
    var users = "";
    var oldFlag = new Array();
    var newFlag = new Array();

    if (oldUserList != null && oldUserList.length > 0) {
        if (oldUserList != null && oldUserList.length > 0) {
            for (var i = 0; i < oldUserList.length; i++) {
                oldFlag.push(0);
            }
        }

        if (user != null && user.length > 0) {
            for (var i = 0; i < user.length; i++) {
                newFlag.push(2);
            }
        }

        for (var i = 0; i < user.length; i++) {
            find(oldUserList, user[i].UserId, newFlag, i, oldFlag);
        }

        var str = "";
        for (var i = 0; i < oldFlag.length; i++) {
            //remove all the users who is offline
            if (oldFlag[i] == 0) {
                var elemToDelete = document.getElementById("User_" + oldUserList[i].UserId);
                document.getElementById("UserList").removeChild(elemToDelete);

                elemToDelete = document.getElementById("UserBr_" + oldUserList[i].UserId);
                document.getElementById("UserList").removeChild(elemToDelete);
            }
        }

        for (var i = 0; i < newFlag.length; i++) {
            //append the users who is new
            if (newFlag[i] == 2) {
                var elemToAppend = document.createElement("A");
                elemToAppend.innerHTML = user[i].Name;
                elemToAppend.id = "User_" + user[i].UserId;
                elemToAppend.href = "javascript:ChangeTalkTo('" + user[i].Name + "')";
                document.getElementById("UserList").appendChild(elemToAppend);

                elemToAppend = document.createElement("BR");
                elemToAppend.id = "UserBr_" + user[i].UserId;
                document.getElementById("UserList").appendChild(elemToAppend);
            }
        }
    }
    else {//输出页面
        var sb = new StringBuilder();
        if (user.length > 0) {
            for (var i = 0; i < user.length; i++) {
                sb.append("<a id=User_");
                sb.append(user[i].UserId);
                sb.append(" href=\"javascript:ChangeTalkTo('");
                sb.append(user[i].Name);
                sb.append("')\">");
                sb.append(user[i].Name);
                sb.append("</a> <br />");
            }
            
            replaceHtml("UserList", sb.toString());
        }
    }
    $("#OnlineUserCount").html(user.length);
    
    users = "";
    sb = new StringBuilder();
    for (var i = 0; i < guest.length; i++) {
        sb.append("<a id=User_");
        sb.append(guest[i].UserId);
        sb.append(" href=\"javascript:ChangeTalkTo('");
        sb.append(guest[i].Name);
        sb.append("')\">");
        sb.append(guest[i].Name);
        sb.append("</a> <br />");
    }
    replaceHtml("GuestList", sb.toString());
    //users = users + "<a href=\"javascript:ChangeTalkTo('" + guest[i] + "')\">" + guest[i] + "</a> <br>";
    //$("#GuestList").html(users);
    $("#OnlineGuestCount").html(guest.length);

    oldUserList = user;
    
}

function find(arr, val, newFlag, index, oldFlag) {
    var start = 0;
    var end = arr.length - 1;
    var mid = parseInt(arr.length / 2);

    if (val < arr[start].UserId || val > arr[end].UserId) {
        return false;
    }

    if (val == arr[start].UserId) {
        if (newFlag != null && newFlag.length > 0) {
            newFlag[index] = 1;
            oldFlag[start] = 1;
        }
        return true;
    }

    if (val == arr[end].UserId) {
        if (newFlag != null && newFlag.length > 0) {
            newFlag[index] = 1;
            oldFlag[end] = 1;
        }
        return true;
    }

    while (start < mid && mid < end) {

        if (val > arr[mid].UserId) {
            start = mid;
            mid = parseInt((mid + end) / 2);
        }
        else if (val < arr[mid].UserId) {
            end = mid;
            mid = parseInt((mid + start) / 2);
        }
        else {
            if (newFlag != null && newFlag.length > 0) {
                newFlag[index] = 1;
                oldFlag[mid] = 1;
            }
            return true;
        }
    }
    return false;
}

//function doUserList(guest, user) {
//    var users = "";
//    for (var i = 0; i < user.length; i++)
//        users = users + "<a href=\"javascript:ChangeTalkTo('" + user[i] + "')\">" + user[i] + "</a> <br>";
//    $("#UserList").html(users);
//    $("#OnlineUserCount").html(user.length);
//    
//    users = "";
//    for (var i = 0; i < guest.length; i++)
//        users = users + "<a href=\"javascript:ChangeTalkTo('" + guest[i] + "')\">" + guest[i] + "</a> <br>";
//    $("#GuestList").html(users);
//    $("#OnlineGuestCount").html(guest.length);
//}

function doChatList(pub, pri) {

    var content = new StringBuilder();
    for (var i = 0; i < pub.length; i++) {
        if (i == 0)
            currentPublicId = pub[i].Chat_Id;

        content.append("<table><tr><td style=\"font-size:14\"><a style=\"color:#AA00CC\" href=\"javascript:ChangeTalkTo('");
        content.append(pub[i].Sender);
        content.append("')\">");
        content.append(pub[i].Sender);
        content.append("</a>对<a style=\"color:#AA00CC\" href=\"javascript:ChangeTalkTo('");
        content.append(pub[i].Sendto);
        content.append("')\">");
        content.append(pub[i].Sendto);
        content.append("</a>说：<font style=\"line-height: 180%; color:#333333\">");
        content.append(pub[i].Content);
        content.append("</font>&nbsp;&nbsp;<font style=\"color:#999999\">(");
        content.append(pub[i].CreateTime);
        content.append(")</font></td></tr></table>");
    }
    replaceHtml("PublicChatResults",content.toString()+document.getElementById("PublicChatResults").innerHTML);
    //document.getElementById("PublicChatResults").innerHTML = document.getElementById("PublicChatResults").innerHTML + content;

    content = new StringBuilder();
    for (var i = 0; i < pri.length; i++) {
        if (i == 0)
            currentPrivateId = pri[i].Chat_Id;

        content.append("<table><tr><td style=\"font-size:14\"><a style=\"color:#AA00CC\" href=\"javascript:ChangeTalkTo('");
        content.append(pri[i].Sender);
        content.append("')\">");
        content.append(pri[i].Sender);
        content.append("</a>对<a style=\"color:#AA00CC\" href=\"javascript:ChangeTalkTo('");
        content.append(pri[i].Sendto);
        content.append("')\">");
        content.append(pri[i].Sendto);
        content.append("</a>说：<font style=\"line-height: 180%; color:#333333\">");
        content.append(pri[i].Content);
        content.append("</font>&nbsp;&nbsp;<font style=\"color:#999999\">(");
        content.append(pri[i].CreateTime);
        content.append(")</font></td></tr></table>");

    }
    replaceHtml("PrivateChatResults", document.getElementById("PrivateChatResults").innerHTML + content.toString());
    //document.getElementById("PrivateChatResults").innerHTML = document.getElementById("PrivateChatResults").innerHTML + content;
}
function ChangeTalkTo(sendto2) {
    document.getElementById('Sendto').innerHTML = sendto2;
}
function SendChatInfo() {
    var content = $("#ChatContent").val();
    content = content.replace(/"/g, "'");
    var isPrivate = $("#isPrivate").get(0).checked;
    var color = "black";
    sendto = document.getElementById('Sendto').innerHTML;

    $("input").each(function(i) {
        var elem = $("input").get(i)
        if (elem.type == "radio" && elem.checked) {
            color = elem.value;
        }
    });

    $.ajax({
        url: "NewChatService.asmx/SendChat",
        timeout: 3000,
        cache: false,
        type: "POST",
        data: "{sender:\"" + sender + "\",sendto:\"" + sendto + "\",content:\"" + content + "\",chatnum:" + cnum + ",isPrivate:" + isPrivate + ",color:\"" + color + "\"}",
        contentType: "application/json;utf-8",
        success: function(data) {
            $("#ChatContent").val("");

        },
        error: function() {
            //alert('发送超时，请重试');
        }
    });
}