
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
    /// The class representing the dbo.Weblog_GroupMember table.
    /// </summary>
    [Table(Name="dbo.Weblog_GroupMember")]
    public partial class Weblog_GroupMember
    {
        
        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Weblog_GroupMember"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute()]
        public Weblog_GroupMember()
        {
            OnCreated();
        }
        #endregion
        
        #region Column Mapped Properties
        
        private int _GM_Id;

        /// <summary>
        /// Gets or sets the GM_Id column value.
        /// </summary>
        [Column(Name="GM_Id", Storage="_GM_Id", DbType="Int NOT NULL", IsPrimaryKey=true, CanBeNull=false)]
        public int GM_Id
        {
            get { return _GM_Id; }
            set
            {
                if (_GM_Id != value)
                {
                    OnGM_IdChanging(value);
                    _GM_Id = value;
                    OnGM_IdChanged();
                }
            }
        }
        
        private long _GM_UserId;

        /// <summary>
        /// Gets or sets the GM_UserId column value.
        /// </summary>
        [Column(Name="GM_UserId", Storage="_GM_UserId", DbType="BigInt NOT NULL", CanBeNull=false)]
        public long GM_UserId
        {
            get { return _GM_UserId; }
            set
            {
                if (_GM_UserId != value)
                {
                    OnGM_UserIdChanging(value);
                    _GM_UserId = value;
                    OnGM_UserIdChanged();
                }
            }
        }
        
        private Nullable<int> _GM_TopicCount;

        /// <summary>
        /// Gets or sets the GM_TopicCount column value.
        /// </summary>
        [Column(Name="GM_TopicCount", Storage="_GM_TopicCount", DbType="Int")]
        public Nullable<int> GM_TopicCount
        {
            get { return _GM_TopicCount; }
            set
            {
                if (_GM_TopicCount != value)
                {
                    OnGM_TopicCountChanging(value);
                    _GM_TopicCount = value;
                    OnGM_TopicCountChanged();
                }
            }
        }
        
        private Nullable<int> _GM_CommentCount;

        /// <summary>
        /// Gets or sets the GM_CommentCount column value.
        /// </summary>
        [Column(Name="GM_CommentCount", Storage="_GM_CommentCount", DbType="Int")]
        public Nullable<int> GM_CommentCount
        {
            get { return _GM_CommentCount; }
            set
            {
                if (_GM_CommentCount != value)
                {
                    OnGM_CommentCountChanging(value);
                    _GM_CommentCount = value;
                    OnGM_CommentCountChanged();
                }
            }
        }
        
        private System.DateTime _GM_JoinTime;

        /// <summary>
        /// Gets or sets the GM_JoinTime column value.
        /// </summary>
        [Column(Name="GM_JoinTime", Storage="_GM_JoinTime", DbType="DateTime NOT NULL", CanBeNull=false)]
        public System.DateTime GM_JoinTime
        {
            get { return _GM_JoinTime; }
            set
            {
                if (_GM_JoinTime != value)
                {
                    OnGM_JoinTimeChanging(value);
                    _GM_JoinTime = value;
                    OnGM_JoinTimeChanged();
                }
            }
        }
        
        private System.DateTime _GM_LastLoginTime;

        /// <summary>
        /// Gets or sets the GM_LastLoginTime column value.
        /// </summary>
        [Column(Name="GM_LastLoginTime", Storage="_GM_LastLoginTime", DbType="DateTime NOT NULL", CanBeNull=false)]
        public System.DateTime GM_LastLoginTime
        {
            get { return _GM_LastLoginTime; }
            set
            {
                if (_GM_LastLoginTime != value)
                {
                    OnGM_LastLoginTimeChanging(value);
                    _GM_LastLoginTime = value;
                    OnGM_LastLoginTimeChanged();
                }
            }
        }
        
        private Nullable<int> _GM_ViewCount;

        /// <summary>
        /// Gets or sets the GM_ViewCount column value.
        /// </summary>
        [Column(Name="GM_ViewCount", Storage="_GM_ViewCount", DbType="Int")]
        public Nullable<int> GM_ViewCount
        {
            get { return _GM_ViewCount; }
            set
            {
                if (_GM_ViewCount != value)
                {
                    OnGM_ViewCountChanging(value);
                    _GM_ViewCount = value;
                    OnGM_ViewCountChanged();
                }
            }
        }
        
        private Nullable<int> _GM_Level;

        /// <summary>
        /// Gets or sets the GM_Level column value.
        /// </summary>
        [Column(Name="GM_Level", Storage="_GM_Level", DbType="Int")]
        public Nullable<int> GM_Level
        {
            get { return _GM_Level; }
            set
            {
                if (_GM_Level != value)
                {
                    OnGM_LevelChanging(value);
                    _GM_Level = value;
                    OnGM_LevelChanged();
                }
            }
        }
        
        private Nullable<bool> _GM_IsBlocked;

        /// <summary>
        /// Gets or sets the GM_IsBlocked column value.
        /// </summary>
        [Column(Name="GM_IsBlocked", Storage="_GM_IsBlocked", DbType="Bit")]
        public Nullable<bool> GM_IsBlocked
        {
            get { return _GM_IsBlocked; }
            set
            {
                if (_GM_IsBlocked != value)
                {
                    OnGM_IsBlockedChanging(value);
                    _GM_IsBlocked = value;
                    OnGM_IsBlockedChanged();
                }
            }
        }
        
        private int _GM_GroupId;

        /// <summary>
        /// Gets or sets the GM_GroupId column value.
        /// </summary>
        [Column(Name="GM_GroupId", Storage="_GM_GroupId", DbType="Int NOT NULL", CanBeNull=false)]
        public int GM_GroupId
        {
            get { return _GM_GroupId; }
            set
            {
                if (_GM_GroupId != value)
                {
                    OnGM_GroupIdChanging(value);
                    _GM_GroupId = value;
                    OnGM_GroupIdChanged();
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
        /// <summary>Called when GM_Id is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGM_IdChanging(int value);
        /// <summary>Called after GM_Id has Changed.</summary>
        partial void OnGM_IdChanged();
        /// <summary>Called when GM_UserId is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGM_UserIdChanging(long value);
        /// <summary>Called after GM_UserId has Changed.</summary>
        partial void OnGM_UserIdChanged();
        /// <summary>Called when GM_TopicCount is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGM_TopicCountChanging(Nullable<int> value);
        /// <summary>Called after GM_TopicCount has Changed.</summary>
        partial void OnGM_TopicCountChanged();
        /// <summary>Called when GM_CommentCount is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGM_CommentCountChanging(Nullable<int> value);
        /// <summary>Called after GM_CommentCount has Changed.</summary>
        partial void OnGM_CommentCountChanged();
        /// <summary>Called when GM_JoinTime is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGM_JoinTimeChanging(System.DateTime value);
        /// <summary>Called after GM_JoinTime has Changed.</summary>
        partial void OnGM_JoinTimeChanged();
        /// <summary>Called when GM_LastLoginTime is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGM_LastLoginTimeChanging(System.DateTime value);
        /// <summary>Called after GM_LastLoginTime has Changed.</summary>
        partial void OnGM_LastLoginTimeChanged();
        /// <summary>Called when GM_ViewCount is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGM_ViewCountChanging(Nullable<int> value);
        /// <summary>Called after GM_ViewCount has Changed.</summary>
        partial void OnGM_ViewCountChanged();
        /// <summary>Called when GM_Level is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGM_LevelChanging(Nullable<int> value);
        /// <summary>Called after GM_Level has Changed.</summary>
        partial void OnGM_LevelChanged();
        /// <summary>Called when GM_IsBlocked is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGM_IsBlockedChanging(Nullable<bool> value);
        /// <summary>Called after GM_IsBlocked has Changed.</summary>
        partial void OnGM_IsBlockedChanged();
        /// <summary>Called when GM_GroupId is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGM_GroupIdChanging(int value);
        /// <summary>Called after GM_GroupId has Changed.</summary>
        partial void OnGM_GroupIdChanged();
        #endregion
        
    }
}
