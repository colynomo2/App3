﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace App3.ro.infovalutar.www {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="CursSoap", Namespace="http://www.infovalutar.ro/")]
    public partial class Curs : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetLatestValueOperationCompleted;
        
        private System.Threading.SendOrPostCallback getlatestvalueOperationCompleted;
        
        private System.Threading.SendOrPostCallback getallOperationCompleted;
        
        private System.Threading.SendOrPostCallback getvalueOperationCompleted;
        
        private System.Threading.SendOrPostCallback getvalueadvOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetValueOperationCompleted;
        
        private System.Threading.SendOrPostCallback LastDateInsertedOperationCompleted;
        
        private System.Threading.SendOrPostCallback lastdateinsertedOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Curs() {
            this.Url = "http://www.infovalutar.ro/curs.asmx";
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
        public event GetLatestValueCompletedEventHandler GetLatestValueCompleted;
        
        /// <remarks/>
        public event getlatestvalueCompletedEventHandler getlatestvalueCompleted;
        
        /// <remarks/>
        public event getallCompletedEventHandler getallCompleted;
        
        /// <remarks/>
        public event getvalueCompletedEventHandler getvalueCompleted;
        
        /// <remarks/>
        public event getvalueadvCompletedEventHandler getvalueadvCompleted;
        
        /// <remarks/>
        public event GetValueCompletedEventHandler GetValueCompleted;
        
        /// <remarks/>
        public event LastDateInsertedCompletedEventHandler LastDateInsertedCompleted;
        
        /// <remarks/>
        public event lastdateinsertedCompletedEventHandler lastdateinsertedCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.infovalutar.ro/GetLatestValue", RequestNamespace="http://www.infovalutar.ro/", ResponseNamespace="http://www.infovalutar.ro/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public double GetLatestValue(string Moneda) {
            object[] results = this.Invoke("GetLatestValue", new object[] {
                        Moneda});
            return ((double)(results[0]));
        }
        
        /// <remarks/>
        public void GetLatestValueAsync(string Moneda) {
            this.GetLatestValueAsync(Moneda, null);
        }
        
        /// <remarks/>
        public void GetLatestValueAsync(string Moneda, object userState) {
            if ((this.GetLatestValueOperationCompleted == null)) {
                this.GetLatestValueOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetLatestValueOperationCompleted);
            }
            this.InvokeAsync("GetLatestValue", new object[] {
                        Moneda}, this.GetLatestValueOperationCompleted, userState);
        }
        
        private void OnGetLatestValueOperationCompleted(object arg) {
            if ((this.GetLatestValueCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetLatestValueCompleted(this, new GetLatestValueCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.infovalutar.ro/getlatestvalue", RequestNamespace="http://www.infovalutar.ro/", ResponseNamespace="http://www.infovalutar.ro/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public double getlatestvalue(string Moneda) {
            object[] results = this.Invoke("getlatestvalue", new object[] {
                        Moneda});
            return ((double)(results[0]));
        }
        
        /// <remarks/>
        public void getlatestvalueAsync(string Moneda) {
            this.getlatestvalueAsync(Moneda, null);
        }
        
        /// <remarks/>
        public void getlatestvalueAsync(string Moneda, object userState) {
            if ((this.getlatestvalueOperationCompleted == null)) {
                this.getlatestvalueOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetlatestvalueOperationCompleted);
            }
            this.InvokeAsync("getlatestvalue", new object[] {
                        Moneda}, this.getlatestvalueOperationCompleted, userState);
        }
        
        private void OngetlatestvalueOperationCompleted(object arg) {
            if ((this.getlatestvalueCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getlatestvalueCompleted(this, new getlatestvalueCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.infovalutar.ro/getall", RequestNamespace="http://www.infovalutar.ro/", ResponseNamespace="http://www.infovalutar.ro/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable getall(System.DateTime dt) {
            object[] results = this.Invoke("getall", new object[] {
                        dt});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void getallAsync(System.DateTime dt) {
            this.getallAsync(dt, null);
        }
        
        /// <remarks/>
        public void getallAsync(System.DateTime dt, object userState) {
            if ((this.getallOperationCompleted == null)) {
                this.getallOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetallOperationCompleted);
            }
            this.InvokeAsync("getall", new object[] {
                        dt}, this.getallOperationCompleted, userState);
        }
        
        private void OngetallOperationCompleted(object arg) {
            if ((this.getallCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getallCompleted(this, new getallCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.infovalutar.ro/getvalue", RequestNamespace="http://www.infovalutar.ro/", ResponseNamespace="http://www.infovalutar.ro/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public double getvalue(System.DateTime TheDate, string Moneda) {
            object[] results = this.Invoke("getvalue", new object[] {
                        TheDate,
                        Moneda});
            return ((double)(results[0]));
        }
        
        /// <remarks/>
        public void getvalueAsync(System.DateTime TheDate, string Moneda) {
            this.getvalueAsync(TheDate, Moneda, null);
        }
        
        /// <remarks/>
        public void getvalueAsync(System.DateTime TheDate, string Moneda, object userState) {
            if ((this.getvalueOperationCompleted == null)) {
                this.getvalueOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetvalueOperationCompleted);
            }
            this.InvokeAsync("getvalue", new object[] {
                        TheDate,
                        Moneda}, this.getvalueOperationCompleted, userState);
        }
        
        private void OngetvalueOperationCompleted(object arg) {
            if ((this.getvalueCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getvalueCompleted(this, new getvalueCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.infovalutar.ro/getvalueadv", RequestNamespace="http://www.infovalutar.ro/", ResponseNamespace="http://www.infovalutar.ro/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public DateValue getvalueadv(System.DateTime thedate, string themoneda) {
            object[] results = this.Invoke("getvalueadv", new object[] {
                        thedate,
                        themoneda});
            return ((DateValue)(results[0]));
        }
        
        /// <remarks/>
        public void getvalueadvAsync(System.DateTime thedate, string themoneda) {
            this.getvalueadvAsync(thedate, themoneda, null);
        }
        
        /// <remarks/>
        public void getvalueadvAsync(System.DateTime thedate, string themoneda, object userState) {
            if ((this.getvalueadvOperationCompleted == null)) {
                this.getvalueadvOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetvalueadvOperationCompleted);
            }
            this.InvokeAsync("getvalueadv", new object[] {
                        thedate,
                        themoneda}, this.getvalueadvOperationCompleted, userState);
        }
        
        private void OngetvalueadvOperationCompleted(object arg) {
            if ((this.getvalueadvCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getvalueadvCompleted(this, new getvalueadvCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.infovalutar.ro/GetValue", RequestNamespace="http://www.infovalutar.ro/", ResponseNamespace="http://www.infovalutar.ro/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public double GetValue(System.DateTime TheDate, string Moneda) {
            object[] results = this.Invoke("GetValue", new object[] {
                        TheDate,
                        Moneda});
            return ((double)(results[0]));
        }
        
        /// <remarks/>
        public void GetValueAsync(System.DateTime TheDate, string Moneda) {
            this.GetValueAsync(TheDate, Moneda, null);
        }
        
        /// <remarks/>
        public void GetValueAsync(System.DateTime TheDate, string Moneda, object userState) {
            if ((this.GetValueOperationCompleted == null)) {
                this.GetValueOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetValueOperationCompleted);
            }
            this.InvokeAsync("GetValue", new object[] {
                        TheDate,
                        Moneda}, this.GetValueOperationCompleted, userState);
        }
        
        private void OnGetValueOperationCompleted(object arg) {
            if ((this.GetValueCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetValueCompleted(this, new GetValueCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.infovalutar.ro/LastDateInserted", RequestNamespace="http://www.infovalutar.ro/", ResponseNamespace="http://www.infovalutar.ro/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.DateTime LastDateInserted() {
            object[] results = this.Invoke("LastDateInserted", new object[0]);
            return ((System.DateTime)(results[0]));
        }
        
        /// <remarks/>
        public void LastDateInsertedAsync() {
            this.LastDateInsertedAsync(null);
        }
        
        /// <remarks/>
        public void LastDateInsertedAsync(object userState) {
            if ((this.LastDateInsertedOperationCompleted == null)) {
                this.LastDateInsertedOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLastDateInsertedOperationCompleted);
            }
            this.InvokeAsync("LastDateInserted", new object[0], this.LastDateInsertedOperationCompleted, userState);
        }
        
        private void OnLastDateInsertedOperationCompleted(object arg) {
            if ((this.LastDateInsertedCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LastDateInsertedCompleted(this, new LastDateInsertedCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.infovalutar.ro/lastdateinserted", RequestNamespace="http://www.infovalutar.ro/", ResponseNamespace="http://www.infovalutar.ro/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.DateTime lastdateinserted() {
            object[] results = this.Invoke("lastdateinserted", new object[0]);
            return ((System.DateTime)(results[0]));
        }
        
        /// <remarks/>
        public void lastdateinsertedAsync() {
            this.lastdateinsertedAsync(null);
        }
        
        /// <remarks/>
        public void lastdateinsertedAsync(object userState) {
            if ((this.lastdateinsertedOperationCompleted == null)) {
                this.lastdateinsertedOperationCompleted = new System.Threading.SendOrPostCallback(this.OnlastdateinsertedOperationCompleted);
            }
            this.InvokeAsync("lastdateinserted", new object[0], this.lastdateinsertedOperationCompleted, userState);
        }
        
        private void OnlastdateinsertedOperationCompleted(object arg) {
            if ((this.lastdateinsertedCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.lastdateinsertedCompleted(this, new lastdateinsertedCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.infovalutar.ro/")]
    public partial class DateValue {
        
        private System.DateTime dateField;
        
        private double valueField;
        
        private string monedaField;
        
        /// <remarks/>
        public System.DateTime date {
            get {
                return this.dateField;
            }
            set {
                this.dateField = value;
            }
        }
        
        /// <remarks/>
        public double value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
        
        /// <remarks/>
        public string moneda {
            get {
                return this.monedaField;
            }
            set {
                this.monedaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetLatestValueCompletedEventHandler(object sender, GetLatestValueCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetLatestValueCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetLatestValueCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public double Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((double)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void getlatestvalueCompletedEventHandler(object sender, getlatestvalueCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getlatestvalueCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getlatestvalueCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public double Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((double)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void getallCompletedEventHandler(object sender, getallCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getallCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getallCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void getvalueCompletedEventHandler(object sender, getvalueCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getvalueCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getvalueCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public double Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((double)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void getvalueadvCompletedEventHandler(object sender, getvalueadvCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getvalueadvCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getvalueadvCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public DateValue Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((DateValue)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetValueCompletedEventHandler(object sender, GetValueCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetValueCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetValueCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public double Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((double)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void LastDateInsertedCompletedEventHandler(object sender, LastDateInsertedCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LastDateInsertedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LastDateInsertedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.DateTime Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.DateTime)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void lastdateinsertedCompletedEventHandler(object sender, lastdateinsertedCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class lastdateinsertedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal lastdateinsertedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.DateTime Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.DateTime)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591