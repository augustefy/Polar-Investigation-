namespace UndercoverGame.LesViews.ViewFooters;

public partial class FooterAccueil : ContentView
{
	public FooterAccueil()
	{
		InitializeComponent();
	}
    public event EventHandler? OnStartButtonClicked;
    private void StartButton_ButtonClicked(object sender, EventArgs e)
    {
        OnStartButtonClicked?.Invoke(sender, e);
    }

    public event EventHandler? OnQuitButtonClicked;
    private void QuitButton_ButtonClicked(object sender, EventArgs e)
    {
        OnQuitButtonClicked?.Invoke(sender, e);
    }

}