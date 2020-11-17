# Demo app voor Node.js

### Requirements
Als je de app ook lokaal wil draaien (buiten een container) heb je Node.js en NPM nodig. Voor het gebruik tijdens de Ramp-Up training is dat niet nodig. 

### Build het image
docker build . -t hello-app-from-nodejs:1.0

### Run het image lokaal
docker run -p 4000:4000 hello-app-from-nodejs:1.0

### Uitvoeren van de smoketest lokaal
http://localhost:4000

### Deploy het image op Kubernetes
kubectl apply -f hello-deployment.yaml
kubectl apply -f hello-service.yaml

### Uitvoeren van de smoketest Kubernetes
http://localhost:30080