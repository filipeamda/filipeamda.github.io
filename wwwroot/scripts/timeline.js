function initTimeline() {
    if (typeof gsap === 'undefined' || typeof ScrollTrigger === 'undefined') {
        console.error('GSAP or ScrollTrigger not loaded');
        return;
    }

    gsap.registerPlugin(ScrollTrigger);

    const items = gsap.utils.toArray(".timeline-item");

    if (items.length === 0) {
        return;
    }

    items.forEach((item, index) => {
        const direction = index % 2 === 0 ? -1 : 1;

        gsap.fromTo(item,
            {
                x: 100 * direction,
                opacity: 0
            },
            {
                x: 0,
                opacity: 1,
                duration: 1.2,
                ease: "power3.out",
                scrollTrigger: {
                    trigger: item,
                    start: "top 80%",
                    toggleActions: "play none none none"
                }
            }
        );
    });
}