using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DatabaseRecordCreationModels.Models
{
    [Serializable]
    public class ConfigurationData
    {
        [Key]
        public string Category { get; set; }
        [Key]
        public string KeyName { get; set; }
        public string Value { get; set; }
        public bool Status { get; set; }
        
    }
}
