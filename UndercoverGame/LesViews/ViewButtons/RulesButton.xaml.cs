using UndercoverGame.Popups;
using CommunityToolkit.Maui.Views;

namespace UndercoverGame.LesViews.ViewButtons;

public partial class RulesButton : ContentView
{
	public RulesButton()
	{
		InitializeComponent();
	}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        var popup = new PopUpRules();
        Application.Current.MainPage.ShowPopup(popup);
    }
}