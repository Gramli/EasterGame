let music: HTMLAudioElement | null = null;
let playing = false;

export function toggleMusic(): void {
  if (!music) {
    music = new Audio('/assets/Mellowtron.mp3');
    music.loop = true;
  }

  if (playing) {
    music.pause();
    playing = false;
  } else {
    playing = true;
    music.play().catch(() => {});
  }
}