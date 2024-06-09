using CommunityToolkit.Maui.Views;
using UndercoverClass.Board;

namespace UndercoverGame;

public partial class PopUpWord : Popup
{
	public PopUpWord(Case Casec)
	{
		InitializeComponent();
		BindingContext = Casec;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Close(new string("yes"));
    }
}