
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
    /// The class representing the dbo.Weblog_Theme table.
    /// </summary>
    [Table(Name="dbo.Weblog_Theme")]
    public partial class Weblog_Theme
    {
        
        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Weblog_Theme"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute()]
        public Weblog_Theme()
        {
            OnCreated();
        }
        #endregion
        
        #region Column Mapped Properties
        
        private int _Theme_Id = default(int);

        /// <summary>
        /// Gets the Theme_Id column value.
        /// </summary>
        [Column(Name="Theme_Id", Storage="_Theme_Id", DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true, CanBeNull=false)]
        public int Theme_Id
        {
            get { return _Theme_Id; }
            set
            {
                if (_Theme_Id != value)
                {
                    OnTheme_IdChanging(value);
                    _Theme_Id = value;
                    OnTheme_IdChanged();
                }
            }
        }
        
        private string _Theme_Name;

        /// <summary>
        /// Gets or sets the Theme_Name column value.
        /// </summary>
        [Column(Name="Theme_Name", Storage="_Theme_Name", DbType="NChar(50)")]
        public string Theme_Name
        {
            get { return _Theme_Name; }
            set
            {
                if (_Theme_Name != value)
                {
                    OnTheme_NameChanging(value);
                    _Theme_Name = value;
                    OnTheme_NameChanged();
                }
            }
        }
        
        private string _Theme_Intro;

        /// <summary>
        /// Gets or sets the Theme_Intro column value.
        /// </summary>
        [Column(Name="Theme_Intro", Storage="_Theme_Intro", DbType="NChar(500)")]
        public string Theme_Intro
        {
            get { return _Theme_Intro; }
            set
            {
                if (_Theme_Intro != value)
                {
                    OnTheme_IntroChanging(value);
                    _Theme_Intro = value;
                    OnTheme_IntroChanged();
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
        /// <summary>Called when Theme_Id is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnTheme_IdChanging(int value);
        /// <summary>Called after Theme_Id has Changed.</summary>
        partial void OnTheme_IdChanged();
        /// <summary>Called when Theme_Name is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnTheme_NameChanging(string value);
        /// <summary>Called after Theme_Name has Changed.</summary>
        partial void OnTheme_NameChanged();
        /// <summary>Called when Theme_Intro is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnTheme_IntroChanging(string value);
        /// <summary>Called after Theme_Intro has Changed.</summary>
        partial void OnTheme_IntroChanged();
        #endregion
        
    }
}

