import { Game } from './Game';
import { CellType, Level } from './Levels/Level';
import { GameImages } from './Assets';

const T = Level.TILE_SIZE;

export class Renderer {
  private ctx:    CanvasRenderingContext2D;
  private images: GameImages;

  constructor(ctx: CanvasRenderingContext2D, images: GameImages) {
    this.ctx    = ctx;
    this.images = images;
  }

  render(game: Game): void {
    const { ctx } = this;
    ctx.clearRect(0, 0, ctx.canvas.width, ctx.canvas.height);

    switch (game.phase) {
      case 'menu':
        this.drawMenu();
        break;
      case 'playing':
        this.drawLevel(game);
        break;
      case 'won':
      case 'lost':
        this.drawLevel(game);
        this.drawOverlay(game);
        break;
    }
  }

  private drawLevel(game: Game): void {
    this.drawGrid(game);
    this.drawObjects(game);
    game.player.draw(this.ctx, T, this.images);
  }

  private drawGrid(game: Game): void {
    const { grid } = game.level;
    const { ctx, images } = this;

    for (let x = 0; x < Level.COLS; x++) {
      for (let y = 0; y < Level.ROWS; y++) {
        const px = x * T;
        const py = y * T;

        switch (grid[x][y]) {
          case CellType.Empty:
          case CellType.EggCell:
            ctx.drawImage(images.trava, px, py, T, T);
            break;
          case CellType.Wall:
            ctx.drawImage(images.trava,  px, py, T, T);
            ctx.drawImage(images.kamen,  px, py, T, T);
            break;
          case CellType.Dead:
            ctx.drawImage(images.mrtvePole, px, py, T, T);
            break;
          case CellType.Teleport:
            ctx.drawImage(images.teleport, px, py, T, T);
            break;
          case CellType.Door:
            ctx.drawImage(images.dvere, px, py, T, T);
            break;
        }
      }
    }
  }

  private drawObjects(game: Game): void {
    for (const obj of game.level.objects) {
      obj.draw(this.ctx, T, this.images);
    }
  }

  private drawMenu(): void {
    const { ctx, images } = this;
    const w = ctx.canvas.width;
    const h = ctx.canvas.height;

    const pattern = ctx.createPattern(images.trava, 'repeat');
    if (pattern) {
      ctx.fillStyle = pattern;
      ctx.fillRect(0, 0, w, h);
    }

    ctx.fillStyle = 'rgba(0,0,0,0.52)';
    ctx.fillRect(0, 0, w, h);

    const spriteY = h / 2 - 170;
    const spriteSize = T * 1.5;
    const sprites = [
      images.vajickoModre, images.vajickoCervene, images.vajickoOranzove,
      images.mrkev, images.zajicDoprava,
    ];
    const totalW = sprites.length * spriteSize + (sprites.length - 1) * 8;
    sprites.forEach((img, i) => {
      ctx.drawImage(img, w / 2 - totalW / 2 + i * (spriteSize + 8), spriteY, spriteSize, spriteSize);
    });

    // Title
    ctx.fillStyle    = '#f1c40f';
    ctx.font         = 'bold 38px system-ui, sans-serif';
    ctx.textAlign    = 'center';
    ctx.textBaseline = 'middle';
    ctx.fillText('Easter Game', w / 2, h / 2 - 90);

    ctx.fillStyle = '#d4f7b0';
    ctx.font      = '17px system-ui, sans-serif';
    ctx.fillText('Plan your path · collect all eggs · reach the door', w / 2, h / 2 - 52);

    ctx.fillStyle = 'rgba(0,0,0,0.4)';
    ctx.fillRect(w / 2 - 220, h / 2 - 20, 440, 108);

    const controls: [string, string][] = [
      ['← → ↑ ↓', 'Move the rabbit'],
      ['Space',    'Jump 2 tiles (requires a carrot)'],
      ['R',        'Restart the current level'],
      ['S',        'Toggle music'],
    ];
    controls.forEach(([key, desc], i) => {
      ctx.font      = '14px monospace';
      ctx.fillStyle = '#f1c40f';
      ctx.textAlign = 'right';
      ctx.fillText(key, w / 2 - 12, h / 2 + 6 + i * 24);
      ctx.font      = '14px system-ui, sans-serif';
      ctx.fillStyle = '#fff';
      ctx.textAlign = 'left';
      ctx.fillText(desc, w / 2 + 12, h / 2 + 6 + i * 24);
    });

    ctx.fillText('Press Enter or Space to start', w / 2, h / 2 + 140);
  }

  private drawOverlay(game: Game): void {
    const { ctx } = this;
    const w   = ctx.canvas.width;
    const h   = ctx.canvas.height;
    const won = game.phase === 'won';

    ctx.fillStyle = 'rgba(0,0,0,0.68)';
    ctx.fillRect(0, 0, w, h);

    const icon = won ? this.images.vajickoModre : this.images.zajicDoprava;
    const iconSize = T * 2;
    ctx.drawImage(icon, w / 2 - iconSize / 2, h / 2 - 110, iconSize, iconSize);

    ctx.textAlign    = 'center';
    ctx.textBaseline = 'middle';
    ctx.fillStyle    = won ? '#f1c40f' : '#e74c3c';
    ctx.font         = 'bold 34px system-ui, sans-serif';
    ctx.fillText(
      won
        ? (game.hasNextLevel ? 'Level Complete!' : '🎊  You Win!  🎊')
        : 'No moves left!',
      w / 2,
      h / 2 - 10,
    );

    const time = this.formatTime(game.elapsedSeconds);
    ctx.fillStyle = '#fff';
    ctx.font      = '18px system-ui, sans-serif';
    ctx.fillText(`Moves: ${game.player.moves}   |   Time: ${time}`, w / 2, h / 2 + 32);

    ctx.fillStyle = '#d4f7b0';
    ctx.font      = '15px system-ui, sans-serif';
    const hint = won && game.hasNextLevel
      ? 'Enter — next level   |   R — replay'
      : 'R — restart';
    ctx.fillText(hint, w / 2, h / 2 + 68);
  }

  private formatTime(totalSeconds: number): string {
    const m = Math.floor(totalSeconds / 60).toString().padStart(2, '0');
    const s = (totalSeconds % 60).toString().padStart(2, '0');
    return `${m}:${s}`;
  }
}
