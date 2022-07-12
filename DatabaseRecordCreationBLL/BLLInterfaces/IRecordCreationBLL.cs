using DatabaseRecordCreationModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseRecordCreationBLL.BLLInterfaces
{
    public interface IRecordCreationBLL
    {
        public string InsertOrUpdateRecord(ConfigurationData obj_Configuration);
     
       
        public List<ConfigurationData>  GetAllConfiguration(out string outMsg);
    }
}
