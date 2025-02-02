using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using UserPanel.Models;
using UserPanel.Services;

namespace UserPanel.ViewModels;
public partial class HeroesViewModel : ObservableObject
{
    private readonly HeroService _heroService;

    [ObservableProperty] private ObservableCollection<Hero> _heroes;
    [ObservableProperty] private bool _isBusy;
    [ObservableProperty] private string? _errorMessage;

    public HeroesViewModel(HeroService heroService)
    {
        _heroService = heroService;
        LoadHeroes();
    }

    private async void LoadHeroes()
    {
        if (_isBusy) return;
        _isBusy = true;

        try
        {
            var heroes = await _heroService.GetHeroesAsync();
            if (heroes == null || !heroes.Any())
            {
                ErrorMessage = "Нет данных о героях.";
                return;
            }
            Heroes = new ObservableCollection<Hero>(heroes);
            Console.WriteLine($"Загружено {heroes.Count} героев.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка загрузки героев: {ex.Message}");
            ErrorMessage = $"Ошибка: {ex.Message}";
        }
        finally
        {
            _isBusy = false;
        }
    }
}