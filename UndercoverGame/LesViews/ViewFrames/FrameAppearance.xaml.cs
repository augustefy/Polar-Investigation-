namespace UndercoverGame.LesViews.ViewFrames;

public partial class FrameAppearance : ContentView
{
	public FrameAppearance()
	{
		InitializeComponent();
	}

	public void colorChanged(object sender, EventArgs e)
	{
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex == 0)
        {
            Application.Current.UserAppTheme = AppTheme.Light;
        }

        if (selectedIndex == 1)
        {
            Application.Current.UserAppTheme = AppTheme.Dark;
        }

        
    }
}