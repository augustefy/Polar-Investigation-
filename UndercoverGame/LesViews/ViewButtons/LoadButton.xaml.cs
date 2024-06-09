namespace UndercoverGame.LesViews.ViewButtons;

public partial class LoadButton : ContentView
{
	public event EventHandler? OnReloadButton;
	public LoadButton()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        OnReloadButton?.Invoke(sender, e);
    }
}