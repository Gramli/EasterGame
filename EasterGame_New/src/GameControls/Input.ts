import { Game } from '../Game';
import { InputAction, applyAction } from './InputAction';

export class Input {
  constructor(
    private readonly game: Game,
    private readonly onStartGame: () => void,
    private readonly onRedraw: () => void,
  ) {
    window.addEventListener('keydown', (e) => this.handleKey(e));
  }

  private handleKey(e: KeyboardEvent): void {
    const action = this.keyToAction(e);
    if (action !== null) {
      e.preventDefault();
      applyAction(action, this.game, this.onStartGame, this.onRedraw);
    }
  }

  private keyToAction(e: KeyboardEvent): InputAction | null {
    const { phase } = this.game;
    switch (e.key) {
      case 'ArrowUp':    return 'MoveUp';
      case 'ArrowDown':  return 'MoveDown';
      case 'ArrowLeft':  return 'MoveLeft';
      case 'ArrowRight': return 'MoveRight';
      case ' ':
        if (phase === 'menu')    return 'StartOrRestart';
        if (phase === 'playing') return 'BigJump';
        return null;
      case 'Enter':
        if (phase === 'menu') return 'StartOrRestart';
        if (phase === 'won')  return 'NextLevel';
        return null;
      case 'r': case 'R': return 'StartOrRestart';
      case 's': case 'S': return 'ToggleMusic';
      default:            return null;
    }
  }
}
