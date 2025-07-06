﻿window.navbarScroll = {
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
            backgroundColor: 'rgba(18, 18, 18, 0.1)',
            backdropFilter: 'blur(0px)'
        });

        gsap.to(navbar, {
            backgroundColor: 'rgba(18, 18, 18, 0.1)',
            backdropFilter: 'blur(10px)',
            ease: 'none',
            scrollTrigger: {
                trigger: document.body,
                start: '30px top',
                end: '500px top',
                toggleActions: 'play none none reverse'
            }
        });
    }
};