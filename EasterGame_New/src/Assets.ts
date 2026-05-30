export interface GameImages {
  trava:           HTMLImageElement;
  mrtvePole:       HTMLImageElement;
  kamen:           HTMLImageElement;
  teleport:        HTMLImageElement;
  dvere:           HTMLImageElement;
  mrkev:           HTMLImageElement;
  vajickoModre:    HTMLImageElement;
  vajickoCervene:  HTMLImageElement;
  vajickoOranzove: HTMLImageElement;
  zajicDoprava:    HTMLImageElement;
  zajicDoleva:     HTMLImageElement;
  zajicNahoru:     HTMLImageElement;
  zajicDolu:       HTMLImageElement;
}

function loadImage(src: string): Promise<HTMLImageElement> {
  return new Promise((resolve, reject) => {
    const img = new Image();
    img.onload  = () => resolve(img);
    img.onerror = () => reject(new Error(`Could not load image: ${src}`));
    img.src = src;
  });
}

export async function loadImages(): Promise<GameImages> {
  const [
    trava, mrtvePole, kamen, teleport, dvere,
    mrkev, vajickoModre, vajickoCervene, vajickoOranzove,
    zajicDoprava, zajicDoleva, zajicNahoru, zajicDolu,
  ] = await Promise.all([
    loadImage('/assets/trava.png'),
    loadImage('/assets/mrtvePole.png'),
    loadImage('/assets/kamen_hnedy_2.png'),
    loadImage('/assets/teleport.png'),
    loadImage('/assets/dvere.png'),
    loadImage('/assets/mrkev.png'),
    loadImage('/assets/vajicko_modre.png'),
    loadImage('/assets/vajicko_cervene.png'),
    loadImage('/assets/vajicko_oranzove.png'),
    loadImage('/assets/zajic_sedi_doprava.png'),
    loadImage('/assets/zajic_sedi_doleva.png'),
    loadImage('/assets/zajic_sedi_nahoru.png'),
    loadImage('/assets/zajic_sedi_dolu.png'),
  ]);

  return {
    trava, mrtvePole, kamen, teleport, dvere,
    mrkev, vajickoModre, vajickoCervene, vajickoOranzove,
    zajicDoprava, zajicDoleva, zajicNahoru, zajicDolu,
  };
}
