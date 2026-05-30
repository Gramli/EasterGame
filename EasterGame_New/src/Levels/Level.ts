import { Egg, EggColor } from '../GameObjects/Egg';
import { Carrot } from '../GameObjects/Carrot';
import { GameObject } from '../GameObjects/GameObject';

export enum CellType {
  Empty    = 0,
  Wall     = 1,
  Dead     = 2,
  Teleport = 3,
  Door     = 4,
  EggCell  = 5,
}

export interface TeleportPair {
  a: { x: number; y: number };
  b: { x: number; y: number };
}

export abstract class Level {
  static readonly COLS      = 20;
  static readonly ROWS      = 15;
  static readonly TILE_SIZE = 40;

  name: string = '';

  grid: CellType[][];

  objects: GameObject[] = [];
  teleportPairs: TeleportPair[] = [];
  doors: Array<{ x: number; y: number }> = [];
  totalEggs: number = 0;

  constructor() {
    this.grid = Array.from({ length: Level.COLS }, () =>
      new Array<CellType>(Level.ROWS).fill(CellType.Empty)
    );
  }

  abstract setup(): void;

  protected fillColumn(x: number, startY: number, count: number, cell: CellType): void {
    for (let y = startY; y < Level.ROWS && count > 0; y++, count--) {
      if (this.grid[x][y] !== CellType.Wall && this.grid[x][y] !== CellType.Teleport) {
        this.grid[x][y] = cell;
      }
    }
  }

  protected fillRow(startX: number, y: number, count: number, cell: CellType): void {
    for (let x = startX; x < Level.COLS && count > 0; x++, count--) {
      if (this.grid[x][y] !== CellType.Wall && this.grid[x][y] !== CellType.Teleport) {
        this.grid[x][y] = cell;
      }
    }
  }

  protected fillDiagonal(
    startX: number,
    startY: number,
    rightDown: boolean,
    count: number,
    cell: CellType,
  ): void {
    let x = startX;
    for (let y = startY; y < Level.ROWS && count > 0; y++, count--) {
      if (x >= 0 && x < Level.COLS
          && this.grid[x][y] !== CellType.Wall
          && this.grid[x][y] !== CellType.Teleport) {
        this.grid[x][y] = cell;
      }
      x += rightDown ? 1 : -1;
    }
  }

  protected addTeleportPairs(...coords: number[]): void {
    for (let i = 0; i + 3 < coords.length; i += 4) {
      const ax = coords[i], ay = coords[i + 1];
      const bx = coords[i + 2], by = coords[i + 3];
      this.grid[ax][ay] = CellType.Teleport;
      this.grid[bx][by] = CellType.Teleport;
      this.teleportPairs.push({ a: { x: ax, y: ay }, b: { x: bx, y: by } });
    }
  }

  protected addDoor(x: number, y: number): void {
    this.grid[x][y] = CellType.Door;
    this.doors.push({ x, y });
  }

  protected addEgg(x: number, y: number, color: EggColor): void {
    this.objects.push(new Egg(x, y, color));
    this.totalEggs++;
  }

  protected addCarrot(x: number, y: number): void {
    this.objects.push(new Carrot(x, y));
  }

  protected spawnEggsFromGrid(color: EggColor): void {
    for (let x = 0; x < Level.COLS; x++) {
      for (let y = 0; y < Level.ROWS; y++) {
        if (this.grid[x][y] === CellType.EggCell) {
          this.objects.push(new Egg(x, y, color));
          this.totalEggs++;
          this.grid[x][y] = CellType.Empty;
        }
      }
    }
  }

  protected clearCell(x: number, y: number): void {
    if (this.grid[x][y] === CellType.EggCell) {
      this.grid[x][y] = CellType.Empty;
    }
  }

  getTeleportDestination(x: number, y: number): { x: number; y: number } | null {
    for (const pair of this.teleportPairs) {
      if (pair.a.x === x && pair.a.y === y) return { ...pair.b };
      if (pair.b.x === x && pair.b.y === y) return { ...pair.a };
    }
    return null;
  }

  isDoor(x: number, y: number): boolean {
    return this.doors.some(d => d.x === x && d.y === y);
  }
}
