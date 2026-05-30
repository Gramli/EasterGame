import { Level, CellType } from './Level';

// Copilot Level — "The Cross"
//
// A cross-shaped wall barrier splits the 20×15 map into four quadrants:
//
//   Q1 (TL) x 0-8 / y 0-5  │  Q2 (TR) x 10-19 / y 0-5
//   ─────────────────────────┼─────────────────────────
//   Q3 (BL) x 0-8 / y 7-14 │  Q4 (BR) x 10-19 / y 7-14
//
// Cross gaps that let the player move between quadrants:
//   • Top of vertical arm   (x=9, y=0)      — Q1 ↔ Q2, free walk
//   • Bottom of vertical arm (x=9, y=13-14) — Q3 ↔ Q4, free walk
//   • Left end of horizontal arm (x=0-2, y=6) — Q1 ↔ Q3, free walk
//   • Right end of horizontal arm (x=17-19, y=6) — Q2 ↔ Q4, free walk
//
// Teleport: (18,2) in Q2 ↔ (1,13) in Q3 — optional diagonal shortcut.
// Carrots at (7,4) and (6,11): let the player jump over the vertical arm
//   from (8,y) → (10,y), skipping the backtrack to the top/bottom gap.
//
// Finishability: All eight eggs are reachable via gap traversal. One valid
//   route — Q1 → Q2 via top gap → teleport to Q3 → Q4 via bottom gap → door.
export class CopilotLevel extends Level {
  constructor() {
    super();
    this.name = 'Copilot Level';
  }

  setup(): void {
    this.setupWalls();
    this.addObjects();
    // Teleport: top-right quadrant corner ↔ bottom-left quadrant corner.
    // Both cells sit in dead-end corners so the player triggers them
    // intentionally rather than by accident.
    this.addTeleportPairs(18, 2, 1, 13);
    this.addDoor(Level.COLS - 1, Level.ROWS - 1);
  }

  private setupWalls(): void {
    // Horizontal arm: y=6, x=3..16.
    // Leaves x=0,1,2 (left gap) and x=17,18,19 (right gap) open.
    this.fillRow(3, 6, 14, CellType.Wall);

    // Vertical arm: x=9, y=1..12.
    // Leaves y=0 (top gap) and y=13,14 (bottom gap) open.
    this.fillColumn(9, 1, 12, CellType.Wall);
  }

  private addObjects(): void {
    // Q1 — top-left (x<9, y<6): eggs near the cross arms reward exploration.
    this.addEgg(2,  2, 'blue');
    this.addEgg(5,  4, 'orange');

    // Q2 — top-right (x>9, y<6): eggs spread so the player sweeps the quadrant
    // before heading toward the teleport at (18,2).
    this.addEgg(14, 1, 'red');
    this.addEgg(17, 4, 'blue');

    // Q3 — bottom-left (x<9, y>6): eggs near the interior encourage visiting
    // both the mid-area and the bottom edge.
    this.addEgg(3,  10, 'orange');
    this.addEgg(6,  13, 'red');

    // Q4 — bottom-right (x>9, y>6): last two eggs before the exit.
    // Player reaches here via the right gap or the bottom-of-arm gap.
    this.addEgg(16, 8,  'blue');
    this.addEgg(12, 11, 'red');

    // Carrot in Q1: collecting it and then walking to x=8 lets the player
    // jump right, skipping the vertical arm to land directly in Q2 (x=10).
    this.addCarrot(7,  4);

    // Carrot in Q3: mirrors the Q1 carrot — jump from x=8 to x=10 at y=11,
    // crossing the vertical arm to reach Q4 without going back to y=13 gap.
    this.addCarrot(6,  11);
  }
}
