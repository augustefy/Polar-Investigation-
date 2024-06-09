using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using UndercoverClass.Rules;

namespace UndercoverGame.Popups;

public partial class PopUpUnderWin : Popup
{
    public static readonly BindableProperty RoleNameProperty =
    BindableProperty.Create("RoleName", typeof(string), typeof(PopUpUnderWin), "simoni");

    public string RoleName
    {
        get => (string)GetValue(RoleNameProperty);
        set => SetValue(RoleNameProperty, value);
    }
    //private string roleName;
    public ReadOnlyCollection<IRole> JoueursG { get; private set; }

    public List<IRole> joueursG = new List<IRole>();

    public PopUpUnderWin(string role,List<IRole> joueurs)
	{
		InitializeComponent();
		RoleName = role + " ont gagner!";
        joueursG = joueurs;
        JoueursG = new ReadOnlyCollection<IRole>(joueursG);
        BindingContext = this;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Close(new string("yes"));
    }
}