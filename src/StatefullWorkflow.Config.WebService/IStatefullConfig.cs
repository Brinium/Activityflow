using StatefullWorkflow.Config.WebService.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StatefullWorkflow.Config.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IStatefullConfig
    {

        [OperationContract]
        [WebGet(UriTemplate = "GetData/{value}")]
        string GetData(string value);

        [OperationContract]
        [WebGet(UriTemplate = "GetWorkflow?workflowId={workflowId}")]
        WorkflowDC GetWorkflow(string workflowId);

        [OperationContract]
        [WebInvoke()]
        bool UpdateWorkflow(WorkflowDC workflow);

        [OperationContract]
        [WebInvoke()]
        bool InsertWorkflow(WorkflowDC workflow);
    }
}
