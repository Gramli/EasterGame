import { Level, CellType } from './Level';

export class Level2 extends Level {
  constructor() {
    super();
    this.name = 'Level 2';
  }

  setup(): void {
    this.setupWalls();
    this.addObjects();
    this.addTeleportPairs(17, 1, 16, 6);
    this.addDoor(Level.COLS - 1, Level.ROWS - 1);
  }

  private setupWalls(): void {
    this.fillColumn(1,  0, 12, CellType.Wall);
    this.fillColumn(5,  0, 15, CellType.Wall);
    this.fillColumn(3,  4,  3, CellType.Wall);
    this.fillColumn(3,  9,  6, CellType.Wall);
    this.fillRow(4,     4, 17, CellType.Wall);
    this.fillColumn(11, 0,  6, CellType.Wall);
    this.fillDiagonal(8, 5, true, 10, CellType.Wall);
  }

  private addObjects(): void {
    this.addEgg(2,  13, 'blue');
    this.addEgg(4,   1, 'red');
    this.addEgg(4,  11, 'orange');
    this.addEgg(8,  12, 'blue');
    this.addEgg(9,   1, 'blue');
    this.addEgg(19,  2, 'red');
    this.addEgg(15,  8, 'orange');
    this.addEgg(19, 12, 'blue');

    this.addCarrot(2,  0);
    this.addCarrot(4, 12);
    this.addCarrot(6,  0);
    this.addCarrot(12, 10);
  }
}
