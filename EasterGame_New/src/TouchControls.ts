import { Game } from './Game';
import { InputAction, applyAction } from './InputAction';

const DPAD: Array<{ action: InputAction; label: string; col: number; row: number }> = [
  { action: 'MoveUp',    label: '↑', col: 2, row: 1 },
  { action: 'MoveLeft',  label: '←', col: 1, row: 2 },
  { action: 'BigJump',   label: '⇧', col: 2, row: 2 },
  { action: 'MoveRight', label: '→', col: 3, row: 2 },
  { action: 'MoveDown',  label: '↓', col: 2, row: 3 },
];

export class TouchControls {
  constructor(
    private readonly game: Game,
    private readonly onStartGame: () => void,
    private readonly onRedraw: () => void,
  ) {
    document.getElementById('app')!.appendChild(this.build());
  }

  private build(): HTMLElement {
    const container = document.createElement('div');
    container.id = 'touch-controls';

    const grid = document.createElement('div');
    grid.className = 'touch-dpad';

    for (const { action, label, col, row } of DPAD) {
      const btn = this.createButton(label, action);
      btn.style.gridColumn = String(col);
      btn.style.gridRow    = String(row);
      grid.appendChild(btn);
    }

    const restart = this.createButton('R', 'StartOrRestart');
    restart.style.gridColumn = '1'
    restart.style.gridRow    = '3';
    grid.appendChild(restart);
    container.appendChild(grid);

    return container;
  }

  private createButton(label: string, action: InputAction): HTMLButtonElement {
    const btn = document.createElement('button');
    btn.className = 'touch-btn';
    btn.textContent = label;
    btn.type = 'button';

    const dispatch = () => applyAction(action, this.game, this.onStartGame, this.onRedraw);
    btn.addEventListener('click', dispatch);
    btn.addEventListener('touchstart', (e) => { e.preventDefault(); dispatch(); }, { passive: false });
    btn.addEventListener('touchend',   (e) =>   e.preventDefault(),               { passive: false });

    return btn;
  }
}
