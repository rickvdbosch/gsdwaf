# Demo steps for Azure Fucntion on AKS

## Environment Login and preparation 
```powershell

# Get connected to Azure
Login-AzAccount -Tenant 14897128-2b4f-46c2-88d3-8e1cc742a46c
Select-AzSubscription -Subscription Techorama

az login 
az account set --subscription Techorama

# Make sure we have the kubeclt CLI.
az aks install-cli

# Login to the resoruces
Import-AzAksCredential -ResourceGroupName Techorama -Name techorama 
az acr login --name techorama 

# Make sure we use the right configuration in AKS.
kubectl config use-context techorama

# Create cluster role binding for AKS with RBAC
kubectl create clusterrolebinding kubernetes-dashboard --clusterrole=cluster-admin --serviceaccount=kube-system:kubernetes-dashboard

# Install KEDA and Osiris.
func kubernetes install --namespace keda

```

## AKS Dashboard

```powershell

# Start a proxy to the k8s dashboard.
az aks browse --resource-group Techorama --name techorama

```

## Build and Deploy function to Kubernetes / AKS

```powershell

# Build the function using ACS.
$tag = "techorama.azurecr.io/aksdemo:v8"
az acr build -r techorama -t $tag .

# Deploy the function in k8s. Use lowercase name!
func kubernetes deploy --name aksdemo --image-name $tag

```
