# EasterGame

[![TypeScript](https://img.shields.io/badge/TypeScript-5.4-3178C6?logo=typescript&logoColor=white)](https://www.typescriptlang.org/)
[![Vite](https://img.shields.io/badge/Vite-6-646CFF?logo=vite&logoColor=white)](https://vite.dev/)
[![Docker](https://img.shields.io/badge/Docker-ready-2496ED?logo=docker&logoColor=white)](https://www.docker.com/)
[![License](https://img.shields.io/badge/license-MIT-green.svg)](LICENSE.md)

EasterGame is a tile-based puzzle game about collecting Easter eggs and finding
the exit. Guide the rabbit across each map carefully: every ordinary tile becomes
blocked after you leave it, so a careless turn can close the only path forward.

The game was originally built in 2014 as a C# WinForms application. This
repository also contains a modern browser edition rebuilt with TypeScript,
HTML canvas, and Vite.

## Features

- Eight puzzle levels: seven ported original levels and one additional browser level
- Route-planning gameplay with tiles that disappear behind the player
- Collectible carrots that grant a two-tile jump
- Teleports, walls, eggs, and an exit door
- Move counter, timer, remaining-egg counter, and jump counter
- Responsive canvas scaling for desktop, mobile, and embedded layouts
- Touch controls for phones and tablets
- Optional background music
- Production-ready Docker image served by nginx

## How to Play

Collect every egg, then reach the door to complete the level. You cannot step on
walls or tiles you have already left behind. Pick up carrots to gain jumps and
use teleports when a level provides them.

### Keyboard Controls

| Key | Action |
| --- | --- |
| Arrow keys | Move one tile |
| `Space` | Jump two tiles in the current direction after collecting a carrot |
| `Enter` | Start the game or continue to the next level |
| `R` | Restart the current level |
| `S` | Toggle music |

### Touch Controls

On touch devices, use the on-screen directional pad. The center button jumps,
`R` restarts the level, and `S` toggles music. Tap the game board to start the
game or continue after completing a level.

## Getting Started

### Browser Edition

Requirements:

- [Node.js](https://nodejs.org/) 22 or newer
- npm

Clone the repository and run the development server:

```bash
git clone https://github.com/Gramli/EasterGame.git
cd EasterGame/EasterGame_New
npm ci
npm run dev
```

If you already have the repository, start from its root directory:

```bash
cd EasterGame_New
npm ci
npm run dev
```

Open the URL printed by Vite, usually `http://localhost:5173`.

## Project Structure

```text
.
|-- EasterGame_New/   # TypeScript browser edition
|   |-- public/       # Sprites, music, and SVG assets
|   `-- src/          # Game logic, controls, levels, and renderer
|-- EasterGame/       # Original C# WinForms source code
|-- Assets/           # Archived 2014 Windows build
|-- Dockerfile        # Multi-stage production image
`-- nginx.conf        # Static-site nginx configuration
```

## Original Windows Edition

The original game targets .NET Framework 4.5 and is kept in
[`EasterGame/`](EasterGame/). A packaged 2014 build is available in
[`Assets/EasterGame_2014.zip`](Assets/EasterGame_2014.zip). Extract the archive
on Windows and run `EasterGame.exe`.

## License

This project is licensed under the [MIT License](LICENSE.md).
