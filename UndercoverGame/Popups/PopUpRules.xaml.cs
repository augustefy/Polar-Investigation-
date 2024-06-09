using CommunityToolkit.Maui.Views;

namespace UndercoverGame.Popups;

public partial class PopUpRules : Popup
{
	public PopUpRules()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}