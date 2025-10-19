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

    const texts = [];
    skills.forEach(skill => {
        texts.push(skill.name);
    });

    const options = {
        radius: 200,
        maxSpeed: 'normal',
        initSpeed: 'slow',
        direction: 135,
        keep: true
    };

    TagCloud(container, texts, options);
}