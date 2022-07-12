using DatabaseRecordCreationModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBAccessor.ServiceInterfaces
{
    public interface IRecordCreationService
    {
        public string InsertConfiguration(ConfigurationData obj_Configuration);
        public string UpdateConfiguration(ConfigurationData obj_Configuration, ConfigurationData obj_Configuration2);
        public ConfigurationData GetSingleRecord(string category, string keyName , out string outMsg);
        public List<ConfigurationData> GetAllConfiguration(out string outMsg);
        public string CreateTable();
    }
}
