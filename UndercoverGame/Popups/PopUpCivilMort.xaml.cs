using CommunityToolkit.Maui.Views;
using UndercoverClass.Rules;

namespace UndercoverGame.Popups;

public partial class PopUpCivilMort : Popup
{
    public static readonly BindableProperty QuiProperty =
    BindableProperty.Create("Qui", typeof(string), typeof(PopUpCivilMort), "simoni");

    public string Qui
    {
        get => (string)GetValue(QuiProperty);
        set => SetValue(QuiProperty, value);
    }

    public PopUpCivilMort(IRole j)
	{
		InitializeComponent();
        Qui = j.Joueur.Name + " est mort!";
        BindingContext = this;
	}
    private void Button_Clicked(object sender, EventArgs e)
    {
        Close(new string("yes"));
    }
}