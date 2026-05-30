import { Player, Direction } from './GameObjects/Player';
import { Egg } from './GameObjects/Egg';
import { Carrot } from './GameObjects/Carrot';
import { Level, CellType } from './Levels/Level';
import { Level1 } from './Levels/Level1';
import { Level2 } from './Levels/Level2';
import { Level3 } from './Levels/Level3';
import { Level4 } from './Levels/Level4';
import { Level5 } from './Levels/Level5';
import { Level6 } from './Levels/Level6';
import { Level7 } from './Levels/Level7';
import { CopilotLevel } from './Levels/CopilotLevel';

export type GamePhase = 'menu' | 'playing' | 'won' | 'lost';

const LEVELS: Array<() => Level> = [
  () => new Level1(),
  () => new Level2(),
  () => new Level3(),
  () => new Level4(),
  () => new Level5(),
  () => new Level6(),
  () => new Level7(),
  () => new CopilotLevel(),
];

export class Game {
  phase: GamePhase = 'menu';
  levelIndex:     number = 0;
  level!:         Level;
  player!:        Player;
  elapsedSeconds: number = 0;

  private timerHandle: number | null = null;

  get eggsLeft(): number {
    return this.level.totalEggs - this.player.collectedEggs;
  }

  get hasNextLevel(): boolean {
    return this.levelIndex + 1 < LEVELS.length;
  }

  startLevel(index: number): void {
    this.levelIndex = index;
    this.level      = LEVELS[index]();
    this.level.setup();

    this.player         = new Player(0, 0);
    this.phase          = 'playing';
    this.elapsedSeconds = 0;

    this.stopTimer();
    this.timerHandle = window.setInterval(() => {
      if (this.phase === 'playing') this.elapsedSeconds++;
    }, 1000);
  }

  restartLevel(): void {
    this.startLevel(this.levelIndex);
  }

  nextLevel(): void {
    if (this.levelIndex + 1 < LEVELS.length) {
      this.startLevel(this.levelIndex + 1);
    }
  }

  handleMove(dx: number, dy: number): void {
    if (this.phase !== 'playing') return;

    const nx = this.player.x + dx;
    const ny = this.player.y + dy;
    if (!this.canMoveTo(nx, ny)) return;

    this.leaveCurrentCell();
    this.player.x = nx;
    this.player.y = ny;
    this.player.moves++;

    this.checkTeleport();
    this.collectItems();
    this.checkEndConditions();
  }

  handleJump(): void {
    if (this.phase !== 'playing' || this.player.jumpsLeft <= 0) return;

    const dir = this.player.direction;
    const dx  = dir === Direction.Right ? 2 : dir === Direction.Left ? -2 : 0;
    const dy  = dir === Direction.Down  ? 2 : dir === Direction.Up   ? -2 : 0;

    const nx = this.player.x + dx;
    const ny = this.player.y + dy;
    if (!this.canMoveTo(nx, ny)) return;

    this.leaveCurrentCell();
    this.player.x = nx;
    this.player.y = ny;
    this.player.moves++;
    this.player.jumpsLeft--;

    this.checkTeleport();
    this.collectItems();
    this.checkEndConditions();
  }

  setDirection(direction: Direction): void {
    if (this.phase === 'playing') {
      this.player.setDirection(direction);
    }
  }

  private canMoveTo(x: number, y: number): boolean {
    if (x < 0 || x >= Level.COLS || y < 0 || y >= Level.ROWS) return false;
    const cell = this.level.grid[x][y];
    return cell !== CellType.Wall && cell !== CellType.Dead;
  }

  private leaveCurrentCell(): void {
    const { x, y } = this.player;
    if (this.level.grid[x][y] !== CellType.Teleport && !this.level.isDoor(x, y)) {
      this.level.grid[x][y] = CellType.Dead;
    }
  }

  private checkTeleport(): void {
    const dest = this.level.getTeleportDestination(this.player.x, this.player.y);
    if (dest) {
      this.player.x = dest.x;
      this.player.y = dest.y;
    }
  }

  private collectItems(): void {
    const { x, y } = this.player;
    this.level.objects = this.level.objects.filter(obj => {
      if (obj.x === x && obj.y === y) {
        if (obj instanceof Egg) {
          this.player.collectedEggs++;
          return false;
        }
        if (obj instanceof Carrot) {
          this.player.jumpsLeft++;
          return false;
        }
      }
      return true;
    });
  }

  private checkEndConditions(): void {
    const { x, y } = this.player;

    if (this.level.isDoor(x, y) && this.eggsLeft === 0) {
      this.stopTimer();
      this.phase = 'won';
      return;
    }

    if (!this.hasLegalMove()) {
      this.stopTimer();
      this.phase = 'lost';
    }
  }

  private hasLegalMove(): boolean {
    const { x, y, jumpsLeft } = this.player;
    const steps = jumpsLeft > 0 ? [1, 2] : [1];

    for (const step of steps) {
      if (this.canMoveTo(x + step, y)) return true;
      if (this.canMoveTo(x - step, y)) return true;
      if (this.canMoveTo(x, y + step)) return true;
      if (this.canMoveTo(x, y - step)) return true;
    }
    return false;
  }

  private stopTimer(): void {
    if (this.timerHandle !== null) {
      window.clearInterval(this.timerHandle);
      this.timerHandle = null;
    }
  }
}
