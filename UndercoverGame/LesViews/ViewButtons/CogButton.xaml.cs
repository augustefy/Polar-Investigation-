using UndercoverGame.Popups;
using CommunityToolkit.Maui.Views;

namespace UndercoverGame.LesViews.ViewButtons;

public partial class CogButton : ContentView
{
    public CogButton()
	{
		InitializeComponent();
	}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        var popup = new PopUpSetings();
        Application.Current.MainPage.ShowPopup(popup);
    }
}