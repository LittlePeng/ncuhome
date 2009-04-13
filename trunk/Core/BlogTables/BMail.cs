using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Core.MailServices;

namespace Ncuhome.Blog.Core
{
   public class BMail
    {
       
       public static MailServices.InBox[] GetInbox(int PageIndex,int Length)
       {
           
           MailServices.MailServices m = new Ncuhome.Blog.Core.MailServices.MailServices();
           
          return  m.getInbox((int)BlogContext.Current.Owner.User_TxzId, PageIndex, Length, 1);
       }
       public static void SendMail(int ReceiveTxzId,string Title,string Content)
       {
           MailServices.MailServices m = new Ncuhome.Blog.Core.MailServices.MailServices();
           m.WriteMail(Content, Title, ReceiveTxzId.ToString(), true, (int)Blog.Core.BlogContext.Current.Owner.User_TxzId, 1);
       }
       public static MailServices.SendeBox[] GetSendeBox(int PageIndex, int Length)
       {
           MailServices.MailServices m = new Ncuhome.Blog.Core.MailServices.MailServices();
           return m.getSendBox((int)BlogContext.Current.Owner.User_TxzId, PageIndex, Length, 1);
       }
       public static void DeleteMail(int MailId)
       {
           MailServices.MailServices m = new Ncuhome.Blog.Core.MailServices.MailServices();
           m.deleteMail(MailId);
       }
       public static void UpdateNewMaid(int MailId)
       {
           MailServices.MailServices m = new Ncuhome.Blog.Core.MailServices.MailServices();
           m.UpdateMail_Attibute_IsNew(false, MailId);
       }
       public static int GetNewMailCount()
       {
           MailServices.MailServices m = new Ncuhome.Blog.Core.MailServices.MailServices();
           return m.getnewmailcount((int)BlogContext.Current.Owner.User_TxzId);
       }
      
    }
}
