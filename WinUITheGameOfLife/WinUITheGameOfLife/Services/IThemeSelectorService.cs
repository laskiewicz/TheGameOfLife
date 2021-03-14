using System.Threading.Tasks;

using Microsoft.UI.Xaml;

namespace WinUITheGameOfLife.Services
{
    public interface IThemeSelectorService
    {
        ElementTheme Theme { get; }

        Task InitializeAsync();

        Task SetThemeAsync(ElementTheme theme);

        Task SetRequestedThemeAsync();
    }
}
