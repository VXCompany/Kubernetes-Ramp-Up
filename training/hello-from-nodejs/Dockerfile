FROM node:14.15.0-alpine3.12

# Create app directory
WORKDIR /usr/src/app

# Install app dependencies
COPY package*.json ./

# If you are building your code for production
# RUN npm ci --only=production
RUN npm install

# Bundle app source
COPY *.js .

EXPOSE 4000

CMD [ "node", "server.js" ]