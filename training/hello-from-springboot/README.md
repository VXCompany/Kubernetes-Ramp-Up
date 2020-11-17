# Demo app voor Spring Boot

### Requirements
Als je de app ook lokaal wil draaien (buiten een container) heb je een JDK nodig. Voor het gebruik tijdens de Ramp-Up training is dat niet nodig. 

### Build het image
docker build . -t hello-app-from-springboot:1.0

### Run het image lokaal
docker run -p 8080:8080 hello-app-from-springboot:1.0

### Uitvoeren van de smoketest lokaal
http://localhost:8080

### Deploy het image op Kubernetes
kubectl apply -f hello-deployment.yaml
kubectl apply -f hello-service.yaml

### Uitvoeren van de smoketest Kubernetes
http://localhost:30080