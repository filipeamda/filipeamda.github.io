function initTimeline() {
    console.log("Initializing timeline...");
    setTimeout(() => {
        gsap.registerPlugin(ScrollTrigger);

        const items = gsap.utils.toArray(".timeline-item");

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
        console.log("Timeline initialized.");
    }, 500);
}