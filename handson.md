# Hands-On en demo script

## Build de app
Om 1 van de demo apps te builden, kies je de juiste directory uit de training folder:
- training/hello-from-dotnet
- training/hello-from-nodejs
- training/hello-from-springboot

In de root van de demo app folder vind je de Dockerfile. Deze build en tag je met:
```
docker build . -t hello-app:1.0
```
In het geval van de Node.js app is de build eenvoudig, maar voor de .NET en Spring Boot app gebeurt er in de Docker build iets extra's: de software build vindt ook plaats in een Docker stap. Dit betekent, dat je dus lokaal geen SDK/JDK nodig hebt om de software te bouwen!

Bekijk de app in je lokale Docker repo met:
```
docker images
```

## Deployment van de app op Kubernetes
Deze stap vereist een verbinding met een Kubernetes omgeving. Je kunt hier voor bijvoorbeeld Docker Desktop gebruiken of een Kubernetes omgeving in de cloud (zie de [handleiding](voorbereiding.md) voor de installatie instructies). 

In de root van je demo app folder vind je een deployment file, "hello-deployment.yaml". Deze file is opgemaakt in [YAML](https://en.wikipedia.org/wiki/YAML) en bevat de complete instructie voor je deployment van de app.

Deploy de app met:
```
kubectl apply –f hello-deployment.yaml
```

Dit gebruikt de Kubernetes CLI (kubectl) en vertelt deze om een bepaalde "state" toe te passen, en wel uit een file (je kunt dus ook zonder file vanaf STDIN een configuratie toepassen). 

Vervolgens bekijk je of er een pod gedeployed is met:
```
kubectl get pods
```

## Informatie over de deployment
Nu je een deployment hebt gedaan, kun je een de aantal zaken gaan bekijken. Bijvoorbeeld de logfile van de pod:
```
kubectl logs hello-deployment-<uniek id>
```

Of de beschrijving van de pod zelf, maar dan weer in YAML format:
```
kubectl get pod hello-deployment-<uniek id> -o yaml
```

## Een service toevoegen
Om verkeer eenvoudig naar een pod/ container te sturen kun je gebruik maken van Kubernetes Services. Deze komen voor de pods te staan en zorgen voor zaken als loadbalancing, fouttolerantie, DNS resolving, discovery, etc. 

Voor de demo app is er een service beschreven in de "hello-service.yaml" en die pas je ook toe met:
```
kubectl apply -f hello-service.yaml
```

Deze service zorgt er voor, dat je app die draait in een container op een pod via je host (laptop) te bereiken is. 

> In het geval van een Kubernetes in de cloud, zul je de service aan moeten passen: "type: NodePort" moet dan worden "type: LoadBalancer"
> Je krijgt dan via het publieke ip van je cloud load balancer (Azure Load Balancer of Amazon Elastic Load Balancer) via poort 80 verbinding met je app.

Wanneer je nu vanaf de host gaat naar: http://localhost:30080 zou je de melding van de app moeten zien!

## Scale de deployment
Vanuit de "hello-deployment.yaml" is er 1 replica van je demo app opgestart. Wanneer je nu meerdere instanties wil hebben (bijvoorbeeld voor loadbalancing), kun je dat op de volgende manier doen:

```
kubectl edit deployment hello-deployment
```

Dit opent je text editor (op Linux is dat "vi" maar dat kun je aanpassen via de KUBE_EDITOR environment variabele) en door de "replicas" op 2 te zetten start de Kubernetes scheduler een nieuwe pod voor je op!

Dit controleer je met:

```
kubectl get pods
```

Je kunt de schaal van de applicatie ook direct via de CLI aanpassen:

```
kubectl scale deployment hello-deploment --replicas=3
```

## Opruimen van je resources
Verwijder de service en deployment:
```
kubectl delete service hello-service
kubectl delete deployment hello-deployment
```







