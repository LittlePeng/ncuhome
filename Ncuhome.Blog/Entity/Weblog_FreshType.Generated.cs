
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
    /// The class representing the dbo.Weblog_FreshType table.
    /// </summary>
    [Table(Name="dbo.Weblog_FreshType")]
    public partial class Weblog_FreshType
    {
        
        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Weblog_FreshType"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute()]
        public Weblog_FreshType()
        {
            OnCreated();
        }
        #endregion
        
        #region Column Mapped Properties
        
        private int _FT_Id = default(int);

        /// <summary>
        /// Gets the FT_Id column value.
        /// </summary>
        [Column(Name="FT_Id", Storage="_FT_Id", DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true, CanBeNull=false)]
        public int FT_Id
        {
            get { return _FT_Id; }
            set
            {
                if (_FT_Id != value)
                {
                    OnFT_IdChanging(value);
                    _FT_Id = value;
                    OnFT_IdChanged();
                }
            }
        }
        
        private string _FT_Name;

        /// <summary>
        /// Gets or sets the FT_Name column value.
        /// </summary>
        [Column(Name="FT_Name", Storage="_FT_Name", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
        public string FT_Name
        {
            get { return _FT_Name; }
            set
            {
                if (_FT_Name != value)
                {
                    OnFT_NameChanging(value);
                    _FT_Name = value;
                    OnFT_NameChanged();
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
        /// <summary>Called when FT_Id is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnFT_IdChanging(int value);
        /// <summary>Called after FT_Id has Changed.</summary>
        partial void OnFT_IdChanged();
        /// <summary>Called when FT_Name is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnFT_NameChanging(string value);
        /// <summary>Called after FT_Name has Changed.</summary>
        partial void OnFT_NameChanged();
        #endregion
        
    }
}

