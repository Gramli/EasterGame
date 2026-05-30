import { Game } from './Game';
import { Direction } from './GameObjects/Player';
import { toggleMusic, startMusicOnFirstPlay } from './Music';

export class Input {
  constructor(
    private readonly game:    Game,
    private readonly onRedraw: () => void,
  ) {
    window.addEventListener('keydown', (e) => this.handleKey(e));
  }

  private handleKey(e: KeyboardEvent): void {
    const { game, onRedraw } = this;

    if (game.phase === 'menu') {
      if (e.key === 'Enter' || e.key === ' ') {
        e.preventDefault();
        game.startLevel(0);
        startMusicOnFirstPlay();
        onRedraw();
      }
      return;
    }


    if (game.phase === 'won') {
      if (e.key === 'Enter' && game.hasNextLevel) {
        game.nextLevel();
        onRedraw();
      } else if (e.key === 'r' || e.key === 'R') {
        game.restartLevel();
        onRedraw();
      }
      return;
    }


    if (game.phase === 'lost') {
      if (e.key === 'r' || e.key === 'R') {
        game.restartLevel();
        onRedraw();
      }
      return;
    }


    switch (e.key) {
      case 'ArrowRight':
        e.preventDefault();
        game.setDirection(Direction.Right);
        game.handleMove(1, 0);
        break;
      case 'ArrowLeft':
        e.preventDefault();
        game.setDirection(Direction.Left);
        game.handleMove(-1, 0);
        break;
      case 'ArrowUp':
        e.preventDefault();
        game.setDirection(Direction.Up);
        game.handleMove(0, -1);
        break;
      case 'ArrowDown':
        e.preventDefault();
        game.setDirection(Direction.Down);
        game.handleMove(0, 1);
        break;
      case ' ':
        e.preventDefault();
        game.handleJump();
        break;
      case 'r':
      case 'R':
        game.restartLevel();
        break;
      case 's':
      case 'S':
        toggleMusic();
        return;
      default:
        return;
    }

    onRedraw();
  }
}

