namespace Machine_Learning_Studio.StartPage;

public partial class MenuButton : ContentView
{
    public static readonly BindableProperty ButtonTextProperty =
            BindableProperty.Create(nameof(ButtonText), typeof(string), typeof(MenuButton), default(string));

    public string ButtonText
    {
        get { return (string)GetValue(ButtonTextProperty); }
        set { SetValue(ButtonTextProperty, value); }
    }

    public MenuButton()
    {
        InitializeComponent();
        BindingContext = this;
    }
}