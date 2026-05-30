const music = new Audio('/assets/Mellowtron.wav');
music.loop  = true;

let playing = false;

export function startMusicOnFirstPlay(): void {
  if (!playing) {
    music.play().catch(() => {});
    playing = true;
  }
}

export function toggleMusic(): void {
  if (playing) {
    music.pause();
    playing = false;
  } else {
    music.play().catch(() => {});
    playing = true;
  }
}
