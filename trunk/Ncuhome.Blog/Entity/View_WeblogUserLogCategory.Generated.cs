
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
    /// The class representing the dbo.View_WeblogUserLogCategory table.
    /// </summary>
    [Table(Name="dbo.View_WeblogUserLogCategory")]
    public partial class View_WeblogUserLogCategory
    {
        
        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="View_WeblogUserLogCategory"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute()]
        public View_WeblogUserLogCategory()
        {
            OnCreated();
        }
        #endregion
        
        #region Column Mapped Properties
        
       
        
        private int _Cate_Id;

        /// <summary>
        /// Gets or sets the Cate_Id column value.
        /// </summary>
        [Column(Name="Cate_Id", Storage="_Cate_Id", DbType="Int NOT NULL", CanBeNull=false)]
        public int Cate_Id
        {
            get { return _Cate_Id; }
            set
            {
                if (_Cate_Id != value)
                {
                    OnCate_IdChanging(value);
                    _Cate_Id = value;
                    OnCate_IdChanged();
                }
            }
        }
        
        private string _Cate_Name;

        /// <summary>
        /// Gets or sets the Cate_Name column value.
        /// </summary>
        [Column(Name="Cate_Name", Storage="_Cate_Name", DbType="NVarChar(50)")]
        public string Cate_Name
        {
            get { return _Cate_Name; }
            set
            {
                if (_Cate_Name != value)
                {
                    OnCate_NameChanging(value);
                    _Cate_Name = value;
                    OnCate_NameChanged();
                }
            }
        }
        
        private Nullable<System.DateTime> _Cate_CreateTime;

        /// <summary>
        /// Gets or sets the Cate_CreateTime column value.
        /// </summary>
        [Column(Name="Cate_CreateTime", Storage="_Cate_CreateTime", DbType="DateTime")]
        public Nullable<System.DateTime> Cate_CreateTime
        {
            get { return _Cate_CreateTime; }
            set
            {
                if (_Cate_CreateTime != value)
                {
                    OnCate_CreateTimeChanging(value);
                    _Cate_CreateTime = value;
                    OnCate_CreateTimeChanged();
                }
            }
        }
        
        private Nullable<int> _Cate_UserId;

        /// <summary>
        /// Gets or sets the Cate_UserId column value.
        /// </summary>
        [Column(Name="Cate_UserId", Storage="_Cate_UserId", DbType="Int")]
        public Nullable<int> Cate_UserId
        {
            get { return _Cate_UserId; }
            set
            {
                if (_Cate_UserId != value)
                {
                    OnCate_UserIdChanging(value);
                    _Cate_UserId = value;
                    OnCate_UserIdChanged();
                }
            }
        }
        
        private string _Cate_Intro;

        /// <summary>
        /// Gets or sets the Cate_Intro column value.
        /// </summary>
        [Column(Name="Cate_Intro", Storage="_Cate_Intro", DbType="NVarChar(500)")]
        public string Cate_Intro
        {
            get { return _Cate_Intro; }
            set
            {
                if (_Cate_Intro != value)
                {
                    OnCate_IntroChanging(value);
                    _Cate_Intro = value;
                    OnCate_IntroChanged();
                }
            }
        }
        
        private int _Log_Count;

        /// <summary>
        /// Gets or sets the Log_Count column value.
        /// </summary>
        [Column(Name = "Log_Count", Storage = "_Log_Count", DbType = "Int NOT NULL", CanBeNull = false)]
        public int Log_Count
        {
            get { return _Log_Count; }
            set
            {
                if (_Log_Count != value)
                {
                    OnLog_CountChanging(value);
                    _Log_Count = value;
                    OnLog_CountChanged();
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
        /// <summary>Called when Cate_Id is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnCate_IdChanging(int value);
        /// <summary>Called after Cate_Id has Changed.</summary>
        partial void OnCate_IdChanged();
        /// <summary>Called when Cate_Name is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnCate_NameChanging(string value);
        /// <summary>Called after Cate_Name has Changed.</summary>
        partial void OnCate_NameChanged();
        /// <summary>Called when Cate_CreateTime is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnCate_CreateTimeChanging(Nullable<System.DateTime> value);
        /// <summary>Called after Cate_CreateTime has Changed.</summary>
        partial void OnCate_CreateTimeChanged();
        /// <summary>Called when Cate_UserId is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnCate_UserIdChanging(Nullable<int> value);
        /// <summary>Called after Cate_UserId has Changed.</summary>
        partial void OnCate_UserIdChanged();
        /// <summary>Called when Cate_Intro is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnCate_IntroChanging(string value);
        /// <summary>Called after Cate_Intro has Changed.</summary>
        partial void OnCate_IntroChanged();
        /// <summary>Called when Log_Count is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnLog_CountChanging(int value);
        /// <summary>Called after Log_Count has Changed.</summary>
        partial void OnLog_CountChanged();
        #endregion
        
    }
}
