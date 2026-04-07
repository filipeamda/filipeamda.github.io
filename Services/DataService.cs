using System.Net.Http.Json;
using filipealmeida.Models;

namespace filipealmeida.Services;

public class DataService
{
    private readonly HttpClient _http;
    private Bio? _bio;
    private List<Experience>? _experiences;
    private List<Skill>? _skills;
    private readonly Task _loadingTask;

    public DataService(HttpClient http)
    {
        _http = http;
        // Start loading all data as soon as the service is instantiated
        _loadingTask = LoadAllData();
    }

    private async Task LoadAllData()
    {
        var bioTask = _http.GetFromJsonAsync<Bio>("data/bio.json");
        var experiencesTask = _http.GetFromJsonAsync<List<Experience>>("data/experience.json");
        var skillsTask = _http.GetFromJsonAsync<List<Skill>>("data/skills.json");

        await Task.WhenAll(bioTask, experiencesTask, skillsTask);

        _bio = await bioTask;
        _experiences = await experiencesTask;
        _skills = await skillsTask;
    }

    public async Task EnsureLoadedAsync() => await _loadingTask;

    public Bio? Bio => _bio;
    public List<Experience>? Experiences => _experiences;
    public List<Skill>? Skills => _skills;
}