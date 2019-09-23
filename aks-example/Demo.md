# Demo steps for Azure Fucntion on AKS

## Environment Login

```powershell

# Get connected to Azure
Login-AzAccount -Tenant 14897128-2b4f-46c2-88d3-8e1cc742a46c
Select-AzSubscription -Subscription Techorama

az login 
az account set --subscription Techorama

# Login to the resoruces.
Import-AzAksCredential -ResourceGroupName Techorama -Name techorama 
az acr login --name techorama 

# Make sure we use the right configuration in AKS.
kubectl config use-context techorama

```

## AKS Dashboard

```powershell

# Create cluster role binding for AKS with RBAC
kubectl create clusterrolebinding kubernetes-dashboard --clusterrole=cluster-admin --serviceaccount=kube-system:kubernetes-dashboard

# And use it.
az aks browse --resource-group Techorama --name techorama

```

## Install Keda in kubernetes / AKS

```powershell

func kubernetes install --namespace keda

```

## Build and Deploy function to Kubernetes / AKS

```powershell

$version = 2; $tag = "techorama.azurecr.io/aksdemo:v${version}"

az acr build -r techorama -t $tag .

# Use lowercase name
func kubernetes deploy --name aksdemo --image-name $tag

```
