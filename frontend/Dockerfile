# Use an official Node.js runtime as the base image
FROM node:18 as build

# Set the working directory within the container
WORKDIR /app
COPY package*.json ./

# Build the image
RUN npm install 
COPY . .
RUN npm run build 

# Use an official Nginx image as the base image for serving
FROM nginx:alpine

# Copy config from to the Nginx server
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Copy the built app from the build stage to the Nginx server
COPY --from=build /app/dist /usr/share/nginx/html

# Start Nginx
CMD ["nginx", "-g", "daemon off;"]