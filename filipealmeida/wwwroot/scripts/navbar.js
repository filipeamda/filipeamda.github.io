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

        gsap.registerPlugin(ScrollTrigger);

        gsap.set(navbar, {
            '--navbar-bg': 'rgba(18, 18, 18, 0.1)'
        });

        gsap.to(navbar, {
            '--navbar-bg': 'rgba(18, 18, 18, 0.3)',
            ease: 'none',
            scrollTrigger: {
                trigger: document.body,
                start: '30px top',
                end: '500px top',
                toggleActions: 'play none none reverse'
            }
        });
    },
    scrollToTop: function () {
        window.scrollTo({
            top: 0,
            behavior: 'smooth'
        });
    }
};