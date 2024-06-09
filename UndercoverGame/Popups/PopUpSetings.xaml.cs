using CommunityToolkit.Maui.Views;

namespace UndercoverGame.Popups;

public partial class PopUpSetings : Popup
{
	public PopUpSetings()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Close();
    }
}