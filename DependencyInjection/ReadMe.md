Connect docker desktop:

```powershell
kubectl apply -f https://raw.githubusercontent.com/kubernetes/dashboard/v2.0.0-beta4/aio/deploy/recommended.yaml
$TOKEN=((kubectl -n kubernetes-dashboard describe secret default | Select-String "token:") -split " +")[1]
kubectl config set-credentials docker-desktop --token="${TOKEN}"
```

Open proxy:

```powershell
kubectl proxy
```

connect to [the dashboard](http://localhost:8001/api/v1/namespaces/kubernetes-dashboard/services/https:kubernetes-dashboard:/proxy) and log-in using the config in `~/.kube/config`.

http://collabnix.com/kubernetes-dashboard-on-docker-desktop-for-windows-2-0-0-3-in-2-minutes/
https://kubernetes.io/docs/tasks/access-application-cluster/web-ui-dashboard/