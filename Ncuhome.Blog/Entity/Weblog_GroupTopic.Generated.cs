
//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Diagnostics;

namespace Ncuhome.Blog.Entity 
{
    /// <summary>
    /// The class representing the dbo.Weblog_GroupTopic table.
    /// </summary>
    [Table(Name="dbo.Weblog_GroupTopic")]
    public partial class Weblog_GroupTopic
    {
        
        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Weblog_GroupTopic"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute()]
        public Weblog_GroupTopic()
        {
            OnCreated();
        }
        #endregion
        
        #region Column Mapped Properties
        
        private long _GT_Id = default(long);

        /// <summary>
        /// Gets the GT_Id column value.
        /// </summary>
        [Column(Name="GT_Id", Storage="_GT_Id", DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true, CanBeNull=false)]
        public long GT_Id
        {
            get { return _GT_Id; }
            set
            {
                if (_GT_Id != value)
                {
                    OnGT_IdChanging(value);
                    _GT_Id = value;
                    OnGT_IdChanged();
                }
            }
        }
        
        private long _GT_UserId;

        /// <summary>
        /// Gets or sets the GT_UserId column value.
        /// </summary>
        [Column(Name="GT_UserId", Storage="_GT_UserId", DbType="BigInt NOT NULL", CanBeNull=false)]
        public long GT_UserId
        {
            get { return _GT_UserId; }
            set
            {
                if (_GT_UserId != value)
                {
                    OnGT_UserIdChanging(value);
                    _GT_UserId = value;
                    OnGT_UserIdChanged();
                }
            }
        }
        
        private string _GT_Title;

