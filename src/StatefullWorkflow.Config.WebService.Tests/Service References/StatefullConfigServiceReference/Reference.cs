﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StatefullWorkflow.Config.WebService.Test.StatefullConfigServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WorkflowDC", Namespace="http://schemas.datacontract.org/2004/07/StatefullWorkflow.Config.WebService.DataC" +
        "ontracts")]
    [System.SerializableAttribute()]
    public partial class WorkflowDC : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private StatefullWorkflow.Config.WebService.Test.StatefullConfigServiceReference.StateActivityDC[] ActivitiesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DisplayNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StartStateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private StatefullWorkflow.Config.WebService.Test.StatefullConfigServiceReference.StateDC[] StatesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private StatefullWorkflow.Config.WebService.Test.StatefullConfigServiceReference.StateTransitionDC[] TransitionsField;
        
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
        public StatefullWorkflow.Config.WebService.Test.StatefullConfigServiceReference.StateActivityDC[] Activities {
            get {
                return this.ActivitiesField;
            }
            set {
                if ((object.ReferenceEquals(this.ActivitiesField, value) != true)) {
                    this.ActivitiesField = value;
                    this.RaisePropertyChanged("Activities");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DisplayName {
            get {
                return this.DisplayNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DisplayNameField, value) != true)) {
                    this.DisplayNameField = value;
                    this.RaisePropertyChanged("DisplayName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Id {
            get {
                return this.IdField;
            }
            set {
                if ((object.ReferenceEquals(this.IdField, value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StartState {
            get {
                return this.StartStateField;
            }
            set {
                if ((object.ReferenceEquals(this.StartStateField, value) != true)) {
                    this.StartStateField = value;
                    this.RaisePropertyChanged("StartState");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public StatefullWorkflow.Config.WebService.Test.StatefullConfigServiceReference.StateDC[] States {
            get {
                return this.StatesField;
            }
            set {
                if ((object.ReferenceEquals(this.StatesField, value) != true)) {
                    this.StatesField = value;
                    this.RaisePropertyChanged("States");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public StatefullWorkflow.Config.WebService.Test.StatefullConfigServiceReference.StateTransitionDC[] Transitions {
            get {
                return this.TransitionsField;
            }
            set {
                if ((object.ReferenceEquals(this.TransitionsField, value) != true)) {
                    this.TransitionsField = value;
                    this.RaisePropertyChanged("Transitions");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="StateActivityDC", Namespace="http://schemas.datacontract.org/2004/07/StatefullWorkflow.Config.WebService.DataC" +
        "ontracts")]
    [System.SerializableAttribute()]
    public partial class StateActivityDC : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] AuthorisedRolesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] AuthorisedUsersField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DisplayNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StateIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WorkflowIdField;
        
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
        public string[] AuthorisedRoles {
            get {
                return this.AuthorisedRolesField;
            }
            set {
                if ((object.ReferenceEquals(this.AuthorisedRolesField, value) != true)) {
                    this.AuthorisedRolesField = value;
                    this.RaisePropertyChanged("AuthorisedRoles");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] AuthorisedUsers {
            get {
                return this.AuthorisedUsersField;
            }
            set {
                if ((object.ReferenceEquals(this.AuthorisedUsersField, value) != true)) {
                    this.AuthorisedUsersField = value;
                    this.RaisePropertyChanged("AuthorisedUsers");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DisplayName {
            get {
                return this.DisplayNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DisplayNameField, value) != true)) {
                    this.DisplayNameField = value;
                    this.RaisePropertyChanged("DisplayName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Id {
            get {
                return this.IdField;
            }
            set {
                if ((object.ReferenceEquals(this.IdField, value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StateId {
            get {
                return this.StateIdField;
            }
            set {
                if ((object.ReferenceEquals(this.StateIdField, value) != true)) {
                    this.StateIdField = value;
                    this.RaisePropertyChanged("StateId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string WorkflowId {
            get {
                return this.WorkflowIdField;
            }
            set {
                if ((object.ReferenceEquals(this.WorkflowIdField, value) != true)) {
                    this.WorkflowIdField = value;
                    this.RaisePropertyChanged("WorkflowId");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="StateDC", Namespace="http://schemas.datacontract.org/2004/07/StatefullWorkflow.Config.WebService.DataC" +
        "ontracts")]
    [System.SerializableAttribute()]
    public partial class StateDC : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DisplayNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OnEntryStateActionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OnExitStateActionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WorkflowIdField;
        
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
        public string DisplayName {
            get {
                return this.DisplayNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DisplayNameField, value) != true)) {
                    this.DisplayNameField = value;
                    this.RaisePropertyChanged("DisplayName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Id {
            get {
                return this.IdField;
            }
            set {
                if ((object.ReferenceEquals(this.IdField, value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OnEntryStateAction {
            get {
                return this.OnEntryStateActionField;
            }
            set {
                if ((object.ReferenceEquals(this.OnEntryStateActionField, value) != true)) {
                    this.OnEntryStateActionField = value;
                    this.RaisePropertyChanged("OnEntryStateAction");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OnExitStateAction {
            get {
                return this.OnExitStateActionField;
            }
            set {
                if ((object.ReferenceEquals(this.OnExitStateActionField, value) != true)) {
                    this.OnExitStateActionField = value;
                    this.RaisePropertyChanged("OnExitStateAction");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string WorkflowId {
            get {
                return this.WorkflowIdField;
            }
            set {
                if ((object.ReferenceEquals(this.WorkflowIdField, value) != true)) {
                    this.WorkflowIdField = value;
                    this.RaisePropertyChanged("WorkflowId");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="StateTransitionDC", Namespace="http://schemas.datacontract.org/2004/07/StatefullWorkflow.Config.WebService.DataC" +
        "ontracts")]
    [System.SerializableAttribute()]
    public partial class StateTransitionDC : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DisplayNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StateIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TargetStateIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TriggerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WorkflowIdField;
        
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
        public string DisplayName {
            get {
                return this.DisplayNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DisplayNameField, value) != true)) {
                    this.DisplayNameField = value;
                    this.RaisePropertyChanged("DisplayName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Id {
            get {
                return this.IdField;
            }
            set {
                if ((object.ReferenceEquals(this.IdField, value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StateId {
            get {
                return this.StateIdField;
            }
            set {
                if ((object.ReferenceEquals(this.StateIdField, value) != true)) {
                    this.StateIdField = value;
                    this.RaisePropertyChanged("StateId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TargetStateId {
            get {
                return this.TargetStateIdField;
            }
            set {
                if ((object.ReferenceEquals(this.TargetStateIdField, value) != true)) {
                    this.TargetStateIdField = value;
                    this.RaisePropertyChanged("TargetStateId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Trigger {
            get {
                return this.TriggerField;
            }
            set {
                if ((object.ReferenceEquals(this.TriggerField, value) != true)) {
                    this.TriggerField = value;
                    this.RaisePropertyChanged("Trigger");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string WorkflowId {
            get {
                return this.WorkflowIdField;
            }
            set {
                if ((object.ReferenceEquals(this.WorkflowIdField, value) != true)) {
                    this.WorkflowIdField = value;
                    this.RaisePropertyChanged("WorkflowId");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="StatefullConfigServiceReference.IStatefullConfig")]
    public interface IStatefullConfig {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStatefullConfig/GetData", ReplyAction="http://tempuri.org/IStatefullConfig/GetDataResponse")]
        string GetData(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStatefullConfig/GetData", ReplyAction="http://tempuri.org/IStatefullConfig/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStatefullConfig/GetWorkflow", ReplyAction="http://tempuri.org/IStatefullConfig/GetWorkflowResponse")]
        StatefullWorkflow.Config.WebService.Test.StatefullConfigServiceReference.WorkflowDC GetWorkflow(string workflowId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStatefullConfig/GetWorkflow", ReplyAction="http://tempuri.org/IStatefullConfig/GetWorkflowResponse")]
        System.Threading.Tasks.Task<StatefullWorkflow.Config.WebService.Test.StatefullConfigServiceReference.WorkflowDC> GetWorkflowAsync(string workflowId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStatefullConfig/UpdateWorkflow", ReplyAction="http://tempuri.org/IStatefullConfig/UpdateWorkflowResponse")]
        bool UpdateWorkflow(StatefullWorkflow.Config.WebService.Test.StatefullConfigServiceReference.WorkflowDC workflow);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStatefullConfig/UpdateWorkflow", ReplyAction="http://tempuri.org/IStatefullConfig/UpdateWorkflowResponse")]
        System.Threading.Tasks.Task<bool> UpdateWorkflowAsync(StatefullWorkflow.Config.WebService.Test.StatefullConfigServiceReference.WorkflowDC workflow);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStatefullConfig/InsertWorkflow", ReplyAction="http://tempuri.org/IStatefullConfig/InsertWorkflowResponse")]
        bool InsertWorkflow(StatefullWorkflow.Config.WebService.Test.StatefullConfigServiceReference.WorkflowDC workflow);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStatefullConfig/InsertWorkflow", ReplyAction="http://tempuri.org/IStatefullConfig/InsertWorkflowResponse")]
        System.Threading.Tasks.Task<bool> InsertWorkflowAsync(StatefullWorkflow.Config.WebService.Test.StatefullConfigServiceReference.WorkflowDC workflow);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStatefullConfigChannel : StatefullWorkflow.Config.WebService.Test.StatefullConfigServiceReference.IStatefullConfig, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StatefullConfigClient : System.ServiceModel.ClientBase<StatefullWorkflow.Config.WebService.Test.StatefullConfigServiceReference.IStatefullConfig>, StatefullWorkflow.Config.WebService.Test.StatefullConfigServiceReference.IStatefullConfig {
        
        public StatefullConfigClient() {
        }
        
        public StatefullConfigClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public StatefullConfigClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StatefullConfigClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StatefullConfigClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(string value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(string value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public StatefullWorkflow.Config.WebService.Test.StatefullConfigServiceReference.WorkflowDC GetWorkflow(string workflowId) {
            return base.Channel.GetWorkflow(workflowId);
        }
        
        public System.Threading.Tasks.Task<StatefullWorkflow.Config.WebService.Test.StatefullConfigServiceReference.WorkflowDC> GetWorkflowAsync(string workflowId) {
            return base.Channel.GetWorkflowAsync(workflowId);
        }
        
        public bool UpdateWorkflow(StatefullWorkflow.Config.WebService.Test.StatefullConfigServiceReference.WorkflowDC workflow) {
            return base.Channel.UpdateWorkflow(workflow);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateWorkflowAsync(StatefullWorkflow.Config.WebService.Test.StatefullConfigServiceReference.WorkflowDC workflow) {
            return base.Channel.UpdateWorkflowAsync(workflow);
        }
        
        public bool InsertWorkflow(StatefullWorkflow.Config.WebService.Test.StatefullConfigServiceReference.WorkflowDC workflow) {
            return base.Channel.InsertWorkflow(workflow);
        }
        
        public System.Threading.Tasks.Task<bool> InsertWorkflowAsync(StatefullWorkflow.Config.WebService.Test.StatefullConfigServiceReference.WorkflowDC workflow) {
            return base.Channel.InsertWorkflowAsync(workflow);
        }
    }
}
