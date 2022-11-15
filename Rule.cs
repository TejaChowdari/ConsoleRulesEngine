using global::RulesEngine.Models;
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp3
{
       /// <summary>
        /// Rule class
        /// </summary>
        [ExcludeFromCodeCoverage]
        public class Rule
        {
            public string RuleName { get; set; }
            public Dictionary<string, object> Properties { get; set; }
            public string Operator { get; set; }
            public string ErrorMessage { get; set; }
            public string SuccessMessage { get; set; }
            public bool Enabled { get; set; } = true;

            [JsonConverter(typeof(StringEnumConverter))]
            public RuleExpressionType RuleExpressionType { get; set; } = RuleExpressionType.LambdaExpression;
            public IEnumerable<string> WorkflowsToInject { get; set; }
            public IEnumerable<Rule> Rules { get; set; }
            public IEnumerable<ScopedParam> LocalParams { get; set; }
            public string Expression { get; set; }
            public RuleActions Actions { get; set; }
            public string SuccessEvent { get; set; }

        }
    }


