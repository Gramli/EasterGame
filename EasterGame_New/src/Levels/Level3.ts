import { Level, CellType } from './Level';

export class Level3 extends Level {
  constructor() {
    super();
    this.name = 'Level 3';
  }

  setup(): void {
    this.setupWalls();
    this.addObjects();
    this.addTeleportPairs(5, 12, 19, 2);
    this.addDoor(Level.COLS - 1, Level.ROWS - 1);
  }

  private setupWalls(): void {
    this.fillColumn(1,  1, 11, CellType.Wall);
    this.fillDiagonal(2, 1, true, 4, CellType.Wall);
    this.fillDiagonal(7, 6, true, 2, CellType.Wall);
    this.fillColumn(9,  2, 13, CellType.Wall);
    this.fillColumn(13, 3, 12, CellType.Wall);
    this.fillColumn(15, 5, 10, CellType.Wall);
    this.fillColumn(17, 7,  8, CellType.Wall);
    this.fillRow(14, 3,  6, CellType.Wall);
    this.fillRow(16, 5,  4, CellType.Wall);
    this.fillRow(18, 7,  2, CellType.Wall);
    this.fillColumn(18, 0,  3, CellType.Wall);
  }

  private addObjects(): void {
    this.addEgg(4,   0, 'blue');
    this.addEgg(10, 12, 'red');
    this.addEgg(14,  5, 'orange');
    this.addEgg(16,  7, 'blue');
    this.addEgg(16,  1, 'red');

    this.addCarrot(0,  2);
    this.addCarrot(2,  3);
    this.addCarrot(11, 7);
  }
}
