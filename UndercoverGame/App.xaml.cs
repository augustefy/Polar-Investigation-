using UndercoverGame.LesPages;
using UndercoverClass.Game;
namespace UndercoverGame
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            Directory.SetCurrentDirectory(Path.Combine(Directory.GetCurrentDirectory(), "C:/"));

            MainPage = new AppShell();
            MainPage = new NavigationPage(new PageAccueil());
            //MainPage = new NavigationPage(new Ztest());
        }
    }
}
