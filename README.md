# GSDwAF

## Gettings sh*t done with Azure Functions (on AKS)!

All documentation and source code of the Techorama talk about Azure Functions, Kubernetes, AKS and more.

## Azure Functions

>Azure Functions is a serverless compute service that enables you to run code on-demand without having to 
explicitly provision or manage infrastructure. Use Azure Functions to run a script or piece of code in 
response to a variety of events.

Source: [Azure Functions Documentation](https://docs.microsoft.com/en-us/azure/azure-functions/)

## Triggers & Bindings

>Triggers and bindings let you avoid hardcoding access to other services. Your function receives data (for example, the content of a queue message) in function parameters. You send data (for example, to create a queue message) by using the return value of the function.

Source: [Azure Functions triggers and bindings concepts](https://docs.microsoft.com/en-us/azure/azure-functions/functions-triggers-bindings)

## Azure Kubernetes Service

>Azure Kubernetes Service (AKS) manages your hosted Kubernetes environment, making it quick and easy to 
deploy and manage containerized applications without container orchestration expertise. It also eliminates 
the burden of ongoing operations and maintenance by provisioning, upgrading, and scaling resources on 
demand, without taking your applications offline.

Source: [Azure Kubernetes Service (AKS)](https://docs.microsoft.com/en-us/azure/aks/)

## Managed Identities for Azure Resources

>A common challenge when building cloud applications is how to manage the credentials in your code for authenticating to cloud services. Keeping the credentials secure is an important task. Ideally, the credentials never appear on developer workstations and aren't checked into source control. Azure Key Vault provides a way to securely store credentials, secrets, and other keys, but your code has to authenticate to Key Vault to retrieve them.

>The managed identities for Azure resources feature in Azure Active Directory (Azure AD) solves this problem. The feature provides Azure services with an automatically managed identity in Azure AD. You can use the identity to authenticate to any service that supports Azure AD authentication, including Key Vault, without any credentials in your code.

Source: [What is managed identities for Azure resources?](https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/overview)
