namespace UndercoverGame;

public partial class ButtonsFooter : ContentView
{
	public ButtonsFooter()
	{
		InitializeComponent();
	}

    public event EventHandler? OnRestartButtonClicked;
    private void RestartButton_ButtonClicked(object sender, EventArgs e)
    {
        OnRestartButtonClicked?.Invoke(sender, e);
    }

    public event EventHandler? OnQuitButtonClicked;
    private void QuitButton_ButtonClicked(object sender, EventArgs e)
    {
        OnQuitButtonClicked?.Invoke(sender, e);
    }
}