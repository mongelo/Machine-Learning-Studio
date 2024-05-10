using System.Windows.Input;

namespace Machine_Learning_Studio.StartPage;

public partial class MenuButton
{

    public static readonly BindableProperty ButtonTextProperty =
            BindableProperty.Create(nameof(ButtonText), typeof(string), typeof(MenuButton), default(string));

    //public static readonly BindableProperty ButtonTextProperty2 =
    //        BindableProperty.Create(nameof(ButtonText2), typeof(string), typeof(MenuButton), default(string));

    public static readonly BindableProperty TxtProperty = BindableProperty.Create(
        "ButtonText2",
        typeof(string),
        typeof(MenuButton),
        default(string));

    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(MenuButton), null);

    public string ButtonText
    {
        get { return (string)GetValue(ButtonTextProperty); }
        set { SetValue(ButtonTextProperty, value); }
    }

    public string Txt
    {
        get { return (string)GetValue(TxtProperty); }
        set { SetValue(TxtProperty, value); }
    }

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public MenuButton()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Command?.Execute(null);
    }

}