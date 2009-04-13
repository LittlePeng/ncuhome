
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
    /// The class representing the dbo.Common_Friend table.
    /// </summary>
    [Table(Name="dbo.Common_Friend")]
    public partial class Common_Friend
    {
        
        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Common_Friend"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute()]
        public Common_Friend()
        {
            OnCreated();
        }
        #endregion
        
        #region Column Mapped Properties
        
        private int _Frd_Id = default(int);

        /// <summary>
        /// Gets the Frd_Id column value.
        /// </summary>
        [Column(Name="Frd_Id", Storage="_Frd_Id", DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true, CanBeNull=false)]
        public int Frd_Id
        {
            get { return _Frd_Id; }
            set
            {
                if (_Frd_Id != value)
                {
                    OnFrd_IdChanging(value);
                    _Frd_Id = value;
                    OnFrd_IdChanged();
                }
            }
        }
        
        private int _Frd_TxzUID;

        /// <summary>
        /// Gets or sets the Frd_TxzUID column value.
        /// </summary>
        [Column(Name="Frd_TxzUID", Storage="_Frd_TxzUID", DbType="Int NOT NULL", CanBeNull=false)]
        public int Frd_TxzUID
        {
            get { return _Frd_TxzUID; }
            set
            {
                if (_Frd_TxzUID != value)
                {
                    OnFrd_TxzUIDChanging(value);
                    _Frd_TxzUID = value;
                    OnFrd_TxzUIDChanged();
                }
            }
        }
        
        private int _Frd_FriendUserId;

        /// <summary>
        /// Gets or sets the Frd_FriendUserId column value.
        /// </summary>
        [Column(Name="Frd_FriendUserId", Storage="_Frd_FriendUserId", DbType="Int NOT NULL", CanBeNull=false)]
        public int Frd_FriendUserId
        {
            get { return _Frd_FriendUserId; }
            set
            {
                if (_Frd_FriendUserId != value)
                {
                    OnFrd_FriendUserIdChanging(value);
                    _Frd_FriendUserId = value;
                    OnFrd_FriendUserIdChanged();
                }
            }
        }
        
        private System.DateTime _Frd_CreateTime;

        /// <summary>
        /// Gets or sets the Frd_CreateTime column value.
        /// </summary>
        [Column(Name="Frd_CreateTime", Storage="_Frd_CreateTime", DbType="DateTime NOT NULL", CanBeNull=false)]
        public System.DateTime Frd_CreateTime
        {
            get { return _Frd_CreateTime; }
            set
            {
                if (_Frd_CreateTime != value)
                {
                    OnFrd_CreateTimeChanging(value);
                    _Frd_CreateTime = value;
                    OnFrd_CreateTimeChanged();
                }
            }
        }
        
        private int _Frd_UserId;

        /// <summary>
        /// Gets or sets the Frd_UserId column value.
        /// </summary>
        [Column(Name="Frd_UserId", Storage="_Frd_UserId", DbType="Int NOT NULL", CanBeNull=false)]
        public int Frd_UserId
        {
            get { return _Frd_UserId; }
            set
            {
                if (_Frd_UserId != value)
                {
                    OnFrd_UserIdChanging(value);
                    _Frd_UserId = value;
                    OnFrd_UserIdChanged();
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
        /// <summary>Called when Frd_Id is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnFrd_IdChanging(int value);
        /// <summary>Called after Frd_Id has Changed.</summary>
        partial void OnFrd_IdChanged();
        /// <summary>Called when Frd_TxzUID is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnFrd_TxzUIDChanging(int value);
        /// <summary>Called after Frd_TxzUID has Changed.</summary>
        partial void OnFrd_TxzUIDChanged();
        /// <summary>Called when Frd_FriendUserId is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnFrd_FriendUserIdChanging(int value);
        /// <summary>Called after Frd_FriendUserId has Changed.</summary>
        partial void OnFrd_FriendUserIdChanged();
        /// <summary>Called when Frd_CreateTime is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnFrd_CreateTimeChanging(System.DateTime value);
        /// <summary>Called after Frd_CreateTime has Changed.</summary>
        partial void OnFrd_CreateTimeChanged();
        /// <summary>Called when Frd_UserId is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnFrd_UserIdChanging(int value);
        /// <summary>Called after Frd_UserId has Changed.</summary>
        partial void OnFrd_UserIdChanged();
        #endregion
        
    }
}

