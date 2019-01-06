﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GeoLib.Client.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IGeoService")]
    public interface IGeoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGeoService/GetZipInfo", ReplyAction="http://tempuri.org/IGeoService/GetZipInfoResponse")]
        GeoLib.Contracts.ZipCodeData GetZipInfo(string zip);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGeoService/GetZipInfo", ReplyAction="http://tempuri.org/IGeoService/GetZipInfoResponse")]
        System.Threading.Tasks.Task<GeoLib.Contracts.ZipCodeData> GetZipInfoAsync(string zip);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGeoService/GetStates", ReplyAction="http://tempuri.org/IGeoService/GetStatesResponse")]
        string[] GetStates(bool primaryOnly);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGeoService/GetStates", ReplyAction="http://tempuri.org/IGeoService/GetStatesResponse")]
        System.Threading.Tasks.Task<string[]> GetStatesAsync(bool primaryOnly);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGeoService/GetZipsByState", ReplyAction="http://tempuri.org/IGeoService/GetZipsByStateResponse")]
        GeoLib.Contracts.ZipCodeData[] GetZipsByState(string state);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGeoService/GetZipsByState", ReplyAction="http://tempuri.org/IGeoService/GetZipsByStateResponse")]
        System.Threading.Tasks.Task<GeoLib.Contracts.ZipCodeData[]> GetZipsByStateAsync(string state);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGeoService/GetZipsByRange", ReplyAction="http://tempuri.org/IGeoService/GetZipsByRangeResponse")]
        GeoLib.Contracts.ZipCodeData[] GetZipsByRange(string zip, int range);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGeoService/GetZipsByRange", ReplyAction="http://tempuri.org/IGeoService/GetZipsByRangeResponse")]
        System.Threading.Tasks.Task<GeoLib.Contracts.ZipCodeData[]> GetZipsByRangeAsync(string zip, int range);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGeoServiceChannel : GeoLib.Client.ServiceReference1.IGeoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GeoServiceClient : System.ServiceModel.ClientBase<GeoLib.Client.ServiceReference1.IGeoService>, GeoLib.Client.ServiceReference1.IGeoService {
        
        public GeoServiceClient() {
        }
        
        public GeoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GeoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GeoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GeoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public GeoLib.Contracts.ZipCodeData GetZipInfo(string zip) {
            return base.Channel.GetZipInfo(zip);
        }
        
        public System.Threading.Tasks.Task<GeoLib.Contracts.ZipCodeData> GetZipInfoAsync(string zip) {
            return base.Channel.GetZipInfoAsync(zip);
        }
        
        public string[] GetStates(bool primaryOnly) {
            return base.Channel.GetStates(primaryOnly);
        }
        
        public System.Threading.Tasks.Task<string[]> GetStatesAsync(bool primaryOnly) {
            return base.Channel.GetStatesAsync(primaryOnly);
        }
        
        public GeoLib.Contracts.ZipCodeData[] GetZipsByState(string state) {
            return base.Channel.GetZipsByState(state);
        }
        
        public System.Threading.Tasks.Task<GeoLib.Contracts.ZipCodeData[]> GetZipsByStateAsync(string state) {
            return base.Channel.GetZipsByStateAsync(state);
        }
        
        public GeoLib.Contracts.ZipCodeData[] GetZipsByRange(string zip, int range) {
            return base.Channel.GetZipsByRange(zip, range);
        }
        
        public System.Threading.Tasks.Task<GeoLib.Contracts.ZipCodeData[]> GetZipsByRangeAsync(string zip, int range) {
            return base.Channel.GetZipsByRangeAsync(zip, range);
        }
    }
}
