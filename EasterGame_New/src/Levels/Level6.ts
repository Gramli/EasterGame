import { Level, CellType } from './Level';

export class Level6 extends Level {
  constructor() {
    super();
    this.name = 'Level 6';
  }

  setup(): void {
    this.setupWalls();
    this.addObjects();
    this.addTeleportPairs(15, 3, 10, 11, 0, 10, 17, 14);
    this.addDoor(Level.COLS - 1, Level.ROWS - 1);
  }

  private setupWalls(): void {
    this.fillColumn(1,   0, 13, CellType.Wall);
    this.fillRow(2,      4,  6, CellType.Wall);
    this.fillColumn(2,   5, 10, CellType.Wall);
    this.fillColumn(8,   0, 15, CellType.Wall);
    this.fillColumn(9,   3,  4, CellType.Wall);
    this.fillColumn(10,  6,  2, CellType.Wall);
    this.fillDiagonal(11, 8, true,   6, CellType.Wall);
    this.fillDiagonal(12, 8, true,   4, CellType.Wall);
    this.fillColumn(16, 10,  5, CellType.Wall);
    this.fillRow(17,    10,  3, CellType.Wall);
  }

  private addObjects(): void {
    this.fillColumn(9,   7, 8, CellType.EggCell);
    this.fillColumn(10,  8, 7, CellType.EggCell);
    this.fillColumn(11,  9, 6, CellType.EggCell);
    this.fillColumn(12, 10, 5, CellType.EggCell);
    this.fillColumn(13, 11, 4, CellType.EggCell);
    this.fillColumn(14, 12, 3, CellType.EggCell);
    this.fillColumn(15, 13, 2, CellType.EggCell);
    this.clearCell(9,  14);
    this.clearCell(10, 11);
    this.spawnEggsFromGrid('red');

    this.addEgg(1,  13, 'blue');
    this.addEgg(4,   2, 'red');
    this.addEgg(14,  2, 'orange');
    this.addEgg(14,  9, 'blue');

    this.addCarrot(0,   3);
    this.addCarrot(5,   3);
    this.addCarrot(9,  14);
    this.addCarrot(4,  11);
    this.addCarrot(16,  9);
    this.addCarrot(17,  9);
  }
}
