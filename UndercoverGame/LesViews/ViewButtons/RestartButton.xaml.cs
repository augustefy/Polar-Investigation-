namespace UndercoverGame.LesViews.ViewButtons;

public partial class RestartButton : ContentView
{
	public RestartButton()
	{
		InitializeComponent();
	}

    public event EventHandler? OnRestartButtonClicked;
    private void Button_Clicked(object sender, EventArgs e)
    {
        OnRestartButtonClicked?.Invoke(sender, e);
    }
}