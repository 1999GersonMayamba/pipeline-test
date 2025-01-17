﻿using Amazon.CDK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CdkPipelineDemo
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            new CdkPipelineDemoStack(app, "CdkPipelineDemoStack", new StackProps
            {
                Env = new Amazon.CDK.Environment
                {
                    Account = System.Environment.GetEnvironmentVariable("CDK_DEFAULT_ACCOUNT"),
                    Region = System.Environment.GetEnvironmentVariable("CDK_DEFAULT_REGION"),
                },
                Tags = new Dictionary<string, string>
                {
                    { "github", "pipeline" },
                    { "build", "teste" }
                }
            });
            app.Synth();
        }
    }
}
