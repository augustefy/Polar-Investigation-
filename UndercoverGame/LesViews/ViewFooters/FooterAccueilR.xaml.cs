namespace UndercoverGame.LesViews.ViewFooters;

public partial class FooterAccueilR : ContentView
{
	public FooterAccueilR()
	{
		InitializeComponent();
	}
    public event EventHandler? OnStartButtonClicked;
    private void StartButton_ButtonClicked(object sender, EventArgs e)
    {
        OnStartButtonClicked?.Invoke(sender, e);
    }

    public event EventHandler? OnLoadButtonClicked;
	public void LoadButton_ButtonClicked(object sender, EventArgs e)
	{
		OnLoadButtonClicked?.Invoke(this, e);
	}

}