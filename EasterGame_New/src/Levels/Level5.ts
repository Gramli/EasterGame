import { Level, CellType } from './Level';

export class Level5 extends Level {
  constructor() {
    super();
    this.name = 'Level 5';
  }

  setup(): void {
    this.setupWalls();
    this.addObjects();
    this.addTeleportPairs(6, 14, 19, 9, 12, 14, 17, 14);
    this.addDoor(Level.COLS - 1, Level.ROWS - 1);
    this.addDoor(0, Level.ROWS - 1);
  }

  private setupWalls(): void {
    this.fillColumn(3,   1, 14, CellType.Wall);
    this.fillRow(0,     12, 20, CellType.Wall);
    this.fillDiagonal(4,  2, true,  10, CellType.Wall);
    this.fillDiagonal(19, 5, false,  6, CellType.Wall);
    this.fillColumn(9,  13,  2, CellType.Wall);
    this.fillColumn(14, 13,  2, CellType.Wall);
  }

  private addObjects(): void {
    this.addEgg(6,   8, 'blue');
    this.addEgg(10,  2, 'red');
    this.addEgg(14,  5, 'orange');
    this.addEgg(11, 13, 'blue');
    this.addEgg(18,  9, 'red');

    this.addCarrot(1,   3);
    this.addCarrot(4,  14);
    this.addCarrot(8,  11);
    this.addCarrot(17, 11);
  }
}
