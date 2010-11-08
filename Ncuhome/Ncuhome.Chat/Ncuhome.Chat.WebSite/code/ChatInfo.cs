using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///ChatInfo 的摘要说明
/// </summary>
namespace Ncuhome.Chat
{
    [Serializable]
    public class ChatInfo
    {
        public bool IsChange { get; set; }
        public int OnlineUserCount { get; set; }
        public string UserState { get; set; }
        public ChatUser[] GuestUser { get; set; }
        public ChatUser[] UserUser { get; set; }
        public ChatList[] PublicChatList { get; set; }
        public ChatList[] PrivateChatList { get; set; }
    }
    [Serializable]
    public class ChatList
    {
        public int  Chat_Id { get; set; }
        public string CreateTime { get; set; }
        public string Sender { get; set; }
        public string  Sendto { get; set; }
        public string  Content { get; set; }
    }

    [Serializable]
    public class ChatUser
    {
        public int UserId { get; set; }
        public string Name { get; set; }
    }
}