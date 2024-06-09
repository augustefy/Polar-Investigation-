namespace UndercoverGame.LesViews.ViewButtons;

public partial class ButtonMoins : ContentView
{
	public ButtonMoins()
	{
		InitializeComponent();
	}
    public event EventHandler? OnButtonClicked;
    private void Button_Clicked(object sender, EventArgs e)
    {
        OnButtonClicked?.Invoke(sender, e);
    }
}