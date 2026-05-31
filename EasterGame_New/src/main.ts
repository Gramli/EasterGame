import { Game }                               from './Game';
import { Renderer }                          from './GameRendering/Renderer';
import { Input }                             from './GameControls/Input';
import { CanvasManager }                     from './GameRendering/CanvasManager';
import { TouchControls }                     from './GameControls/TouchControls';
import { DeviceDetection }                   from './GameRendering/DeviceDetection';
import { loadImages }                        from './Assets';

if (DeviceDetection.isEmbedded()) {
  document.documentElement.classList.add('embedded');
}

const canvas        = document.getElementById('game') as HTMLCanvasElement;
const canvasManager = new CanvasManager('game');
const ctx           = canvas.getContext('2d')!;

ctx.fillStyle    = '#1a3a0e';
ctx.fillRect(0, 0, canvas.width, canvas.height);
ctx.fillStyle    = '#f1c40f';
ctx.font         = 'bold 24px system-ui, sans-serif';
ctx.textAlign    = 'center';
ctx.textBaseline = 'middle';
ctx.fillText('Loading…', canvas.width / 2, canvas.height / 2);

const images   = await loadImages();
const game     = new Game();
const renderer = new Renderer(ctx, images);

const hudLevel = document.getElementById('hud-level')!;
const hudEggs  = document.getElementById('hud-eggs')!;
const hudJumps = document.getElementById('hud-jumps')!;
const hudMoves = document.getElementById('hud-moves')!;
const hudTime  = document.getElementById('hud-time')!;

function startGame(): void {
  game.startLevel(0);
  redraw();
}

function updateHUD(): void {
  if (game.phase !== 'playing' && game.phase !== 'won' && game.phase !== 'lost') {
    hudLevel.textContent = hudEggs.textContent = hudJumps.textContent =
      hudMoves.textContent = hudTime.textContent = '';
    return;
  }
  const mm = Math.floor(game.elapsedSeconds / 60).toString().padStart(2, '0');
  const ss = (game.elapsedSeconds % 60).toString().padStart(2, '0');

  hudLevel.textContent = game.level.name;
  hudEggs.textContent  = `🥚 ${game.eggsLeft} left`;
  hudJumps.textContent = `🥕 ×${game.player.jumpsLeft}`;
  hudMoves.textContent = `Moves: ${game.player.moves}`;
  hudTime.textContent  = `⏱ ${mm}:${ss}`;
}

function redraw(): void {
  renderer.render(game, canvasManager.getTileSize());
  updateHUD();
}

if (DeviceDetection.shouldShowTouchControls()) {
  new TouchControls(game, startGame, redraw);
}

new Input(game, startGame, redraw);

canvasManager.onResize(() => redraw());
window.setInterval(redraw, 1000); 
redraw();

