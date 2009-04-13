
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
    /// The class representing the dbo.Weblog_FreshDescrible table.
    /// </summary>
    [Table(Name="dbo.Weblog_FreshDescrible")]
    public partial class Weblog_FreshDescrible
    {
        
        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Weblog_FreshDescrible"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute()]
        public Weblog_FreshDescrible()
        {
            OnCreated();
        }
        #endregion
        
        #region Column Mapped Properties
        
        private int _FD_Id = default(int);

        /// <summary>
        /// Gets the FD_Id column value.
        /// </summary>
        [Column(Name="FD_Id", Storage="_FD_Id", DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true, CanBeNull=false)]
        public int FD_Id
        {
            get { return _FD_Id; }
            set
            {
                if (_FD_Id != value)
                {
                    OnFD_IdChanging(value);
                    _FD_Id = value;
                    OnFD_IdChanged();
                }
            }
        }
        
        private string _FD_Name;

        /// <summary>
        /// Gets or sets the FD_Name column value.
        /// </summary>
        [Column(Name="FD_Name", Storage="_FD_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string FD_Name
        {
            get { return _FD_Name; }
            set
            {
                if (_FD_Name != value)
                {
                    OnFD_NameChanging(value);
                    _FD_Name = value;
                    OnFD_NameChanged();
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
        /// <summary>Called when FD_Id is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnFD_IdChanging(int value);
        /// <summary>Called after FD_Id has Changed.</summary>
        partial void OnFD_IdChanged();
        /// <summary>Called when FD_Name is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnFD_NameChanging(string value);
        /// <summary>Called after FD_Name has Changed.</summary>
        partial void OnFD_NameChanged();
        #endregion
        
    }
}

