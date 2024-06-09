using CommunityToolkit.Maui.Views;
using UndercoverClass.Rules;

namespace UndercoverGame.Popups;

public partial class PopUpWhite : Popup
{
	public PopUpWhite(IRole role)
	{
		InitializeComponent();
        BindingContext = this;
	}

    void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = entry.Text;
    }

    void OnEntryCompleted(object sender, EventArgs e)
    {
        string text = ((Entry)sender).Text;
        Close(new string(text));
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        
        //var button = (Microsoft.Maui.Controls.ImageButton)sender;
        //var button = (Button)sender;
        //var i = (Entry)button.BindingContext;
        string text = entry.Text;
        Close(new string(text));
    }
}