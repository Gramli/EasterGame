import { Level } from './Levels/Level';

export class CanvasManager {
  private canvas: HTMLCanvasElement;
  private currentTileSize: number = Level.TILE_SIZE;
  private resizeObserver: ResizeObserver | null = null;
  private readonly MIN_TILE_SIZE = 24;
  private readonly MAX_TILE_SIZE = 48;
  private readonly CONTROL_HEIGHT = 80;
  private onResizeCallback: (() => void) | null = null;

  constructor(canvasElementId: string) {
    const canvas = document.getElementById(canvasElementId);
    if (!canvas || !(canvas instanceof HTMLCanvasElement)) {
      throw new Error(`Canvas element with id "${canvasElementId}" not found`);
    }
    this.canvas = canvas;
    this.setupResizeListener();
    this.recalculateSize();
  }

  onResize(callback: () => void): void {
    this.onResizeCallback = callback;
  }

  getTileSize(): number {
    return this.currentTileSize;
  }

  recalculateSize(): void {
    const newTileSize = this.calculateOptimalTileSize();
    if (newTileSize !== this.currentTileSize) {
      this.currentTileSize = newTileSize;
      this.applyCanvasSize();
      if (this.onResizeCallback) {
        this.onResizeCallback();
      }
    }
  }

  private calculateOptimalTileSize(): number {
    const isMobile = this.isMobileScreen();
    const availableWidth = window.innerWidth;
    const availableHeight = window.innerHeight;
    const effectiveHeight = isMobile
      ? availableHeight - this.CONTROL_HEIGHT - 150
      : availableHeight - 150;

    const tileSizeFromWidth  = Math.floor((availableWidth  - 20) / Level.COLS);
    const tileSizeFromHeight = Math.floor(effectiveHeight        / Level.ROWS);
    const tileSize = Math.max(
      this.MIN_TILE_SIZE,
      Math.min(this.MAX_TILE_SIZE, Math.min(tileSizeFromWidth, tileSizeFromHeight)),
    );

    return tileSize;
  }

  private isMobileScreen(): boolean {
    return window.innerWidth < 768;
  }

  private applyCanvasSize(): void {
    const canvasWidth = Level.COLS * this.currentTileSize;
    const canvasHeight = Level.ROWS * this.currentTileSize;

    this.canvas.width = canvasWidth;
    this.canvas.height = canvasHeight;

    const hud = document.getElementById('hud');
    if (hud) hud.style.width = this.isMobileScreen() ? '100%' : `${canvasWidth}px`;

    const isMobile = this.isMobileScreen();
    this.canvas.style.maxWidth  = isMobile ? '100vw' : 'none';
    this.canvas.style.maxHeight = isMobile ? '100vh' : 'none';
  }

  private setupResizeListener(): void {
    window.addEventListener('resize', () => {
      this.recalculateSize();
    });

    // Handle orientation change (mobile)
    window.addEventListener('orientationchange', () => {
      setTimeout(() => this.recalculateSize(), 100);
    });

    if (typeof ResizeObserver !== 'undefined') {
      const appContainer = document.getElementById('app');
      if (appContainer) {
        this.resizeObserver = new ResizeObserver(() => {
          this.recalculateSize();
        });
        this.resizeObserver.observe(appContainer);
      }
    }
  }

  destroy(): void {
    if (this.resizeObserver) {
      this.resizeObserver.disconnect();
    }
  }
}
