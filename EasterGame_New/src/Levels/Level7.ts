import { Level, CellType } from './Level';

export class Level7 extends Level {
  constructor() {
    super();
    this.name = 'Level 7';
  }

  setup(): void {
    this.setupWalls();
    this.addObjects();
    this.addTeleportPairs(1, 2, 9, 1, 2, 4, 8, 7, 0, 12, 19, 13);
    this.addDoor(Level.COLS - 1, Level.ROWS - 1);
  }

  private setupWalls(): void {
    this.fillColumn(4,  0, 15, CellType.Wall);
    this.fillColumn(11, 0, 15, CellType.Wall);
    this.fillRow(5,  2,  6, CellType.Wall);
    this.fillRow(0,  9,  4, CellType.Wall);
    this.fillRow(12, 12,  6, CellType.Wall);
    this.fillRow(9,  0,  2, CellType.Wall);
  }

  private addObjects(): void {
    this.fillRow(12, 13, 7, CellType.EggCell);
    this.fillRow(12, 14, 7, CellType.EggCell);
    this.spawnEggsFromGrid('red');

    this.addEgg(7,   1, 'blue');
    this.addEgg(6,   4, 'red');
    this.addEgg(10,  6, 'orange');
    this.addEgg(5,  11, 'blue');
    this.addEgg(9,  13, 'red');
    this.addEgg(15,  4, 'orange');

    this.addCarrot(10, 1);
    this.addCarrot(5,  7);
  }
}
