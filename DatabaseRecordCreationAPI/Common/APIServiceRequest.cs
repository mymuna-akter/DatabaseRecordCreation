using Newtonsoft.Json;
using System;
namespace DatabaseRecordCreationAPI.Common
{
    public class APIServiceRequest
    {
        private string msgRequestId;
        public string RequestId
        {
            get { return msgRequestId; }
            set { msgRequestId = value; }
        }
        private dynamic msgBusinessData;
        public dynamic BusinessData
        {
            get { return msgBusinessData; }
            set { msgBusinessData = value; }
        }
    }
}
