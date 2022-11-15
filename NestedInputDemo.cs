using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RulesEngine.Extensions;
using RulesEngine.Models;

namespace ConsoleApp3
{
    internal class ListItem
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public List<string> Subjects { get; set; }

        public  void GetAllStudetns()
        {
            var input1 = new Student { Id = 100, Name = "Tom", Gender = "Male"};
            var input2 = new Student { Id = 200, Name = "Mike",Gender = "Male"};
            var input3 = new Student { Id = 300, Name = "Pam", Gender = "Female"};
            var inputs = new dynamic[]{ input1, input2,input3};
            var files = Directory.GetFiles(@"D:\Practice\RulesConsole", "NeastedInputDemo.json", SearchOption.AllDirectories);
            //var files = Directory.GetFiles(Directory.GetCurrentDirectory(), "NeastedInputDemo.json", SearchOption.AllDirectories);
            //var files = Directory.GetFiles(Directory.GetCurrentDirectory(), "NeastedInputDemo.json", SearchOption.AllDirectories);
            if (files == null || files.Length == 0)
            {
                throw new Exception("Rules not found.");
            }
            var fileData = File.ReadAllText(files[0]);
            var Workflows = JsonConvert.DeserializeObject<List<Workflow>>(fileData);
            var bre = new RulesEngine.RulesEngine(Workflows.ToArray(), null);
            Console.WriteLine(bre);
            foreach (var workflow in Workflows)
            {
                var resultList = bre.ExecuteAllRulesAsync(workflow.WorkflowName, inputs).Result;
                resultList.OnSuccess((eventname) =>
                {
                    Console.WriteLine($"{workflow.WorkflowName} evaluation resulted in success - {eventname}");
                }).OnFail(() =>
                {
                    Console.WriteLine($"{workflow.WorkflowName} evaluation resulted in failure");
                });
            }
        }
    }
}