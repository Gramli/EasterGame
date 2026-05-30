# ── build stage ──────────────────────────────────────────────────────────────
FROM node:22-alpine AS build

WORKDIR /app

COPY EasterGame_New/package*.json ./
RUN npm ci

# Copy source and all public assets (PNG, SVG, WAV)
COPY EasterGame_New/ ./
RUN npm run build

# ── serve stage ───────────────────────────────────────────────────────────────
FROM nginx:1.27-alpine

COPY nginx.conf /etc/nginx/conf.d/default.conf
# dist/ includes everything from public/ (assets, svgs) plus compiled JS/CSS
COPY --from=build /app/dist /usr/share/nginx/html

EXPOSE 8080

CMD ["nginx", "-g", "daemon off;"]
