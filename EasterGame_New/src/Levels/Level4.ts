import { Level, CellType } from './Level';

export class Level4 extends Level {
  constructor() {
    super();
    this.name = 'Level 4';
  }

  setup(): void {
    this.setupWalls();
    this.addObjects();
    this.addTeleportPairs(0, 8, 8, 6, 13, 5, 18, 8);
    this.addDoor(Level.COLS - 1, Level.ROWS - 1);
  }

  private setupWalls(): void {
    this.fillColumn(1,   3, 12, CellType.Wall);
    this.fillRow(1,      3, 19, CellType.Wall);
    this.fillColumn(7,   4,  3, CellType.Wall);
    this.fillColumn(9,   4,  6, CellType.Wall);
    this.fillColumn(12,  4,  2, CellType.Wall);
    this.fillRow(10,     1, 10, CellType.Wall);
    this.fillColumn(15,  4, 11, CellType.Wall);
    this.fillDiagonal(14, 5, false, 10, CellType.Wall);
  }

  private addObjects(): void {
    this.fillRow(1,  0, 19, CellType.EggCell);
    this.fillRow(1,  1,  9, CellType.EggCell);
    this.fillRow(0,  2, 19, CellType.EggCell);
    this.fillColumn(8, 7,  3, CellType.EggCell);
    this.spawnEggsFromGrid('blue');

    this.addEgg(13, 4, 'red');

    this.addCarrot(0,  1);
    this.addCarrot(8,  5);
    this.addCarrot(19, 2);
  }
}
