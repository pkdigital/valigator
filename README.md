# Valigator email validation service

This project provides email address validation, disposable address detection and typo suggestions.

It was developed for [Eventsense](https://www.evensense.co.uk) and is designed to execute via an AWS Lambda exposed through Amazon API Gateway. 

### Configuring for Application Load Balancer ###

To configure this project to handle requests from an Application Load Balancer instead of API Gateway change
the base class of `LambdaEntryPoint` from `Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction` to 
`Amazon.Lambda.AspNetCoreServer.ApplicationLoadBalancerFunction`.

### Project Files ###

The validation service reads and caches some data files to help with validating domain suffixes, suggested domains and disposable email address detection.

These files were built in part or in full from the following sources:

##### Disposable emails #####

https://github.com/martenson/disposable-email-domains

##### Popular email domains #####
https://github.com/mailcheck/mailcheck/wiki/List-of-Popular-Domains

##### Top level domains #####
http://data.iana.org/TLD/tlds-alpha-by-domain.txt



## Deployment

To deploy from Visual Studio right click the project in Solution Explorer and select *Publish to AWS Lambda*.

## CLI Deployment

Install Amazon.Lambda.Tools Global Tools if not already installed.
```
    dotnet tool install -g Amazon.Lambda.Tools
```

If already installed check if new version is available.
```
    dotnet tool update -g Amazon.Lambda.Tools
```

Deploy via CLI
```
    cd "Valigator.Api/src/Valigator.Api"
    dotnet lambda deploy-serverless
```
