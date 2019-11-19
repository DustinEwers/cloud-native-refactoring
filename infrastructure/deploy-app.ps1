

$kubernetesResourceGroup="wisco-ipsum"
$aksClusterName="wisco-ipsum-cluster"
$connectionString = "Server=tcp:ipsum-db-server-1.database.windows.net,1433;Initial Catalog=WiscoIpsum-db;Persist Security Info=False;User ID=ipsumAdmin;Password=change-me-123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

az aks get-credentials -g "$kubernetesResourceGroup" -n "$aksClusterName" -a

# Create Kubernetes Secret
$secret = kubectl get secrets db-secret --ignore-not-found=true

if($secret){
    kubectl delete secret db-secret
}

kubectl create secret generic db-secret `
    --from-literal=SQLAZURECONNSTR_Database="$connectionString"

# Apply YAML Files to create the rest of the application
kubectl apply -f .\app-configmap.yaml
kubectl apply -f .\app-deployment.yaml
