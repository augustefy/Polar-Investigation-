using CommunityToolkit.Maui.Views;
using UndercoverClass.Rules;

namespace UndercoverGame.Popups;

public partial class PopUpWhiteWin : Popup
{
	public PopUpWhiteWin(IRole WGagnant)
	{
		InitializeComponent();
		BindingContext = WGagnant;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Close(new string("yes"));
    }
}