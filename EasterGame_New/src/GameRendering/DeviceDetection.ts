export class DeviceDetection {
  private static isTouchDeviceCache: boolean | null = null;

  static isTouchDevice(): boolean {
    if (this.isTouchDeviceCache !== null) {
      return this.isTouchDeviceCache;
    }
    const hasCoarsePointer = window.matchMedia("(pointer: coarse)").matches;
    const hasTouchEvents = "ontouchstart" in window;
    const maxTouchPoints = navigator.maxTouchPoints > 0;
    this.isTouchDeviceCache = hasCoarsePointer || hasTouchEvents || maxTouchPoints;
    return this.isTouchDeviceCache;
  }

  private static isSmallScreen(): boolean {
    return window.innerWidth < 768;
  }

  static shouldShowTouchControls(): boolean {
    return this.isTouchDevice() || this.isSmallScreen();
  }
}
