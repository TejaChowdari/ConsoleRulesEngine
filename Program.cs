using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RulesEngine;
using RulesEngine.Models;
using System.Dynamic;
using RulesEngine.Extensions;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.IO;

namespace ConsoleApp3
{
  public class Program
    {
        public static void Main(string[] args)
        {

            new Student().GetAllStudetns();
            //new NestedInputDemo().Run();
            Console.ReadLine();

        }

    }   
}

