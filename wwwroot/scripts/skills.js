function initSkillCloud(skills) {
    if (typeof TagCloud === 'undefined') {
        console.error('TagCloud not loaded');
        return;
    }

    const container = document.querySelector('.skills-container');
    if (!container) {
        console.error('Skills container element not found');
        return;
    }

    console.log("Initializing skill cloud with skills:", skills);
    const texts = [];
    skills.forEach(skill => {
        texts.push(skill.name);
    });

    const options = {
        radius: 250,
        maxSpeed: 'normal',
        initSpeed: 'normal',
        direction: 135,
        keep: true
    };

    TagCloud(container, texts, options);
    console.log("Skill cloud initialized.");
}