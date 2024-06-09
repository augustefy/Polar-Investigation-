namespace UndercoverGame.LesViews.ViewButtons;

public partial class QuitButton : ContentView
{
	public QuitButton()
	{
		InitializeComponent();
	}
    public event EventHandler? OnQuitButtonClicked;
    private void Button_Clicked(object sender, EventArgs e)
    {
        OnQuitButtonClicked?.Invoke(sender, e);
    }
}