
using DatabaseRecordCreationModels.Models;
using DBAccessor.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DBAccessor.Context;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace DBAccessor.Services
{
    public class RecordCreationService : IRecordCreationService
    {
        private readonly RecordCreationContext _dbContext;
        private readonly IConfiguration _dbconnectionstring;
       
        public IDbConnection Db { get; }

        public RecordCreationService(RecordCreationContext dbContext, IConfiguration dbconnectionstring)
        {
            _dbContext = dbContext;
            _dbconnectionstring = dbconnectionstring;
        
             Db = GetConnection();
           
        }
        public IDbConnection GetConnection()
         {
            string connstring = _dbconnectionstring.GetConnectionString("SQLiteConnection");
             var conn = new SqliteConnection(connstring);
             if (conn.State == ConnectionState.Closed)
             {
                 conn.Open();
             }
             return conn;
         }
        public string CreateTable()
        {
            string msg = null;
            try
            {
                List<ConfigurationData> objList = new List<ConfigurationData>();
                
                string query = "CREATE TABLE ConfigurationsData (Category STRING  PRIMARY KEY NOT NULL, KeyName  STRING NOT NULL UNIQUE,value STRING,status BOOLEAN)";
               
                Db.Query(query);
                msg = "done";
            }
            catch(Exception e)
            {
                msg = e.Message;
            }
            finally
            {
                Db.Close();
            }
            return msg;

        }
        public List<ConfigurationData> GetAllConfiguration(out string outputmsg)
        {
             outputmsg = null;
            List<ConfigurationData> objList = new List<ConfigurationData>();
            try
            {
                
               
                objList = Db.Query<ConfigurationData>("SELECT * from ConfigurationsData").AsList();
               
                
            }
            catch (Exception e)
            {
                outputmsg = e.Message;
            }
            finally
            {
                Db.Close();
            }
            return objList;
        }

        public ConfigurationData GetSingleRecord(string category, string keyName , out string outputmsg)
        {
            outputmsg = null;
            ConfigurationData objList = new ConfigurationData();
            try
            {
                
                
                string query = "SELECT * from ConfigurationsData C where C.Category = '"  + category + "' AND C.KeyName = '" + keyName + "';";
                objList = Db.Query<ConfigurationData>(query).FirstOrDefault();
                
               
            }
            catch (Exception e)
            {
                outputmsg = e.Message;
            }
            finally
            {
                Db.Close();
            }
            return objList;
        }

      
         public string InsertConfiguration(ConfigurationData obj_Configuration)
           {
               string successMsg = "save successfully";
           
               try
               {
                   _dbContext.Set<ConfigurationData>().Add(obj_Configuration);
                _dbContext.SaveChanges();
                   return successMsg;
               }
               catch(Exception e)
               {
                   return e.Message;           
               }
               

           }

        public string UpdateConfiguration(ConfigurationData requestData, ConfigurationData obj_Configuration)
        {
            string successMsg = "update successfully";
            try
            {

                obj_Configuration.Value = requestData.Value;
                obj_Configuration.Status = requestData.Status;
                _dbContext.Update(obj_Configuration);
                _dbContext.SaveChanges();
                
                return successMsg;
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
    }
}
