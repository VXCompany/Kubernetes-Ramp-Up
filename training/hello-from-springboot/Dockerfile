FROM maven:3.6.3-jdk-11 as build-env

WORKDIR /app

# Copy everything and build
COPY . ./

RUN mvn package

# Build runtime image
FROM openjdk:11.0.9-jre
WORKDIR /app
COPY --from=build-env /app/target/hello-from-springboot-0.0.1-SNAPSHOT.jar .

EXPOSE 8080

ENTRYPOINT ["java","-jar","/hello-from-springboot-0.0.1-SNAPSHOT.jar"]
