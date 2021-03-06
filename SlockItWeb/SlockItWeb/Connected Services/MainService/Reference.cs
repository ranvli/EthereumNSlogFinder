﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SlockItWeb.MainService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SearchParameter", Namespace="http://schemas.datacontract.org/2004/07/SockitAPI.Model")]
    [System.SerializableAttribute()]
    public partial class SearchParameter : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AnyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ulong BlockNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ENameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ulong FromField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Any {
            get {
                return this.AnyField;
            }
            set {
                if ((object.ReferenceEquals(this.AnyField, value) != true)) {
                    this.AnyField = value;
                    this.RaisePropertyChanged("Any");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ulong BlockNumber {
            get {
                return this.BlockNumberField;
            }
            set {
                if ((this.BlockNumberField.Equals(value) != true)) {
                    this.BlockNumberField = value;
                    this.RaisePropertyChanged("BlockNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EName {
            get {
                return this.ENameField;
            }
            set {
                if ((object.ReferenceEquals(this.ENameField, value) != true)) {
                    this.ENameField = value;
                    this.RaisePropertyChanged("EName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ulong From {
            get {
                return this.FromField;
            }
            set {
                if ((this.FromField.Equals(value) != true)) {
                    this.FromField = value;
                    this.RaisePropertyChanged("From");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ENSHistoryDomain", Namespace="http://schemas.datacontract.org/2004/07/SockitAPI.Model")]
    [System.SerializableAttribute()]
    public partial class ENSHistoryDomain : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AuthorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BlockHashField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ulong BlockNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NumberOfTransactionsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ulong TimeStampField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Author {
            get {
                return this.AuthorField;
            }
            set {
                if ((object.ReferenceEquals(this.AuthorField, value) != true)) {
                    this.AuthorField = value;
                    this.RaisePropertyChanged("Author");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BlockHash {
            get {
                return this.BlockHashField;
            }
            set {
                if ((object.ReferenceEquals(this.BlockHashField, value) != true)) {
                    this.BlockHashField = value;
                    this.RaisePropertyChanged("BlockHash");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ulong BlockNumber {
            get {
                return this.BlockNumberField;
            }
            set {
                if ((this.BlockNumberField.Equals(value) != true)) {
                    this.BlockNumberField = value;
                    this.RaisePropertyChanged("BlockNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NumberOfTransactions {
            get {
                return this.NumberOfTransactionsField;
            }
            set {
                if ((this.NumberOfTransactionsField.Equals(value) != true)) {
                    this.NumberOfTransactionsField = value;
                    this.RaisePropertyChanged("NumberOfTransactions");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ulong TimeStamp {
            get {
                return this.TimeStampField;
            }
            set {
                if ((this.TimeStampField.Equals(value) != true)) {
                    this.TimeStampField = value;
                    this.RaisePropertyChanged("TimeStamp");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TransactionDomain", Namespace="http://schemas.datacontract.org/2004/07/SockitAPI.Model")]
    [System.SerializableAttribute()]
    public partial class TransactionDomain : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FromField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long GasField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long GasPriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string InputField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ToField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TransactionHashField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long TransactionIndexField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string From {
            get {
                return this.FromField;
            }
            set {
                if ((object.ReferenceEquals(this.FromField, value) != true)) {
                    this.FromField = value;
                    this.RaisePropertyChanged("From");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long Gas {
            get {
                return this.GasField;
            }
            set {
                if ((this.GasField.Equals(value) != true)) {
                    this.GasField = value;
                    this.RaisePropertyChanged("Gas");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long GasPrice {
            get {
                return this.GasPriceField;
            }
            set {
                if ((this.GasPriceField.Equals(value) != true)) {
                    this.GasPriceField = value;
                    this.RaisePropertyChanged("GasPrice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Input {
            get {
                return this.InputField;
            }
            set {
                if ((object.ReferenceEquals(this.InputField, value) != true)) {
                    this.InputField = value;
                    this.RaisePropertyChanged("Input");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string To {
            get {
                return this.ToField;
            }
            set {
                if ((object.ReferenceEquals(this.ToField, value) != true)) {
                    this.ToField = value;
                    this.RaisePropertyChanged("To");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TransactionHash {
            get {
                return this.TransactionHashField;
            }
            set {
                if ((object.ReferenceEquals(this.TransactionHashField, value) != true)) {
                    this.TransactionHashField = value;
                    this.RaisePropertyChanged("TransactionHash");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long TransactionIndex {
            get {
                return this.TransactionIndexField;
            }
            set {
                if ((this.TransactionIndexField.Equals(value) != true)) {
                    this.TransactionIndexField = value;
                    this.RaisePropertyChanged("TransactionIndex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Value {
            get {
                return this.ValueField;
            }
            set {
                if ((object.ReferenceEquals(this.ValueField, value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MainService.IENSService")]
    public interface IENSService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IENSService/GetHistoryAny", ReplyAction="http://tempuri.org/IENSService/GetHistoryAnyResponse")]
        SlockItWeb.MainService.ENSHistoryDomain[] GetHistoryAny(SlockItWeb.MainService.SearchParameter param);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IENSService/GetHistoryAny", ReplyAction="http://tempuri.org/IENSService/GetHistoryAnyResponse")]
        System.Threading.Tasks.Task<SlockItWeb.MainService.ENSHistoryDomain[]> GetHistoryAnyAsync(SlockItWeb.MainService.SearchParameter param);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IENSService/GetHistoryByENAndTimeFrom", ReplyAction="http://tempuri.org/IENSService/GetHistoryByENAndTimeFromResponse")]
        SlockItWeb.MainService.ENSHistoryDomain[] GetHistoryByENAndTimeFrom(SlockItWeb.MainService.SearchParameter param);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IENSService/GetHistoryByENAndTimeFrom", ReplyAction="http://tempuri.org/IENSService/GetHistoryByENAndTimeFromResponse")]
        System.Threading.Tasks.Task<SlockItWeb.MainService.ENSHistoryDomain[]> GetHistoryByENAndTimeFromAsync(SlockItWeb.MainService.SearchParameter param);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IENSService/GetHistoryByAddressAndTimeFrom", ReplyAction="http://tempuri.org/IENSService/GetHistoryByAddressAndTimeFromResponse")]
        SlockItWeb.MainService.ENSHistoryDomain[] GetHistoryByAddressAndTimeFrom(SlockItWeb.MainService.SearchParameter param);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IENSService/GetHistoryByAddressAndTimeFrom", ReplyAction="http://tempuri.org/IENSService/GetHistoryByAddressAndTimeFromResponse")]
        System.Threading.Tasks.Task<SlockItWeb.MainService.ENSHistoryDomain[]> GetHistoryByAddressAndTimeFromAsync(SlockItWeb.MainService.SearchParameter param);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IENSService/GetTransactionsByBlockNumber", ReplyAction="http://tempuri.org/IENSService/GetTransactionsByBlockNumberResponse")]
        SlockItWeb.MainService.TransactionDomain[] GetTransactionsByBlockNumber(SlockItWeb.MainService.SearchParameter param);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IENSService/GetTransactionsByBlockNumber", ReplyAction="http://tempuri.org/IENSService/GetTransactionsByBlockNumberResponse")]
        System.Threading.Tasks.Task<SlockItWeb.MainService.TransactionDomain[]> GetTransactionsByBlockNumberAsync(SlockItWeb.MainService.SearchParameter param);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IENSServiceChannel : SlockItWeb.MainService.IENSService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ENSServiceClient : System.ServiceModel.ClientBase<SlockItWeb.MainService.IENSService>, SlockItWeb.MainService.IENSService {
        
        public ENSServiceClient() {
        }
        
        public ENSServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ENSServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ENSServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ENSServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SlockItWeb.MainService.ENSHistoryDomain[] GetHistoryAny(SlockItWeb.MainService.SearchParameter param) {
            return base.Channel.GetHistoryAny(param);
        }
        
        public System.Threading.Tasks.Task<SlockItWeb.MainService.ENSHistoryDomain[]> GetHistoryAnyAsync(SlockItWeb.MainService.SearchParameter param) {
            return base.Channel.GetHistoryAnyAsync(param);
        }
        
        public SlockItWeb.MainService.ENSHistoryDomain[] GetHistoryByENAndTimeFrom(SlockItWeb.MainService.SearchParameter param) {
            return base.Channel.GetHistoryByENAndTimeFrom(param);
        }
        
        public System.Threading.Tasks.Task<SlockItWeb.MainService.ENSHistoryDomain[]> GetHistoryByENAndTimeFromAsync(SlockItWeb.MainService.SearchParameter param) {
            return base.Channel.GetHistoryByENAndTimeFromAsync(param);
        }
        
        public SlockItWeb.MainService.ENSHistoryDomain[] GetHistoryByAddressAndTimeFrom(SlockItWeb.MainService.SearchParameter param) {
            return base.Channel.GetHistoryByAddressAndTimeFrom(param);
        }
        
        public System.Threading.Tasks.Task<SlockItWeb.MainService.ENSHistoryDomain[]> GetHistoryByAddressAndTimeFromAsync(SlockItWeb.MainService.SearchParameter param) {
            return base.Channel.GetHistoryByAddressAndTimeFromAsync(param);
        }
        
        public SlockItWeb.MainService.TransactionDomain[] GetTransactionsByBlockNumber(SlockItWeb.MainService.SearchParameter param) {
            return base.Channel.GetTransactionsByBlockNumber(param);
        }
        
        public System.Threading.Tasks.Task<SlockItWeb.MainService.TransactionDomain[]> GetTransactionsByBlockNumberAsync(SlockItWeb.MainService.SearchParameter param) {
            return base.Channel.GetTransactionsByBlockNumberAsync(param);
        }
    }
}
