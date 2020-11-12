FROM openjdk:11.0.9.1-jdk AS build-env

WORKDIR /app

# Copy everything and build
COPY . ./
RUN ./mvnw package

# Build runtime image
FROM openjdk:11.0.9-jre
WORKDIR /app
COPY --from=build-env /app/target/hello-from-springboot-0.0.1-SNAPSHOT.jar .
ENTRYPOINT ["java","-jar","/hello-from-springboot-0.0.1-SNAPSHOT.jar"]