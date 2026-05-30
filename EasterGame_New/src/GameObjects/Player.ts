import { GameObject } from './GameObject';
import { GameImages } from '../Assets';

export enum Direction {
  Right = 'right',
  Left  = 'left',
  Up    = 'up',
  Down  = 'down',
}

export class Player extends GameObject {
  direction:     Direction = Direction.Right;
  jumpsLeft:     number    = 0;
  collectedEggs: number    = 0;
  moves:         number    = 0;

  constructor(x: number, y: number) {
    super(x, y);
  }

  setDirection(direction: Direction): void {
    this.direction = direction;
  }

  draw(ctx: CanvasRenderingContext2D, tileSize: number, images: GameImages): void {
    const sprite: HTMLImageElement = {
      [Direction.Right]: images.zajicDoprava,
      [Direction.Left]:  images.zajicDoleva,
      [Direction.Up]:    images.zajicNahoru,
      [Direction.Down]:  images.zajicDolu,
    }[this.direction];

    ctx.drawImage(sprite, this.x * tileSize, this.y * tileSize, tileSize, tileSize);
  }
}
