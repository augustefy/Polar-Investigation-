using UndercoverGame.LesPages;

namespace UndercoverGame;

public partial class headerPickCard : ContentView
{

    public static readonly BindableProperty NJoueurProperty =
		BindableProperty.Create("NJoueur", typeof(string), typeof(headerPickCard), "simoni", propertyChanged: (s, n, o) =>
		{

		});
	
	public string NJoueur
	{
		get => (string)GetValue(NJoueurProperty);
		set => SetValue(NJoueurProperty, value);
	}

    public headerPickCard()
    {
        InitializeComponent();
    }
}