export function detectLowRam() {
    if (navigator.deviceMemory && navigator.deviceMemory < 4) {
        document.body.classList.add("low-res-mode");
    }
}
