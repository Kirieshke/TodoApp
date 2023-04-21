using GemBox.Spreadsheet;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using MailKit.Net.Smtp;
using MimeKit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TodoApp.Core.Entity
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime TimeOfCreation { get; set; } = DateTime.Now;
        public DateTime Deadline { get; set; }
        public DateTime TimeOfDone { get; set; }
        public bool IsDone { get; set; } 
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public override string ToString()
        {
            return Id.ToString() + ", " + Name + ", " + TimeOfCreation + ", " + TimeOfDone;
        }
        public void serializeJson(Task wwe,string taskJsonFile)
        {
            
            string json = JsonConvert.SerializeObject(wwe.ToString());
            string jsonFormated = JValue.Parse(json).ToString(Formatting.Indented);
            File.AppendAllText(taskJsonFile, jsonFormated);
        }
        public  void deserializeJson(Task t, string filename)
        {

            string clientDetails = t.Name + "," + t.Deadline + "," + t.TimeOfDone + Environment.NewLine ;


            if (!File.Exists(filename))
            {
                string clientHeader = "Client Name(ie. Billto_desc)" + "," + "Mid_id,billing number(ie billto_id)" + "," + "business unit id" + Environment.NewLine;

                File.WriteAllText(filename, clientHeader);
                
            }

            File.AppendAllText(filename, clientDetails);

        }
        public string ChangeColor()
        {
             if(DateTime.Now > Deadline)
             {
                return "#D03B2E";
             }
             return "#D0D0D0";
        }
        
    }
}