        /// <summary>
        /// Gets or sets the GT_Title column value.
        /// </summary>
        [Column(Name="GT_Title", Storage="_GT_Title", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string GT_Title
        {
            get { return _GT_Title; }
            set
            {
                if (_GT_Title != value)
                {
                    OnGT_TitleChanging(value);
                    _GT_Title = value;
                    OnGT_TitleChanged();
                }
            }
        }
        
        private string _GT_Content;

        /// <summary>
        /// Gets or sets the GT_Content column value.
        /// </summary>
        [Column(Name="GT_Content", Storage="_GT_Content", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
        public string GT_Content
        {
            get { return _GT_Content; }
            set
            {
                if (_GT_Content != value)
                {
                    OnGT_ContentChanging(value);
                    _GT_Content = value;
                    OnGT_ContentChanged();
                }
            }
        }
        
        private string _GT_Class;

        /// <summary>
        /// Gets or sets the GT_Class column value.
        /// </summary>
        [Column(Name="GT_Class", Storage="_GT_Class", DbType="NVarChar(20)")]
        public string GT_Class
        {
            get { return _GT_Class; }
            set
            {
                if (_GT_Class != value)
                {
                    OnGT_ClassChanging(value);
                    _GT_Class = value;
                    OnGT_ClassChanged();
                }
            }
        }
        
        private System.DateTime _GT_CreateTime;

        /// <summary>
        /// Gets or sets the GT_CreateTime column value.
        /// </summary>
        [Column(Name="GT_CreateTime", Storage="_GT_CreateTime", DbType="DateTime NOT NULL", CanBeNull=false)]
        public System.DateTime GT_CreateTime
        {
            get { return _GT_CreateTime; }
            set
            {
                if (_GT_CreateTime != value)
                {
                    OnGT_CreateTimeChanging(value);
                    _GT_CreateTime = value;
                    OnGT_CreateTimeChanged();
                }
            }
        }
        
        private System.DateTime _GT_LastModiTime;

        /// <summary>
        /// Gets or sets the GT_LastModiTime column value.
        /// </summary>
        [Column(Name="GT_LastModiTime", Storage="_GT_LastModiTime", DbType="DateTime NOT NULL", CanBeNull=false)]
        public System.DateTime GT_LastModiTime
        {
            get { return _GT_LastModiTime; }
            set
            {
                if (_GT_LastModiTime != value)
                {
                    OnGT_LastModiTimeChanging(value);
                    _GT_LastModiTime = value;
                    OnGT_LastModiTimeChanged();
                }
            }
        }
        
        private Nullable<int> _GT_ViewCount;

        /// <summary>
        /// Gets or sets the GT_ViewCount column value.
        /// </summary>
        [Column(Name="GT_ViewCount", Storage="_GT_ViewCount", DbType="Int")]
        public Nullable<int> GT_ViewCount
        {
            get { return _GT_ViewCount; }
            set
            {
                if (_GT_ViewCount != value)
                {
                    OnGT_ViewCountChanging(value);
                    _GT_ViewCount = value;
                    OnGT_ViewCountChanged();
                }
            }
        }
        
        private Nullable<bool> _GT_IsTop;

        /// <summary>
        /// Gets or sets the GT_IsTop column value.
        /// </summary>
        [Column(Name="GT_IsTop", Storage="_GT_IsTop", DbType="Bit")]
        public Nullable<bool> GT_IsTop
        {
            get { return _GT_IsTop; }
            set
            {
                if (_GT_IsTop != value)
                {
                    OnGT_IsTopChanging(value);
                    _GT_IsTop = value;
                    OnGT_IsTopChanged();
                }
            }
        }
        
        private Nullable<int> _GT_CommentCount;

        /// <summary>
        /// Gets or sets the GT_CommentCount column value.
        /// </summary>
        [Column(Name="GT_CommentCount", Storage="_GT_CommentCount", DbType="Int")]
        public Nullable<int> GT_CommentCount
        {
            get { return _GT_CommentCount; }
            set
            {
                if (_GT_CommentCount != value)
                {
                    OnGT_CommentCountChanging(value);
                    _GT_CommentCount = value;
                    OnGT_CommentCountChanged();
                }
            }
        }
        
        private int _GT_GroupId;

        /// <summary>
        /// Gets or sets the GT_GroupId column value.
        /// </summary>
        [Column(Name="GT_GroupId", Storage="_GT_GroupId", DbType="Int NOT NULL", CanBeNull=false)]
        public int GT_GroupId
        {
            get { return _GT_GroupId; }
            set
            {
                if (_GT_GroupId != value)
                {
                    OnGT_GroupIdChanging(value);
                    _GT_GroupId = value;
                    OnGT_GroupIdChanged();
                }
            }
        }
        #endregion
        
        #region Association Mapped Properties
        #endregion
        
        #region Extensibility Method Definitions
        /// <summary>Called when this instance is loaded.</summary>
        partial void OnLoaded();
        /// <summary>Called when this instance is being saved.</summary>
        partial void OnValidate(ChangeAction action);
        /// <summary>Called when this instance is created.</summary>
        partial void OnCreated();
        /// <summary>Called when GT_Id is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGT_IdChanging(long value);
        /// <summary>Called after GT_Id has Changed.</summary>
        partial void OnGT_IdChanged();
        /// <summary>Called when GT_UserId is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGT_UserIdChanging(long value);
        /// <summary>Called after GT_UserId has Changed.</summary>
        partial void OnGT_UserIdChanged();
        /// <summary>Called when GT_Title is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGT_TitleChanging(string value);
        /// <summary>Called after GT_Title has Changed.</summary>
        partial void OnGT_TitleChanged();
        /// <summary>Called when GT_Content is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGT_ContentChanging(string value);
        /// <summary>Called after GT_Content has Changed.</summary>
        partial void OnGT_ContentChanged();
        /// <summary>Called when GT_Class is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGT_ClassChanging(string value);
        /// <summary>Called after GT_Class has Changed.</summary>
        partial void OnGT_ClassChanged();
        /// <summary>Called when GT_CreateTime is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGT_CreateTimeChanging(System.DateTime value);
        /// <summary>Called after GT_CreateTime has Changed.</summary>
        partial void OnGT_CreateTimeChanged();
        /// <summary>Called when GT_LastModiTime is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGT_LastModiTimeChanging(System.DateTime value);
        /// <summary>Called after GT_LastModiTime has Changed.</summary>
        partial void OnGT_LastModiTimeChanged();
        /// <summary>Called when GT_ViewCount is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGT_ViewCountChanging(Nullable<int> value);
        /// <summary>Called after GT_ViewCount has Changed.</summary>
        partial void OnGT_ViewCountChanged();
        /// <summary>Called when GT_IsTop is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGT_IsTopChanging(Nullable<bool> value);
        /// <summary>Called after GT_IsTop has Changed.</summary>
        partial void OnGT_IsTopChanged();
        /// <summary>Called when GT_CommentCount is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGT_CommentCountChanging(Nullable<int> value);
        /// <summary>Called after GT_CommentCount has Changed.</summary>
        partial void OnGT_CommentCountChanged();
        /// <summary>Called when GT_GroupId is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGT_GroupIdChanging(int value);
        /// <summary>Called after GT_GroupId has Changed.</summary>
        partial void OnGT_GroupIdChanged();
        #endregion
        
    }
}
