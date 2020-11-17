# Demo app voor .NET

### Requirements
Als je de app ook lokaal wil draaien (buiten een container) heb je een SDK nodig. Voor het gebruik tijdens de Ramp-Up training is dat niet nodig. 

### Build het image
docker build . -t hello-app:1.0

### Run het image lokaal
docker run -p 5000:5000 hello-app:1.0

### Uitvoeren van de smoketest lokaal
http://localhost:5000

### Deploy het image op Kubernetes
kubectl apply -f hello-deployment.yaml
kubectl apply -f hello-service.yaml

### Uitvoeren van de smoketest Kubernetes
http://localhost:30080