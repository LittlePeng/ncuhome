
//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Data
{
    /// <summary>
    /// The DataContext class for the NCUHOME2006 database.
    /// </summary>
    public partial class BlogDataDataContext : DataContext
    {
        private static MappingSource mappingCache = new AttributeMappingSource();
        
        #region Constructors
        /// <summary>
        /// Initializes the <see cref="BlogDataDataContext"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute]
        static BlogDataDataContext()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogDataDataContext"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute]
        public BlogDataDataContext()
            : base(Ncuhome.Blog.Data.Properties.Settings.Default.NCUHOME2006ConnectionString, mappingCache)
        {
            OnCreated();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogDataDataContext"/> class.
        /// </summary>
        /// <param name="connection">The connection string.</param>
        [DebuggerNonUserCodeAttribute]
        public BlogDataDataContext(string connection)
            : base(connection, mappingCache)
        {
            OnCreated();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogDataDataContext"/> class.
        /// </summary>
        /// <param name="connection">The database connection.</param>
        [DebuggerNonUserCodeAttribute]
        public BlogDataDataContext(IDbConnection connection)
            : base(connection, mappingCache)
        {
            OnCreated();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogDataDataContext"/> class.
        /// </summary>
        /// <param name="connection">The connection string.</param>
        /// <param name="mappingSource">The mapping source.</param>
        [DebuggerNonUserCodeAttribute]
        public BlogDataDataContext(string connection, MappingSource mappingSource)
            : base(connection, mappingSource)
        {
            OnCreated();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogDataDataContext"/> class.
        /// </summary>
        /// <param name="connection">The database connection.</param>
        /// <param name="mappingSource">The mapping source.</param>
        [DebuggerNonUserCodeAttribute]
        public BlogDataDataContext(IDbConnection connection, MappingSource mappingSource)
            : base(connection, mappingSource)
        {
            OnCreated();
        }
        #endregion
        
        #region Tables
        /// <summary>Represents the dbo.Weblog_Comment table in the underlying database.</summary>
        public Table<Weblog_Comment> Weblog_Comments
        {
            get { return GetTable<Weblog_Comment>(); }
        }
        
        /// <summary>Represents the dbo.Weblog_ViewLog table in the underlying database.</summary>
        public Table<Weblog_ViewLog> Weblog_ViewLogs
        {
            get { return GetTable<Weblog_ViewLog>(); }
        }
        
        /// <summary>Represents the dbo.Weblog_FreshContent table in the underlying database.</summary>
        public Table<Weblog_FreshContent> Weblog_FreshContents
        {
            get { return GetTable<Weblog_FreshContent>(); }
        }
        
        /// <summary>Represents the dbo.Weblog_FreshDescrible table in the underlying database.</summary>
        public Table<Weblog_FreshDescrible> Weblog_FreshDescribles
        {
            get { return GetTable<Weblog_FreshDescrible>(); }
        }
        
        /// <summary>Represents the dbo.Weblog_FreshType table in the underlying database.</summary>
        public Table<Weblog_FreshType> Weblog_FreshTypes
        {
            get { return GetTable<Weblog_FreshType>(); }
        }
        
        /// <summary>Represents the dbo.Weblog_FreshVisit table in the underlying database.</summary>
        public Table<Weblog_FreshVisit> Weblog_FreshVisits
        {
            get { return GetTable<Weblog_FreshVisit>(); }
        }
        
        /// <summary>Represents the dbo.Weblog_Group table in the underlying database.</summary>
        public Table<Weblog_Group> Weblog_Groups
        {
            get { return GetTable<Weblog_Group>(); }
        }
        
        /// <summary>Represents the dbo.Weblog_GroupClass table in the underlying database.</summary>
        public Table<Weblog_GroupClass> Weblog_GroupClasses
        {
            get { return GetTable<Weblog_GroupClass>(); }
        }
        
        /// <summary>Represents the dbo.Weblog_GroupComment table in the underlying database.</summary>
        public Table<Weblog_GroupComment> Weblog_GroupComments
        {
            get { return GetTable<Weblog_GroupComment>(); }
        }
        
        /// <summary>Represents the dbo.Weblog_GroupMember table in the underlying database.</summary>
        public Table<Weblog_GroupMember> Weblog_GroupMembers
        {
            get { return GetTable<Weblog_GroupMember>(); }
        }
        
        /// <summary>Represents the dbo.Weblog_GroupTopic table in the underlying database.</summary>
        public Table<Weblog_GroupTopic> Weblog_GroupTopics
        {
            get { return GetTable<Weblog_GroupTopic>(); }
        }
        
        /// <summary>Represents the dbo.Weblog_GroupVisitor table in the underlying database.</summary>
        public Table<Weblog_GroupVisitor> Weblog_GroupVisitors
        {
            get { return GetTable<Weblog_GroupVisitor>(); }
        }
        
        /// <summary>Represents the dbo.Weblog_Link table in the underlying database.</summary>
        public Table<Weblog_Link> Weblog_Links
        {
            get { return GetTable<Weblog_Link>(); }
        }
        
        /// <summary>Represents the dbo.Weblog_Relative table in the underlying database.</summary>
        public Table<Weblog_Relative> Weblog_Relatives
        {
            get { return GetTable<Weblog_Relative>(); }
        }
        
        /// <summary>Represents the dbo.View_FreshInfor table in the underlying database.</summary>
        public Table<View_FreshInfor> View_FreshInfors
        {
            get { return GetTable<View_FreshInfor>(); }
        }
        
        /// <summary>Represents the dbo.View_GetCommentInforByLogId table in the underlying database.</summary>
        public Table<View_GetCommentInforByLogId> View_GetCommentInforByLogIds
        {
            get { return GetTable<View_GetCommentInforByLogId>(); }
        }
        
        /// <summary>Represents the dbo.View_GetFriendLogByUserId table in the underlying database.</summary>
        public Table<View_GetFriendLogByUserId> View_GetFriendLogByUserIds
        {
            get { return GetTable<View_GetFriendLogByUserId>(); }
        }
        
        /// <summary>Represents the dbo.View_GetUserNickNameByLogId table in the underlying database.</summary>
        public Table<View_GetUserNickNameByLogId> View_GetUserNickNameByLogIds
        {
            get { return GetTable<View_GetUserNickNameByLogId>(); }
        }
        
        /// <summary>Represents the dbo.View_CommonFunction table in the underlying database.</summary>
        public Table<View_CommonFunction> View_CommonFunctions
        {
            get { return GetTable<View_CommonFunction>(); }
        }
        
        /// <summary>Represents the dbo.Common_Friend table in the underlying database.</summary>
        public Table<Common_Friend> Common_Friends
        {
            get { return GetTable<Common_Friend>(); }
        }
        
        /// <summary>Represents the dbo.View_WeblogCssFilePath table in the underlying database.</summary>
        public Table<View_WeblogCssFilePath> View_WeblogCssFilePaths
        {
            get { return GetTable<View_WeblogCssFilePath>(); }
        }
        
        /// <summary>Represents the dbo.Weblog_UserCss table in the underlying database.</summary>
        public Table<Weblog_UserCss> Weblog_UserCsses
        {
            get { return GetTable<Weblog_UserCss>(); }
        }
        
        /// <summary>Represents the dbo.Weblog_Theme table in the underlying database.</summary>
        public Table<Weblog_Theme> Weblog_Themes
        {
            get { return GetTable<Weblog_Theme>(); }
        }
        
        /// <summary>Represents the dbo.View_WeblogThemeDetail table in the underlying database.</summary>
        public Table<View_WeblogThemeDetail> View_WeblogThemeDetails
        {
            get { return GetTable<View_WeblogThemeDetail>(); }
        }
        
        /// <summary>Represents the dbo.Weblog_CssFile table in the underlying database.</summary>
        public Table<Weblog_CssFile> Weblog_CssFiles
        {
            get { return GetTable<Weblog_CssFile>(); }
        }
        
        /// <summary>Represents the dbo.View_WeblogThemeCssFile table in the underlying database.</summary>
        public Table<View_WeblogThemeCssFile> View_WeblogThemeCssFiles
        {
            get { return GetTable<View_WeblogThemeCssFile>(); }
        }
        
        /// <summary>Represents the dbo.View_WeblogUserComment table in the underlying database.</summary>
        public Table<View_WeblogUserComment> View_WeblogUserComments
        {
            get { return GetTable<View_WeblogUserComment>(); }
        }
        
        /// <summary>Represents the dbo.View_WeblogUserXSJBXX table in the underlying database.</summary>
        public Table<View_WeblogUserXSJBXX> View_WeblogUserXSJBXXes
        {
            get { return GetTable<View_WeblogUserXSJBXX>(); }
        }
        
        /// <summary>Represents the dbo.Weblog_Log table in the underlying database.</summary>
        public Table<Weblog_Log> Weblog_Logs
        {
            get { return GetTable<Weblog_Log>(); }
        }
        
        /// <summary>Represents the dbo.Weblog_Category table in the underlying database.</summary>
        public Table<Weblog_Category> Weblog_Categorys
        {
            get { return GetTable<Weblog_Category>(); }
        }
        
        /// <summary>Represents the dbo.View_WeblogLogCategory table in the underlying database.</summary>
        public Table<View_WeblogLogCategory> View_WeblogLogCategorys
        {
            get { return GetTable<View_WeblogLogCategory>(); }
        }
        
        /// <summary>Represents the dbo.View_WeblogUserLogCategory table in the underlying database.</summary>
        public Table<View_WeblogUserLogCategory> View_WeblogUserLogCategorys
        {
            get { return GetTable<View_WeblogUserLogCategory>(); }
        }
        
        /// <summary>Represents the dbo.View_BlogUserFriend table in the underlying database.</summary>
        public Table<View_BlogUserFriend> View_BlogUserFriends
        {
            get { return GetTable<View_BlogUserFriend>(); }
        }
        
        /// <summary>Represents the dbo.Weblog_User table in the underlying database.</summary>
        public Table<Weblog_User> Weblog_Users
        {
            get { return GetTable<Weblog_User>(); }
        }
        
        /// <summary>Represents the dbo.Weblog_UserRssLink table in the underlying database.</summary>
        public Table<Weblog_UserRssLink> Weblog_UserRssLinks
        {
            get { return GetTable<Weblog_UserRssLink>(); }
        }
        
        /// <summary>Represents the dbo.Weblog_Notice table in the underlying database.</summary>
        public Table<Weblog_Notice> Weblog_Notices
        {
            get { return GetTable<Weblog_Notice>(); }
        }
        
        /// <summary>Represents the dbo.View_WeblogUserRecommend table in the underlying database.</summary>
        public Table<View_WeblogUserRecommend> View_WeblogUserRecommends
        {
            get { return GetTable<View_WeblogUserRecommend>(); }
        }
        
        /// <summary>Represents the dbo.Weblog_RecommendTheme table in the underlying database.</summary>
        public Table<Weblog_RecommendTheme> Weblog_RecommendThemes
        {
            get { return GetTable<Weblog_RecommendTheme>(); }
        }
        
        /// <summary>Represents the dbo.Weblog_Recommend table in the underlying database.</summary>
        public Table<Weblog_Recommend> Weblog_Recommends
        {
            get { return GetTable<Weblog_Recommend>(); }
        }
        
        /// <summary>Represents the dbo.View_WeblogUserLog table in the underlying database.</summary>
        public Table<View_WeblogUserLog> View_WeblogUserLogs
        {
            get { return GetTable<View_WeblogUserLog>(); }
        }
        
        #endregion

        #region Functions
        #endregion

        #region Extensibility Method Definitions
        /// <summary>Called after this instance is created.</summary>
        partial void OnCreated();
        /// <summary>Called before a Weblog_Comment is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertWeblog_Comment(Weblog_Comment instance);
        /// <summary>Called before a Weblog_Comment is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateWeblog_Comment(Weblog_Comment instance);
        /// <summary>Called before a Weblog_Comment is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteWeblog_Comment(Weblog_Comment instance);
        /// <summary>Called before a Weblog_ViewLog is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertWeblog_ViewLog(Weblog_ViewLog instance);
        /// <summary>Called before a Weblog_ViewLog is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateWeblog_ViewLog(Weblog_ViewLog instance);
        /// <summary>Called before a Weblog_ViewLog is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteWeblog_ViewLog(Weblog_ViewLog instance);
        /// <summary>Called before a Weblog_FreshContent is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertWeblog_FreshContent(Weblog_FreshContent instance);
        /// <summary>Called before a Weblog_FreshContent is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateWeblog_FreshContent(Weblog_FreshContent instance);
        /// <summary>Called before a Weblog_FreshContent is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteWeblog_FreshContent(Weblog_FreshContent instance);
        /// <summary>Called before a Weblog_FreshDescrible is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertWeblog_FreshDescrible(Weblog_FreshDescrible instance);
        /// <summary>Called before a Weblog_FreshDescrible is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateWeblog_FreshDescrible(Weblog_FreshDescrible instance);
        /// <summary>Called before a Weblog_FreshDescrible is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteWeblog_FreshDescrible(Weblog_FreshDescrible instance);
        /// <summary>Called before a Weblog_FreshType is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertWeblog_FreshType(Weblog_FreshType instance);
        /// <summary>Called before a Weblog_FreshType is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateWeblog_FreshType(Weblog_FreshType instance);
        /// <summary>Called before a Weblog_FreshType is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteWeblog_FreshType(Weblog_FreshType instance);
        /// <summary>Called before a Weblog_FreshVisit is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertWeblog_FreshVisit(Weblog_FreshVisit instance);
        /// <summary>Called before a Weblog_FreshVisit is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateWeblog_FreshVisit(Weblog_FreshVisit instance);
        /// <summary>Called before a Weblog_FreshVisit is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteWeblog_FreshVisit(Weblog_FreshVisit instance);
        /// <summary>Called before a Weblog_Group is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertWeblog_Group(Weblog_Group instance);
        /// <summary>Called before a Weblog_Group is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateWeblog_Group(Weblog_Group instance);
        /// <summary>Called before a Weblog_Group is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteWeblog_Group(Weblog_Group instance);
        /// <summary>Called before a Weblog_GroupClass is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertWeblog_GroupClass(Weblog_GroupClass instance);
        /// <summary>Called before a Weblog_GroupClass is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateWeblog_GroupClass(Weblog_GroupClass instance);
        /// <summary>Called before a Weblog_GroupClass is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteWeblog_GroupClass(Weblog_GroupClass instance);
        /// <summary>Called before a Weblog_GroupComment is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertWeblog_GroupComment(Weblog_GroupComment instance);
        /// <summary>Called before a Weblog_GroupComment is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateWeblog_GroupComment(Weblog_GroupComment instance);
        /// <summary>Called before a Weblog_GroupComment is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteWeblog_GroupComment(Weblog_GroupComment instance);
        /// <summary>Called before a Weblog_GroupMember is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertWeblog_GroupMember(Weblog_GroupMember instance);
        /// <summary>Called before a Weblog_GroupMember is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateWeblog_GroupMember(Weblog_GroupMember instance);
        /// <summary>Called before a Weblog_GroupMember is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteWeblog_GroupMember(Weblog_GroupMember instance);
        /// <summary>Called before a Weblog_GroupTopic is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertWeblog_GroupTopic(Weblog_GroupTopic instance);
        /// <summary>Called before a Weblog_GroupTopic is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateWeblog_GroupTopic(Weblog_GroupTopic instance);
        /// <summary>Called before a Weblog_GroupTopic is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteWeblog_GroupTopic(Weblog_GroupTopic instance);
        /// <summary>Called before a Weblog_GroupVisitor is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertWeblog_GroupVisitor(Weblog_GroupVisitor instance);
        /// <summary>Called before a Weblog_GroupVisitor is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateWeblog_GroupVisitor(Weblog_GroupVisitor instance);
        /// <summary>Called before a Weblog_GroupVisitor is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteWeblog_GroupVisitor(Weblog_GroupVisitor instance);
        /// <summary>Called before a Weblog_Link is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertWeblog_Link(Weblog_Link instance);
        /// <summary>Called before a Weblog_Link is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateWeblog_Link(Weblog_Link instance);
        /// <summary>Called before a Weblog_Link is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteWeblog_Link(Weblog_Link instance);
        /// <summary>Called before a Weblog_Relative is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertWeblog_Relative(Weblog_Relative instance);
        /// <summary>Called before a Weblog_Relative is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateWeblog_Relative(Weblog_Relative instance);
        /// <summary>Called before a Weblog_Relative is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteWeblog_Relative(Weblog_Relative instance);
        /// <summary>Called before a View_FreshInfor is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertView_FreshInfor(View_FreshInfor instance);
        /// <summary>Called before a View_FreshInfor is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateView_FreshInfor(View_FreshInfor instance);
        /// <summary>Called before a View_FreshInfor is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteView_FreshInfor(View_FreshInfor instance);
        /// <summary>Called before a View_GetCommentInforByLogId is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertView_GetCommentInforByLogId(View_GetCommentInforByLogId instance);
        /// <summary>Called before a View_GetCommentInforByLogId is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateView_GetCommentInforByLogId(View_GetCommentInforByLogId instance);
        /// <summary>Called before a View_GetCommentInforByLogId is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteView_GetCommentInforByLogId(View_GetCommentInforByLogId instance);
        /// <summary>Called before a View_GetFriendLogByUserId is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertView_GetFriendLogByUserId(View_GetFriendLogByUserId instance);
        /// <summary>Called before a View_GetFriendLogByUserId is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateView_GetFriendLogByUserId(View_GetFriendLogByUserId instance);
        /// <summary>Called before a View_GetFriendLogByUserId is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteView_GetFriendLogByUserId(View_GetFriendLogByUserId instance);
        /// <summary>Called before a View_GetUserNickNameByLogId is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertView_GetUserNickNameByLogId(View_GetUserNickNameByLogId instance);
        /// <summary>Called before a View_GetUserNickNameByLogId is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateView_GetUserNickNameByLogId(View_GetUserNickNameByLogId instance);
        /// <summary>Called before a View_GetUserNickNameByLogId is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteView_GetUserNickNameByLogId(View_GetUserNickNameByLogId instance);
        /// <summary>Called before a View_CommonFunction is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertView_CommonFunction(View_CommonFunction instance);
        /// <summary>Called before a View_CommonFunction is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateView_CommonFunction(View_CommonFunction instance);
        /// <summary>Called before a View_CommonFunction is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteView_CommonFunction(View_CommonFunction instance);
        /// <summary>Called before a Common_Friend is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertCommon_Friend(Common_Friend instance);
        /// <summary>Called before a Common_Friend is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateCommon_Friend(Common_Friend instance);
        /// <summary>Called before a Common_Friend is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteCommon_Friend(Common_Friend instance);
        /// <summary>Called before a View_WeblogCssFilePath is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertView_WeblogCssFilePath(View_WeblogCssFilePath instance);
        /// <summary>Called before a View_WeblogCssFilePath is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateView_WeblogCssFilePath(View_WeblogCssFilePath instance);
        /// <summary>Called before a View_WeblogCssFilePath is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteView_WeblogCssFilePath(View_WeblogCssFilePath instance);
        /// <summary>Called before a Weblog_UserCss is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertWeblog_UserCss(Weblog_UserCss instance);
        /// <summary>Called before a Weblog_UserCss is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateWeblog_UserCss(Weblog_UserCss instance);
        /// <summary>Called before a Weblog_UserCss is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteWeblog_UserCss(Weblog_UserCss instance);
        /// <summary>Called before a Weblog_Theme is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertWeblog_Theme(Weblog_Theme instance);
        /// <summary>Called before a Weblog_Theme is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateWeblog_Theme(Weblog_Theme instance);
        /// <summary>Called before a Weblog_Theme is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteWeblog_Theme(Weblog_Theme instance);
        /// <summary>Called before a View_WeblogThemeDetail is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertView_WeblogThemeDetail(View_WeblogThemeDetail instance);
        /// <summary>Called before a View_WeblogThemeDetail is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateView_WeblogThemeDetail(View_WeblogThemeDetail instance);
        /// <summary>Called before a View_WeblogThemeDetail is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteView_WeblogThemeDetail(View_WeblogThemeDetail instance);
        /// <summary>Called before a Weblog_CssFile is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertWeblog_CssFile(Weblog_CssFile instance);
        /// <summary>Called before a Weblog_CssFile is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateWeblog_CssFile(Weblog_CssFile instance);
        /// <summary>Called before a Weblog_CssFile is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteWeblog_CssFile(Weblog_CssFile instance);
        /// <summary>Called before a View_WeblogThemeCssFile is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertView_WeblogThemeCssFile(View_WeblogThemeCssFile instance);
        /// <summary>Called before a View_WeblogThemeCssFile is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateView_WeblogThemeCssFile(View_WeblogThemeCssFile instance);
        /// <summary>Called before a View_WeblogThemeCssFile is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteView_WeblogThemeCssFile(View_WeblogThemeCssFile instance);
        /// <summary>Called before a View_WeblogUserComment is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertView_WeblogUserComment(View_WeblogUserComment instance);
        /// <summary>Called before a View_WeblogUserComment is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateView_WeblogUserComment(View_WeblogUserComment instance);
        /// <summary>Called before a View_WeblogUserComment is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteView_WeblogUserComment(View_WeblogUserComment instance);
        /// <summary>Called before a View_WeblogUserXSJBXX is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertView_WeblogUserXSJBXX(View_WeblogUserXSJBXX instance);
        /// <summary>Called before a View_WeblogUserXSJBXX is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateView_WeblogUserXSJBXX(View_WeblogUserXSJBXX instance);
        /// <summary>Called before a View_WeblogUserXSJBXX is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteView_WeblogUserXSJBXX(View_WeblogUserXSJBXX instance);
        /// <summary>Called before a Weblog_Log is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertWeblog_Log(Weblog_Log instance);
        /// <summary>Called before a Weblog_Log is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateWeblog_Log(Weblog_Log instance);
        /// <summary>Called before a Weblog_Log is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteWeblog_Log(Weblog_Log instance);
        /// <summary>Called before a Weblog_Category is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertWeblog_Category(Weblog_Category instance);
        /// <summary>Called before a Weblog_Category is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateWeblog_Category(Weblog_Category instance);
        /// <summary>Called before a Weblog_Category is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteWeblog_Category(Weblog_Category instance);
        /// <summary>Called before a View_WeblogLogCategory is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertView_WeblogLogCategory(View_WeblogLogCategory instance);
        /// <summary>Called before a View_WeblogLogCategory is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateView_WeblogLogCategory(View_WeblogLogCategory instance);
        /// <summary>Called before a View_WeblogLogCategory is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteView_WeblogLogCategory(View_WeblogLogCategory instance);
        /// <summary>Called before a View_WeblogUserLogCategory is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertView_WeblogUserLogCategory(View_WeblogUserLogCategory instance);
        /// <summary>Called before a View_WeblogUserLogCategory is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateView_WeblogUserLogCategory(View_WeblogUserLogCategory instance);
        /// <summary>Called before a View_WeblogUserLogCategory is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteView_WeblogUserLogCategory(View_WeblogUserLogCategory instance);
        /// <summary>Called before a View_BlogUserFriend is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertView_BlogUserFriend(View_BlogUserFriend instance);
        /// <summary>Called before a View_BlogUserFriend is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateView_BlogUserFriend(View_BlogUserFriend instance);
        /// <summary>Called before a View_BlogUserFriend is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteView_BlogUserFriend(View_BlogUserFriend instance);
        /// <summary>Called before a Weblog_User is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertWeblog_User(Weblog_User instance);
        /// <summary>Called before a Weblog_User is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateWeblog_User(Weblog_User instance);
        /// <summary>Called before a Weblog_User is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteWeblog_User(Weblog_User instance);
        /// <summary>Called before a Weblog_UserRssLink is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertWeblog_UserRssLink(Weblog_UserRssLink instance);
        /// <summary>Called before a Weblog_UserRssLink is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateWeblog_UserRssLink(Weblog_UserRssLink instance);
        /// <summary>Called before a Weblog_UserRssLink is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteWeblog_UserRssLink(Weblog_UserRssLink instance);
        /// <summary>Called before a Weblog_Notice is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertWeblog_Notice(Weblog_Notice instance);
        /// <summary>Called before a Weblog_Notice is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateWeblog_Notice(Weblog_Notice instance);
        /// <summary>Called before a Weblog_Notice is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteWeblog_Notice(Weblog_Notice instance);
        /// <summary>Called before a View_WeblogUserRecommend is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertView_WeblogUserRecommend(View_WeblogUserRecommend instance);
        /// <summary>Called before a View_WeblogUserRecommend is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateView_WeblogUserRecommend(View_WeblogUserRecommend instance);
        /// <summary>Called before a View_WeblogUserRecommend is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteView_WeblogUserRecommend(View_WeblogUserRecommend instance);
        /// <summary>Called before a Weblog_RecommendTheme is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertWeblog_RecommendTheme(Weblog_RecommendTheme instance);
        /// <summary>Called before a Weblog_RecommendTheme is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateWeblog_RecommendTheme(Weblog_RecommendTheme instance);
        /// <summary>Called before a Weblog_RecommendTheme is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteWeblog_RecommendTheme(Weblog_RecommendTheme instance);
        /// <summary>Called before a Weblog_Recommend is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertWeblog_Recommend(Weblog_Recommend instance);
        /// <summary>Called before a Weblog_Recommend is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateWeblog_Recommend(Weblog_Recommend instance);
        /// <summary>Called before a Weblog_Recommend is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteWeblog_Recommend(Weblog_Recommend instance);
        /// <summary>Called before a View_WeblogUserLog is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertView_WeblogUserLog(View_WeblogUserLog instance);
        /// <summary>Called before a View_WeblogUserLog is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateView_WeblogUserLog(View_WeblogUserLog instance);
        /// <summary>Called before a View_WeblogUserLog is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteView_WeblogUserLog(View_WeblogUserLog instance);
        #endregion
    }
}

