import { GameObject } from './GameObject';
import { GameImages } from '../Assets';

export type EggColor = 'blue' | 'red' | 'orange';

export class Egg extends GameObject {
  readonly color: EggColor;

  constructor(x: number, y: number, color: EggColor) {
    super(x, y);
    this.color = color;
  }

  draw(ctx: CanvasRenderingContext2D, tileSize: number, images: GameImages): void {
    const sprite = this.color === 'blue'   ? images.vajickoModre
                 : this.color === 'red'    ? images.vajickoCervene
                 : images.vajickoOranzove;

    ctx.drawImage(sprite, this.x * tileSize, this.y * tileSize, tileSize, tileSize);
  }
}
