import { Level, CellType } from './Level';

export class Level1 extends Level {
  constructor() {
    super();
    this.name = 'Level 1';
  }

  setup(): void {
    this.setupTeleports();
    this.setupWalls();
    this.addObjects();
    this.addDoor(Level.COLS - 1, Level.ROWS - 1);
  }

  private setupTeleports(): void {
    this.addTeleportPairs(4, 10, 16, 5);
  }

  private setupWalls(): void {
    this.fillDiagonal(1, 1, true, Level.ROWS, CellType.Wall);
    this.fillDiagonal(Level.COLS - 3, 2, false, Level.ROWS, CellType.Wall);
    this.fillDiagonal(2, 1, true, Level.ROWS - 3, CellType.Wall);
    this.fillColumn(7, 2, 5, CellType.Wall);
    this.grid[0][2] = CellType.Wall;
  }

  private addObjects(): void {
    this.addEgg(2,  11, 'blue');
    this.addEgg(18,  4, 'red');
    this.addEgg(10,  8, 'orange');
    this.addEgg(14,  4, 'blue');
    this.addEgg(14, 11, 'red');

    this.addCarrot(0, 1);
    this.addCarrot(9, 7);
  }
}
