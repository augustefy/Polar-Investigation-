namespace UndercoverGame.LesViews.ViewButtons;

public partial class StartButton : ContentView
{
	public StartButton()
	{
		InitializeComponent();
	}

    public event EventHandler? OnStartButtonClicked;
    private void Button_Clicked(object sender, EventArgs e)
    {
        OnStartButtonClicked?.Invoke(sender, e);
    }
}