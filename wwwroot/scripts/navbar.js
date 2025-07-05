window.navbarScroll = {
    init: function () {
        if (typeof gsap === 'undefined' || typeof ScrollTrigger === 'undefined') {
            console.error('GSAP or ScrollTrigger not loaded');
            return;
        }

        const navbar = document.querySelector('.navbar');
        if (!navbar) {
            console.error('Navbar element not found');
            return;
        }

        // Register ScrollTrigger
        gsap.registerPlugin(ScrollTrigger);

        // Set initial state
        gsap.set(navbar, { backgroundColor: 'rgba(255, 0, 0, 0)' }); // Red for visibility

        // Animate background
        gsap.to(navbar, {
            backgroundColor: 'rgba(255, 0, 0, 1)', // Fully opaque red
            ease: 'none',
            scrollTrigger: {
                trigger: document.body,
                start: 'top top',
                end: '500px top', // Longer range for testing
                scrub: true,
                toggleActions: 'play none none reverse'
            }
        });
    }
};