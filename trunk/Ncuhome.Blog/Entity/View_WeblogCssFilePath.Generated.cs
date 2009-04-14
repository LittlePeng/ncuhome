
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
    /// The class representing the dbo.View_WeblogCssFilePath table.
    /// </summary>
    [Table(Name="dbo.View_WeblogCssFilePath")]
    public partial class View_WeblogCssFilePath
    {
        
        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="View_WeblogCssFilePath"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute()]
        public View_WeblogCssFilePath()
        {
            OnCreated();
        }
        #endregion
        
        #region Column Mapped Properties
        
        private string _CssFile_Path;

        /// <summary>
        /// Gets or sets the CssFile_Path column value.
        /// </summary>
        [Column(Name="CssFile_Path", Storage="_CssFile_Path", DbType="NChar(200)")]
        public string CssFile_Path
        {
            get { return _CssFile_Path; }
            set
            {
                if (_CssFile_Path != value)
                {
                    OnCssFile_PathChanging(value);
                    _CssFile_Path = value;
                    OnCssFile_PathChanged();
                }
            }
        }
        
        private int _User_Id;

        /// <summary>
        /// Gets or sets the User_Id column value.
        /// </summary>
        [Column(Name="User_Id", Storage="_User_Id", DbType="Int NOT NULL", CanBeNull=false)]
        public int User_Id
        {
            get { return _User_Id; }
            set
            {
                if (_User_Id != value)
                {
                    OnUser_IdChanging(value);
                    _User_Id = value;
                    OnUser_IdChanged();
                }
            }
        }
        
        private Nullable<bool> _UserCss_Used;

        /// <summary>
        /// Gets or sets the UserCss_Used column value.
        /// </summary>
        [Column(Name="UserCss_Used", Storage="_UserCss_Used", DbType="Bit")]
        public Nullable<bool> UserCss_Used
        {
            get { return _UserCss_Used; }
            set
            {
                if (_UserCss_Used != value)
                {
                    OnUserCss_UsedChanging(value);
                    _UserCss_Used = value;
                    OnUserCss_UsedChanged();
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
        /// <summary>Called when CssFile_Path is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnCssFile_PathChanging(string value);
        /// <summary>Called after CssFile_Path has Changed.</summary>
        partial void OnCssFile_PathChanged();
        /// <summary>Called when User_Id is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnUser_IdChanging(int value);
        /// <summary>Called after User_Id has Changed.</summary>
        partial void OnUser_IdChanged();
        /// <summary>Called when UserCss_Used is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnUserCss_UsedChanging(Nullable<bool> value);
        /// <summary>Called after UserCss_Used has Changed.</summary>
        partial void OnUserCss_UsedChanged();
        #endregion
        
    }
}
