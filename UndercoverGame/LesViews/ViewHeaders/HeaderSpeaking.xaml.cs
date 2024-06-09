namespace UndercoverGame.LesViews.ViewHeaders;

public partial class HeaderSpeaking : ContentView
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

    public static readonly BindableProperty TitreProperty =
    BindableProperty.Create("Titre", typeof(string), typeof(HeaderSpeaking), "A Vous De Jouer");

    public string Titre
    {
        get => (string)GetValue(TitreProperty);
        set => SetValue(TitreProperty, value);
    }

    public HeaderSpeaking()
	{
		InitializeComponent();
	}
}