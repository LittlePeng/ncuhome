﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行库版本:2.0.50727.1433
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 2.0.50727.1433 版自动生成。
// 
#pragma warning disable 1591

namespace Ncuhome.Blog.Core.clubNewsService {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="NewsServiceSoap", Namespace="http://tempuri.org/")]
    public partial class NewsService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback HelloWorldOperationCompleted;
        
        private System.Threading.SendOrPostCallback AddNewsOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateNoticeOperationCompleted;
        
        private System.Threading.SendOrPostCallback AddNoticeOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetUserInfoOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetLatestNewsOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public NewsService() {
            this.Url = global::Ncuhome.Blog.Core.Properties.Settings.Default.Ncuhome_Blog_Core_clubNewsService_NewsService;
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
        public event AddNewsCompletedEventHandler AddNewsCompleted;
        
        /// <remarks/>
        public event UpdateNoticeCompletedEventHandler UpdateNoticeCompleted;
        
        /// <remarks/>
        public event AddNoticeCompletedEventHandler AddNoticeCompleted;
        
        /// <remarks/>
        public event GetUserInfoCompletedEventHandler GetUserInfoCompleted;
        
        /// <remarks/>
        public event GetLatestNewsCompletedEventHandler GetLatestNewsCompleted;
        
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
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AddNews", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool AddNews(int FromTxzID, int TotxzID, string Title, string Content, int TypeID, int UrlID) {
            object[] results = this.Invoke("AddNews", new object[] {
                        FromTxzID,
                        TotxzID,
                        Title,
                        Content,
                        TypeID,
                        UrlID});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void AddNewsAsync(int FromTxzID, int TotxzID, string Title, string Content, int TypeID, int UrlID) {
            this.AddNewsAsync(FromTxzID, TotxzID, Title, Content, TypeID, UrlID, null);
        }
        
        /// <remarks/>
        public void AddNewsAsync(int FromTxzID, int TotxzID, string Title, string Content, int TypeID, int UrlID, object userState) {
            if ((this.AddNewsOperationCompleted == null)) {
                this.AddNewsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddNewsOperationCompleted);
            }
            this.InvokeAsync("AddNews", new object[] {
                        FromTxzID,
                        TotxzID,
                        Title,
                        Content,
                        TypeID,
                        UrlID}, this.AddNewsOperationCompleted, userState);
        }
        
        private void OnAddNewsOperationCompleted(object arg) {
            if ((this.AddNewsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddNewsCompleted(this, new AddNewsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/UpdateNotice", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool UpdateNotice(long id, string content, int fiid) {
            object[] results = this.Invoke("UpdateNotice", new object[] {
                        id,
                        content,
                        fiid});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void UpdateNoticeAsync(long id, string content, int fiid) {
            this.UpdateNoticeAsync(id, content, fiid, null);
        }
        
        /// <remarks/>
        public void UpdateNoticeAsync(long id, string content, int fiid, object userState) {
            if ((this.UpdateNoticeOperationCompleted == null)) {
                this.UpdateNoticeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateNoticeOperationCompleted);
            }
            this.InvokeAsync("UpdateNotice", new object[] {
                        id,
                        content,
                        fiid}, this.UpdateNoticeOperationCompleted, userState);
        }
        
        private void OnUpdateNoticeOperationCompleted(object arg) {
            if ((this.UpdateNoticeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateNoticeCompleted(this, new UpdateNoticeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AddNotice", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool AddNotice(int fiid, string content) {
            object[] results = this.Invoke("AddNotice", new object[] {
                        fiid,
                        content});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void AddNoticeAsync(int fiid, string content) {
            this.AddNoticeAsync(fiid, content, null);
        }
        
        /// <remarks/>
        public void AddNoticeAsync(int fiid, string content, object userState) {
            if ((this.AddNoticeOperationCompleted == null)) {
                this.AddNoticeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddNoticeOperationCompleted);
            }
            this.InvokeAsync("AddNotice", new object[] {
                        fiid,
                        content}, this.AddNoticeOperationCompleted, userState);
        }
        
        private void OnAddNoticeOperationCompleted(object arg) {
            if ((this.AddNoticeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddNoticeCompleted(this, new AddNoticeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetUserInfo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetUserInfo(int id, bool login) {
            object[] results = this.Invoke("GetUserInfo", new object[] {
                        id,
                        login});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetUserInfoAsync(int id, bool login) {
            this.GetUserInfoAsync(id, login, null);
        }
        
        /// <remarks/>
        public void GetUserInfoAsync(int id, bool login, object userState) {
            if ((this.GetUserInfoOperationCompleted == null)) {
                this.GetUserInfoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetUserInfoOperationCompleted);
            }
            this.InvokeAsync("GetUserInfo", new object[] {
                        id,
                        login}, this.GetUserInfoOperationCompleted, userState);
        }
        
        private void OnGetUserInfoOperationCompleted(object arg) {
            if ((this.GetUserInfoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetUserInfoCompleted(this, new GetUserInfoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetLatestNews", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public View_NewsType[] GetLatestNews(int pageSize, int pageIndex) {
            object[] results = this.Invoke("GetLatestNews", new object[] {
                        pageSize,
                        pageIndex});
            return ((View_NewsType[])(results[0]));
        }
        
        /// <remarks/>
        public void GetLatestNewsAsync(int pageSize, int pageIndex) {
            this.GetLatestNewsAsync(pageSize, pageIndex, null);
        }
        
        /// <remarks/>
        public void GetLatestNewsAsync(int pageSize, int pageIndex, object userState) {
            if ((this.GetLatestNewsOperationCompleted == null)) {
                this.GetLatestNewsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetLatestNewsOperationCompleted);
            }
            this.InvokeAsync("GetLatestNews", new object[] {
                        pageSize,
                        pageIndex}, this.GetLatestNewsOperationCompleted, userState);
        }
        
        private void OnGetLatestNewsOperationCompleted(object arg) {
            if ((this.GetLatestNewsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetLatestNewsCompleted(this, new GetLatestNewsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.1433")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class View_NewsType {
        
        private int type_IDField;
        
        private string type_ActionField;
        
        private string type_UrlField;
        
        private long news_IDField;
        
        private System.Nullable<int> news_FromTxzIDField;
        
        private System.Nullable<int> news_ToTxzIDField;
        
        private string news_TitleField;
        
        private string news_ContentField;
        
        private System.Nullable<int> news_UrlTypeIDField;
        
        private System.Nullable<int> news_UrlIDField;
        
        private System.Nullable<System.DateTime> news_CreateTimeField;
        
        private System.Nullable<bool> news_IsNewField;
        
        /// <remarks/>
        public int Type_ID {
            get {
                return this.type_IDField;
            }
            set {
                this.type_IDField = value;
            }
        }
        
        /// <remarks/>
        public string Type_Action {
            get {
                return this.type_ActionField;
            }
            set {
                this.type_ActionField = value;
            }
        }
        
        /// <remarks/>
        public string Type_Url {
            get {
                return this.type_UrlField;
            }
            set {
                this.type_UrlField = value;
            }
        }
        
        /// <remarks/>
        public long News_ID {
            get {
                return this.news_IDField;
            }
            set {
                this.news_IDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> News_FromTxzID {
            get {
                return this.news_FromTxzIDField;
            }
            set {
                this.news_FromTxzIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> News_ToTxzID {
            get {
                return this.news_ToTxzIDField;
            }
            set {
                this.news_ToTxzIDField = value;
            }
        }
        
        /// <remarks/>
        public string News_Title {
            get {
                return this.news_TitleField;
            }
            set {
                this.news_TitleField = value;
            }
        }
        
        /// <remarks/>
        public string News_Content {
            get {
                return this.news_ContentField;
            }
            set {
                this.news_ContentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> News_UrlTypeID {
            get {
                return this.news_UrlTypeIDField;
            }
            set {
                this.news_UrlTypeIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> News_UrlID {
            get {
                return this.news_UrlIDField;
            }
            set {
                this.news_UrlIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> News_CreateTime {
            get {
                return this.news_CreateTimeField;
            }
            set {
                this.news_CreateTimeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<bool> News_IsNew {
            get {
                return this.news_IsNewField;
            }
            set {
                this.news_IsNewField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void HelloWorldCompletedEventHandler(object sender, HelloWorldCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void AddNewsCompletedEventHandler(object sender, AddNewsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AddNewsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AddNewsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void UpdateNoticeCompletedEventHandler(object sender, UpdateNoticeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateNoticeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateNoticeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void AddNoticeCompletedEventHandler(object sender, AddNoticeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AddNoticeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AddNoticeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void GetUserInfoCompletedEventHandler(object sender, GetUserInfoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetUserInfoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetUserInfoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void GetLatestNewsCompletedEventHandler(object sender, GetLatestNewsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetLatestNewsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetLatestNewsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public View_NewsType[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((View_NewsType[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591