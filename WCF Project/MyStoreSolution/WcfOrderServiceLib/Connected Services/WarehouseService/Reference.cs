﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfOrderServiceLib.WarehouseService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WarehouseService.IWarehouseService")]
    public interface IWarehouseService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWarehouseService/GetStockValue", ReplyAction="http://tempuri.org/IWarehouseService/GetStockValueResponse")]
        int GetStockValue(string skuId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWarehouseService/GetStockValue", ReplyAction="http://tempuri.org/IWarehouseService/GetStockValueResponse")]
        System.Threading.Tasks.Task<int> GetStockValueAsync(string skuId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWarehouseService/SetStockValue", ReplyAction="http://tempuri.org/IWarehouseService/SetStockValueResponse")]
        bool SetStockValue(string skuId, int Qtd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWarehouseService/SetStockValue", ReplyAction="http://tempuri.org/IWarehouseService/SetStockValueResponse")]
        System.Threading.Tasks.Task<bool> SetStockValueAsync(string skuId, int Qtd);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWarehouseServiceChannel : WcfOrderServiceLib.WarehouseService.IWarehouseService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WarehouseServiceClient : System.ServiceModel.ClientBase<WcfOrderServiceLib.WarehouseService.IWarehouseService>, WcfOrderServiceLib.WarehouseService.IWarehouseService {
        
        public WarehouseServiceClient() {
        }
        
        public WarehouseServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WarehouseServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WarehouseServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WarehouseServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int GetStockValue(string skuId) {
            return base.Channel.GetStockValue(skuId);
        }
        
        public System.Threading.Tasks.Task<int> GetStockValueAsync(string skuId) {
            return base.Channel.GetStockValueAsync(skuId);
        }
        
        public bool SetStockValue(string skuId, int Qtd) {
            return base.Channel.SetStockValue(skuId, Qtd);
        }
        
        public System.Threading.Tasks.Task<bool> SetStockValueAsync(string skuId, int Qtd) {
            return base.Channel.SetStockValueAsync(skuId, Qtd);
        }
    }
}
