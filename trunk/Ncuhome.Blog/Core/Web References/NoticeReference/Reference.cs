﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1434
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.1434.
// 
#pragma warning disable 1591

namespace Ncuhome.Blog.Core.NoticeReference {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1434")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="NoticeServiceSoap", Namespace="http://tempuri.org/")]
    public partial class NoticeService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback HelloWorldOperationCompleted;
        
        private System.Threading.SendOrPostCallback InsertNoticeOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeleteNoticeOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateNoticeOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetNoticeByFIIDOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetNoticeByIDOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public NoticeService() {
            this.Url = global::Ncuhome.Blog.Core.Properties.Settings.Default.Blog_Core_NoticeReference_NoticeService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event HelloWorldCompletedEventHandler HelloWorldCompleted;
        
        /// <remarks/>
        public event InsertNoticeCompletedEventHandler InsertNoticeCompleted;
        
        /// <remarks/>
        public event DeleteNoticeCompletedEventHandler DeleteNoticeCompleted;
        
        /// <remarks/>
        public event UpdateNoticeCompletedEventHandler UpdateNoticeCompleted;
        
        /// <remarks/>
        public event GetNoticeByFIIDCompletedEventHandler GetNoticeByFIIDCompleted;
        
        /// <remarks/>
        public event GetNoticeByIDCompletedEventHandler GetNoticeByIDCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/HelloWorld", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld() {
            object[] results = this.Invoke("HelloWorld", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void HelloWorldAsync() {
            this.HelloWorldAsync(null);
        }
        
        /// <remarks/>
        public void HelloWorldAsync(object userState) {
            if ((this.HelloWorldOperationCompleted == null)) {
                this.HelloWorldOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHelloWorldOperationCompleted);
            }
            this.InvokeAsync("HelloWorld", new object[0], this.HelloWorldOperationCompleted, userState);
        }
        
        private void OnHelloWorldOperationCompleted(object arg) {
            if ((this.HelloWorldCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HelloWorldCompleted(this, new HelloWorldCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/InsertNotice", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void InsertNotice(string title, string content, long fiid, bool isvisible, string url, string fileurl, string filename) {
            this.Invoke("InsertNotice", new object[] {
                        title,
                        content,
                        fiid,
                        isvisible,
                        url,
                        fileurl,
                        filename});
        }
        
        /// <remarks/>
        public void InsertNoticeAsync(string title, string content, long fiid, bool isvisible, string url, string fileurl, string filename) {
            this.InsertNoticeAsync(title, content, fiid, isvisible, url, fileurl, filename, null);
        }
        
        /// <remarks/>
        public void InsertNoticeAsync(string title, string content, long fiid, bool isvisible, string url, string fileurl, string filename, object userState) {
            if ((this.InsertNoticeOperationCompleted == null)) {
                this.InsertNoticeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnInsertNoticeOperationCompleted);
            }
            this.InvokeAsync("InsertNotice", new object[] {
                        title,
                        content,
                        fiid,
                        isvisible,
                        url,
                        fileurl,
                        filename}, this.InsertNoticeOperationCompleted, userState);
        }
        
        private void OnInsertNoticeOperationCompleted(object arg) {
            if ((this.InsertNoticeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.InsertNoticeCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/DeleteNotice", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void DeleteNotice(int NtcID) {
            this.Invoke("DeleteNotice", new object[] {
                        NtcID});
        }
        
        /// <remarks/>
        public void DeleteNoticeAsync(int NtcID) {
            this.DeleteNoticeAsync(NtcID, null);
        }
        
        /// <remarks/>
        public void DeleteNoticeAsync(int NtcID, object userState) {
            if ((this.DeleteNoticeOperationCompleted == null)) {
                this.DeleteNoticeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteNoticeOperationCompleted);
            }
            this.InvokeAsync("DeleteNotice", new object[] {
                        NtcID}, this.DeleteNoticeOperationCompleted, userState);
        }
        
        private void OnDeleteNoticeOperationCompleted(object arg) {
            if ((this.DeleteNoticeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteNoticeCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/UpdateNotice", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void UpdateNotice(long id, string title, string content, int fiid, bool isvisible, string url, string fileurl, string filename) {
            this.Invoke("UpdateNotice", new object[] {
                        id,
                        title,
                        content,
                        fiid,
                        isvisible,
                        url,
                        fileurl,
                        filename});
        }
        
        /// <remarks/>
        public void UpdateNoticeAsync(long id, string title, string content, int fiid, bool isvisible, string url, string fileurl, string filename) {
            this.UpdateNoticeAsync(id, title, content, fiid, isvisible, url, fileurl, filename, null);
        }
        
        /// <remarks/>
        public void UpdateNoticeAsync(long id, string title, string content, int fiid, bool isvisible, string url, string fileurl, string filename, object userState) {
            if ((this.UpdateNoticeOperationCompleted == null)) {
                this.UpdateNoticeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateNoticeOperationCompleted);
            }
            this.InvokeAsync("UpdateNotice", new object[] {
                        id,
                        title,
                        content,
                        fiid,
                        isvisible,
                        url,
                        fileurl,
                        filename}, this.UpdateNoticeOperationCompleted, userState);
        }
        
        private void OnUpdateNoticeOperationCompleted(object arg) {
            if ((this.UpdateNoticeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateNoticeCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetNoticeByFIID", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Notice[] GetNoticeByFIID(int NtcFIID) {
            object[] results = this.Invoke("GetNoticeByFIID", new object[] {
                        NtcFIID});
            return ((Notice[])(results[0]));
        }
        
        /// <remarks/>
        public void GetNoticeByFIIDAsync(int NtcFIID) {
            this.GetNoticeByFIIDAsync(NtcFIID, null);
        }
        
        /// <remarks/>
        public void GetNoticeByFIIDAsync(int NtcFIID, object userState) {
            if ((this.GetNoticeByFIIDOperationCompleted == null)) {
                this.GetNoticeByFIIDOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetNoticeByFIIDOperationCompleted);
            }
            this.InvokeAsync("GetNoticeByFIID", new object[] {
                        NtcFIID}, this.GetNoticeByFIIDOperationCompleted, userState);
        }
        
        private void OnGetNoticeByFIIDOperationCompleted(object arg) {
            if ((this.GetNoticeByFIIDCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetNoticeByFIIDCompleted(this, new GetNoticeByFIIDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetNoticeByID", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Notice GetNoticeByID(long NoticeID) {
            object[] results = this.Invoke("GetNoticeByID", new object[] {
                        NoticeID});
            return ((Notice)(results[0]));
        }
        
        /// <remarks/>
        public void GetNoticeByIDAsync(long NoticeID) {
            this.GetNoticeByIDAsync(NoticeID, null);
        }
        
        /// <remarks/>
        public void GetNoticeByIDAsync(long NoticeID, object userState) {
            if ((this.GetNoticeByIDOperationCompleted == null)) {
                this.GetNoticeByIDOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetNoticeByIDOperationCompleted);
            }
            this.InvokeAsync("GetNoticeByID", new object[] {
                        NoticeID}, this.GetNoticeByIDOperationCompleted, userState);
        }
        
        private void OnGetNoticeByIDOperationCompleted(object arg) {
            if ((this.GetNoticeByIDCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetNoticeByIDCompleted(this, new GetNoticeByIDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.1434")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Notice {
        
        private System.Nullable<long> ntc_AdminIDField;
        
        private long ntc_IDField;
        
        private string ntc_ContentField;
        
        private System.Nullable<int> ntc_FIIDField;
        
        private System.Nullable<bool> ntc_IsVisibleField;
        
        private System.Nullable<System.DateTime> ntc_CreateTimeField;
        
        private System.Nullable<System.DateTime> ntc_UpdateTimeField;
        
        private string ntc_FileNameField;
        
        private string ntc_UrlField;
        
        private string ntc_FileUrlField;
        
        private System.Nullable<long> ntc_HitsField;
        
        private string ntc_TitleField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<long> Ntc_AdminID {
            get {
                return this.ntc_AdminIDField;
            }
            set {
                this.ntc_AdminIDField = value;
            }
        }
        
        /// <remarks/>
        public long Ntc_ID {
            get {
                return this.ntc_IDField;
            }
            set {
                this.ntc_IDField = value;
            }
        }
        
        /// <remarks/>
        public string Ntc_Content {
            get {
                return this.ntc_ContentField;
            }
            set {
                this.ntc_ContentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> Ntc_FIID {
            get {
                return this.ntc_FIIDField;
            }
            set {
                this.ntc_FIIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<bool> Ntc_IsVisible {
            get {
                return this.ntc_IsVisibleField;
            }
            set {
                this.ntc_IsVisibleField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> Ntc_CreateTime {
            get {
                return this.ntc_CreateTimeField;
            }
            set {
                this.ntc_CreateTimeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> Ntc_UpdateTime {
            get {
                return this.ntc_UpdateTimeField;
            }
            set {
                this.ntc_UpdateTimeField = value;
            }
        }
        
        /// <remarks/>
        public string Ntc_FileName {
            get {
                return this.ntc_FileNameField;
            }
            set {
                this.ntc_FileNameField = value;
            }
        }
        
        /// <remarks/>
        public string Ntc_Url {
            get {
                return this.ntc_UrlField;
            }
            set {
                this.ntc_UrlField = value;
            }
        }
        
        /// <remarks/>
        public string Ntc_FileUrl {
            get {
                return this.ntc_FileUrlField;
            }
            set {
                this.ntc_FileUrlField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<long> Ntc_Hits {
            get {
                return this.ntc_HitsField;
            }
            set {
                this.ntc_HitsField = value;
            }
        }
        
        /// <remarks/>
        public string Ntc_Title {
            get {
                return this.ntc_TitleField;
            }
            set {
                this.ntc_TitleField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1434")]
    public delegate void HelloWorldCompletedEventHandler(object sender, HelloWorldCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1434")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HelloWorldCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HelloWorldCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1434")]
    public delegate void InsertNoticeCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1434")]
    public delegate void DeleteNoticeCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1434")]
    public delegate void UpdateNoticeCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1434")]
    public delegate void GetNoticeByFIIDCompletedEventHandler(object sender, GetNoticeByFIIDCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1434")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetNoticeByFIIDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetNoticeByFIIDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Notice[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Notice[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1434")]
    public delegate void GetNoticeByIDCompletedEventHandler(object sender, GetNoticeByIDCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1434")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetNoticeByIDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetNoticeByIDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Notice Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Notice)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591