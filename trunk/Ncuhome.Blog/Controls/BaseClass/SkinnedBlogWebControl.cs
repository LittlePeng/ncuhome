using System;
using System.ComponentModel;
using Ncuhome.Blog.Core;
using System.IO;
using System.Web.UI;

namespace Ncuhome.Blog.Controls
{
    [ParseChildren(true)]
    /// <summary>
    /// 皮肤控件基类
    /// </summary>
    public abstract class SkinnedBlogWebControl : Control, INamingContainer
    {
        /// <summary>
        /// 构造
        /// </summary>
        public SkinnedBlogWebControl()
        {
            //
        }

        /// <summary>
        /// myself：将SkinFilename改名为SkinFileName
        /// </summary>
        public string SkinFileName { get; set; }

        [DefaultValue("true")]
        public bool IsThemed { get; set; }

        public BlogContext blogContext =BlogContext.Current;

        /// <summary>
        /// 创建子控件
        /// </summary>
        protected override void CreateChildControls()
        {
            Control skin = this.LoadSkin();
            this.InitializeSkin(skin);
            this.Controls.Add(skin);
        }

        /// <summary>
        /// 加载皮肤
        /// </summary>
        /// <returns></returns>
        protected Control LoadSkin()
        {
            Control skin;
            string skinPath=string.Empty;

            //myself：先做判断再选皮肤。或者指定默认的皮肤。
            if (this.SkinFileName == null)
            {
                //this.SkinFileName=
                throw new Exception("你必须指定皮肤的文件名");
            }

            if (this.IsThemed)
                skinPath = "\\Themes\\" + Ncuhome.Blog.Core.BlogContext.Current.ThemeName.Trim() + "\\" + this.SkinFileName.TrimStart('\\');
            else
                skinPath = "\\Themes\\NoTheme\\" + this.SkinFileName.TrimStart('\\');
            
            try
            {
                skin = Page.LoadControl(skinPath);
            }
            catch (FileNotFoundException)
            {
                throw new Exception("错误:皮肤文件  " + skinPath + " 没有找到. 皮肤必须被指定,以用于控件的呈现.");
            }

            return skin;
        }

        /// <summary>
        ///皮肤初始化,一个抽象的方法，control继承此类的时候实现这个方法。用于绑定加载控件的添加数据 (抽像类)
        /// </summary>
        protected abstract void InitializeSkin(Control Skin);
    }
}
