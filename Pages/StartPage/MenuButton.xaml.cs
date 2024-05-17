using System.Windows.Input;

namespace Machine_Learning_Studio.StartPage;

public partial class MenuButton
{
    public static readonly BindableProperty ButtonTextProperty = BindableProperty.Create(nameof(ButtonText), typeof(string), typeof(MenuButton), default(string));
    public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(MenuButton), null);
    public static readonly BindableProperty DarkerButtonColorProperty = BindableProperty.Create(nameof(DarkerButtonColor), typeof(Color), typeof(MenuButton), Color.FromRgb(13, 71, 161));
    public static readonly BindableProperty LighterButtonColorProperty = BindableProperty.Create(nameof(LighterButtonColor), typeof(Color), typeof(MenuButton), Color.FromRgb(21, 101, 192));

    public string ButtonText{get { return (string)GetValue(ButtonTextProperty); }set { SetValue(ButtonTextProperty, value); }}
    public ICommand Command{get => (ICommand)GetValue(CommandProperty);set => SetValue(CommandProperty, value);}
    public Color DarkerButtonColor{get => (Color)GetValue(DarkerButtonColorProperty);set => SetValue(DarkerButtonColorProperty, value);}
    public Color LighterButtonColor{get => (Color)GetValue(LighterButtonColorProperty);set => SetValue(LighterButtonColorProperty, value);}

    private bool _highlighted;
    private Color _darkBlueColor = Color.FromRgb(13, 71, 161);
    private Color _mediumBlueColor = Color.FromRgb(21, 101, 192);
    private Color _blueColor = Color.FromRgb(17, 46, 79);
    private Color _lightBlueColor = Color.FromRgb(91, 147, 210);

    public MenuButton()
    {
        InitializeComponent();
        Mediator.MessageReceived += OnMessageReceived;
        BindingContext = this;
    }

    private void OnMessageReceived(object? sender, string message)
    {
        if (message == "menu_button_highlighted")
        {
            _highlighted = false;
            UpdateButtonColors();
        }
    }

	private void UpdateButtonColors()
    {
        DarkerButtonColor = _highlighted ? _blueColor : _darkBlueColor;
        LighterButtonColor = _highlighted ? _lightBlueColor : _mediumBlueColor;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Mediator.SendMessage("menu_button_highlighted");
        _highlighted = true;
        UpdateButtonColors();
        Command?.Execute(null);
    }

}