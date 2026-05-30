import { GameObject } from './GameObject';
import { GameImages } from '../Assets';

export class Carrot extends GameObject {
  constructor(x: number, y: number) {
    super(x, y);
  }

  draw(ctx: CanvasRenderingContext2D, tileSize: number, images: GameImages): void {
    ctx.drawImage(images.mrkev, this.x * tileSize, this.y * tileSize, tileSize, tileSize);
  }
}
