using DatabaseRecordCreationBLL.BLLInterfaces;
using DatabaseRecordCreationModels.Models;
using DBAccessor.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseRecordCreationBLL.BLL
{
    public class RecordCreationBLL : IRecordCreationBLL

    {
        public readonly IRecordCreationService _recordCreationService;
        public RecordCreationBLL(IRecordCreationService recordCreationService)
        {
            _recordCreationService = recordCreationService;
        }

        public List<ConfigurationData> GetAllConfiguration(out string outputMsg)
        {
            return _recordCreationService.GetAllConfiguration(out outputMsg);
        }

        public string InsertOrUpdateRecord(ConfigurationData obj_Configuration)
        {
            string msg = null;
            var obj = _recordCreationService.CreateTable();//if table doesn't exit, then create;
            if (obj == "done")//table created
            { //insert
                return _recordCreationService.InsertConfiguration(obj_Configuration);
            }
            else //if table exist
            { // checking the data already exist or not in databasetable
                ConfigurationData objData = _recordCreationService.GetSingleRecord(obj_Configuration.Category, obj_Configuration.KeyName ,out msg);
                if (msg == null)
                {
                    if (objData == null)
                    { //data doesn't exist
                        return _recordCreationService.InsertConfiguration(obj_Configuration);
                    }
                    else
                    { // data already exist

                        return _recordCreationService.UpdateConfiguration(obj_Configuration, objData);
                    }
                }
                else
                {
                    return msg;
                }
            }
        }

      
    }
}
