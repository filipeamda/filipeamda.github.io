function initSkillCloud(skills) {
    console.log("Initializing skill cloud with skills:", skills);
    const container = '.skills-container';
    const texts = skills;
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