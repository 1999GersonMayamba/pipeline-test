using Amazon.CDK;
using Amazon.CDK.AWS.APIGateway;
using Constructs;

namespace CdkPipelineDemo
{
    public class CdkPipelineDemoStack : Stack
    {
        internal CdkPipelineDemoStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            // The code that defines your stack goes here

            var restAPI = new LambdaRestApi(this, "Teste-Api-Gateway-cdk", new LambdaRestApiProps
            {
                Proxy = true,        
                EndpointTypes = new[] { EndpointType.REGIONAL },
                RestApiName = "Teste-Api-Gateway-cdk",
                Description= "Teste de API Gateway com CDK pepiline",
                DeployOptions = new StageOptions
                {
                    StageName = "dev",
                    Description = "Teste de API Gateway com CDK pepiline",
                    TracingEnabled = false
                }           
            });

            _ = new CfnOutput(this, "apigwtarn", new CfnOutputProps { Value = restAPI.ArnForExecuteApi() });
        }
    }
}
