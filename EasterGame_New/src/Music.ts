let music: HTMLAudioElement | null = null;

function getMusic(): HTMLAudioElement {
  if (!music) {
    music = new Audio('/assets/Mellowtron.mp3');
    music.loop = true;
  }

  return music;
}

export async function toggleMusic(): Promise<void> {
  const audio = getMusic();

  if (!audio.paused) {
    audio.pause();
    return;
  }

  try {
    await audio.play();
  } catch {
  }
}