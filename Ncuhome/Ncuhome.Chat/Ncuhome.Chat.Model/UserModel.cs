using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncuhome.Chat.Model
{
    public class UserModel
    {
        public int UserIdentity { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string  NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string ImageHeaderPath { get; set; }

        /// <summary>
        /// 个性签名
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string TrueName { get; set; }

        /// <summary>
        /// 学院
        /// </summary>
        public string XY { get; set; }

        /// <summary>
        /// 班级
        /// </summary>
        public string BJ { get; set; }
    }
}
