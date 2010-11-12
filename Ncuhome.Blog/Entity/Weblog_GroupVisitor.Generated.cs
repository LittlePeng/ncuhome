
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
    /// The class representing the dbo.Weblog_GroupVisitor table.
    /// </summary>
    [Table(Name="dbo.Weblog_GroupVisitor")]
    public partial class Weblog_GroupVisitor
    {
        
        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Weblog_GroupVisitor"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute()]
        public Weblog_GroupVisitor()
        {
            OnCreated();
        }
        #endregion
        
        #region Column Mapped Properties
        
        private long _GV_Id = default(long);

        /// <summary>
        /// Gets the GV_Id column value.
        /// </summary>
        [Column(Name="GV_Id", Storage="_GV_Id", DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true, CanBeNull=false)]
        public long GV_Id
        {
            get { return _GV_Id; }
            set
            {
                if (_GV_Id != value)
                {
                    OnGV_IdChanging(value);
                    _GV_Id = value;
                    OnGV_IdChanged();
                }
            }
        }
        
        private long _GV_UserId;

        /// <summary>
        /// Gets or sets the GV_UserId column value.
        /// </summary>
        [Column(Name="GV_UserId", Storage="_GV_UserId", DbType="BigInt NOT NULL", CanBeNull=false)]
        public long GV_UserId
        {
            get { return _GV_UserId; }
            set
            {
                if (_GV_UserId != value)
                {
                    OnGV_UserIdChanging(value);
                    _GV_UserId = value;
                    OnGV_UserIdChanged();
                }
            }
        }
        
        private System.DateTime _GV_LastViewTime;

        /// <summary>
        /// Gets or sets the GV_LastViewTime column value.
        /// </summary>
        [Column(Name="GV_LastViewTime", Storage="_GV_LastViewTime", DbType="DateTime NOT NULL", CanBeNull=false)]
        public System.DateTime GV_LastViewTime
        {
            get { return _GV_LastViewTime; }
            set
            {
                if (_GV_LastViewTime != value)
                {
                    OnGV_LastViewTimeChanging(value);
                    _GV_LastViewTime = value;
                    OnGV_LastViewTimeChanged();
                }
            }
        }
        
        private int _GV_GroupId;

        /// <summary>
        /// Gets or sets the GV_GroupId column value.
        /// </summary>
        [Column(Name="GV_GroupId", Storage="_GV_GroupId", DbType="Int NOT NULL", CanBeNull=false)]
        public int GV_GroupId
        {
            get { return _GV_GroupId; }
            set
            {
                if (_GV_GroupId != value)
                {
                    OnGV_GroupIdChanging(value);
                    _GV_GroupId = value;
                    OnGV_GroupIdChanged();
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
        /// <summary>Called when GV_Id is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGV_IdChanging(long value);
        /// <summary>Called after GV_Id has Changed.</summary>
        partial void OnGV_IdChanged();
        /// <summary>Called when GV_UserId is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGV_UserIdChanging(long value);
        /// <summary>Called after GV_UserId has Changed.</summary>
        partial void OnGV_UserIdChanged();
        /// <summary>Called when GV_LastViewTime is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGV_LastViewTimeChanging(System.DateTime value);
        /// <summary>Called after GV_LastViewTime has Changed.</summary>
        partial void OnGV_LastViewTimeChanged();
        /// <summary>Called when GV_GroupId is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGV_GroupIdChanging(int value);
        /// <summary>Called after GV_GroupId has Changed.</summary>
        partial void OnGV_GroupIdChanged();
        #endregion
        
    }
}
