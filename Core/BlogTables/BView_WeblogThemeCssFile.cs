using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Data;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Core
{
    public class BView_WeblogThemeCssFile:BlogTableBase
    {
        /// <summary>
        /// 返回主题Css文件信息
        /// </summary>
        /// <param name="ThemeId"></param>
        /// <returns></returns>
        public static IEnumerable<View_WeblogThemeCssFile> GetThemeCssFileByThemeId(int ThemeId)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogThemeCssFiles.Where(p => p.Theme_Id == ThemeId);
        }
        /// <summary>
        /// 根据CssName获取模板数量
        /// </summary>
        /// <param name="CssName"></param>
        /// <returns></returns>
        public static int GetThemeCssFileCountByCssName(string CssName)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_CssFiles.Where(p => p.CssFile_Name.Contains(CssName)).Count();
        }
        /// <summary>
        /// 根据ThemeId返回模板数量
        /// </summary>
        /// <param name="ThemeId"></param>
        /// <returns></returns>
        public static int GetThemeCssFileCountByThemeId(int ThemeId)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogThemeCssFiles.Where(p => p.Theme_Id == ThemeId).Count();
        }
        /// <summary>
        /// 根据CssName获取模板分页
        /// </summary>
        /// <param name="ThemeId"></param>
        /// <param name="Length"></param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        public static IEnumerable<View_WeblogThemeCssFile> GetThemeCssFileByCssNamePaged(string CssName, int Length, int PageIndex)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogThemeCssFiles.Where(p => p.CssFile_Name.Contains(CssName)).Skip((PageIndex - 1) * Length).Take(Length);
        }
        /// <summary>
        /// 根据ThemeId获取模板分页
        /// </summary>
        /// <param name="ThemeId"></param>
        /// <param name="Length"></param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        public static IEnumerable<View_WeblogThemeCssFile> GetThemeCssFileByThemeIdPaged(int ThemeId,int Length,int PageIndex)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogThemeCssFiles.Where(p => p.Theme_Id == ThemeId).Skip((PageIndex-1)*Length).Take(Length);
        }
        public static bool CheckExist(int Id)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            if (BD.Weblog_CssFiles.Where(p => p.CssFile_Id == Id).Count() == 1)
                return true;
            else
                return false;
        }
    }
}
