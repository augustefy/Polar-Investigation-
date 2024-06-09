namespace UndercoverGame.LesViews.ViewFooters;

public partial class FooterNomPerso : ContentView
{
	public FooterNomPerso()
	{
		InitializeComponent();
	}

    public event EventHandler? OnStartButtonClicked;
    

    private void StartButton_OnStartButtonClicked(object sender, EventArgs e)
    {
        OnStartButtonClicked?.Invoke(sender, e);
    }

    public event EventHandler? OnQuitButtonClicked;
    private void QuitButton_OnQuitButtonClicked(object sender, EventArgs e)
    {
        OnQuitButtonClicked?.Invoke(sender, e);
    }
}