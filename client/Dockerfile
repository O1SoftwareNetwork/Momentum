# client/Dockerfile

# Use a Node.js image with pnpm
FROM node:22-alpine

# Install pnpm
RUN npm install -g pnpm

WORKDIR /app

# Install dependencies
COPY package*.json pnpm-lock.yaml ./
RUN pnpm install

# Copy the rest of the application code
COPY . .

# Expose the port
EXPOSE 3000

# Start the development server
CMD ["pnpm",  "dev", "--host"]
