// 
//    Valigator
// 
//    LambdaEntryPoint.cs
// 
// 

using Amazon.Lambda.AspNetCoreServer;
using Microsoft.AspNetCore.Hosting;

namespace Valigator
{
    /// <summary>
    ///     This class extends from APIGatewayProxyFunction which contains the method FunctionHandlerAsync which is the
    ///     actual Lambda function entry point. The Lambda handler field should be set to
    ///     Valigator.Api::Valigator.Api.LambdaEntryPoint::FunctionHandlerAsync
    /// </summary>
    public class LambdaEntryPoint :
        // When using an ELB's Application Load Balancer as the event source change 
        // the base class to Amazon.Lambda.AspNetCoreServer.ApplicationLoadBalancerFunction
        APIGatewayProxyFunction
    {
        /// <summary>
        ///     The builder has configuration, logging and Amazon API Gateway already configured. The startup class
        ///     needs to be configured in this method using the UseStartup<>() method.
        /// </summary>
        /// <param name="builder"></param>
        protected override void Init(IWebHostBuilder builder)
        {
            builder
                .UseStartup<Startup>();
        }
    }
}