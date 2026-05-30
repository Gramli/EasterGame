import { Game } from './Game';
import { Direction } from './GameObjects/Player';
import { toggleMusic } from './Music';

export type InputAction =
  | 'MoveUp'
  | 'MoveDown'
  | 'MoveLeft'
  | 'MoveRight'
  | 'BigJump'
  | 'StartOrRestart'
  | 'NextLevel'
  | 'ToggleMusic';

export function applyAction(
  action: InputAction,
  game: Game,
  onStartGame: () => void,
  onRedraw: () => void,
): void {
  if (action === 'ToggleMusic') {
    toggleMusic();
    return;
  }

  switch (game.phase) {
    case 'menu':
      if (action === 'StartOrRestart') onStartGame();
      return;

    case 'won':
      if (action === 'NextLevel' && game.hasNextLevel) {
        game.nextLevel();
        onRedraw();
      } else if (action === 'StartOrRestart') {
        game.restartLevel();
        onRedraw();
      }
      return;

    case 'lost':
      if (action === 'StartOrRestart') {
        game.restartLevel();
        onRedraw();
      }
      return;

    case 'playing':
      switch (action) {
        case 'MoveUp':         game.setDirection(Direction.Up);    game.handleMove(0, -1); break;
        case 'MoveDown':       game.setDirection(Direction.Down);  game.handleMove(0, 1);  break;
        case 'MoveLeft':       game.setDirection(Direction.Left);  game.handleMove(-1, 0); break;
        case 'MoveRight':      game.setDirection(Direction.Right); game.handleMove(1, 0);  break;
        case 'BigJump':        game.handleJump();                                          break;
        case 'StartOrRestart': game.restartLevel();                                        break;
        default: return;
      }
      onRedraw();
      return;
  }
}
