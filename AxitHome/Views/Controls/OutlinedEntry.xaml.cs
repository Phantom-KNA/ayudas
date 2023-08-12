
using Microsoft.Maui.Platform;
using System.ComponentModel;
using AxitHome.Helpers;

namespace AxitHome.Views.Controls;

public partial class OutlinedEntry : Grid
{
    private bool showingPass = false;
    public OutlinedEntry()
    {
        InitializeComponent();
        ClearTapped(null, new TappedEventArgs(1));
        var tgrClear = new TapGestureRecognizer();
        tgrClear.Tapped += ClearTapped;
        //AnimationClear.GestureRecognizers.Add(tgrClear);
        ClearButton.GestureRecognizers.Add(tgrClear);

        this.PropertyChanged += OnPropertyChanged;

        ShowPassTapped(null, new TappedEventArgs(1));
        var tgrShowPass = new TapGestureRecognizer();
        tgrShowPass.Tapped += ShowPassTapped;
        //AnimationShowPass.GestureRecognizers.Add(tgrShowPass);
        ShowPassButton.GestureRecognizers.Add(tgrShowPass);

        MainEntry.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == "IsFocused")
            {
                if (MainEntry.IsFocused)
                    MainBorder.Stroke = FocusedBorderColor;
                else
                    MainBorder.Stroke = BorderColor;
            }
        };

        this.Unfocused += OutlinedEntry_Unfocused;

        MainEntry.TextChanged += (sender, args) =>
        {
            if (TextChanged != null)
            {
                TextChanged.Invoke(this, args);
            }
        };
    }
    public event EventHandler<TextChangedEventArgs> TextChanged;

    public bool SetFocus()
    {
        return MainEntry.Focus();
    }

    public void RemoveFocus()
    {
        MainEntry.Unfocus();
    }

    public async void HideKeyboard()
    {
        //Validacion si el teclado esta visible
        //if (KeyboardExtensions.IsSoftKeyboardShowing(MainEntry))
        //{
        //    await KeyboardExtensions.HideKeyboardAsync(MainEntry, default);
        //}
    }
    private void OutlinedEntry_Unfocused(object sender, FocusEventArgs e)
    {
        //if (this.UnfocusedCommand == null) return;
        //this.UnfocusedCommand.Execute(null);
    }

    private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(MaxLength))
        {
            MainEntry.MaxLength = MaxLength;
        }
    }

    private async void ShowPassTapped(object sender, TappedEventArgs e)
    {
        //this.AnimationShowPass.Opacity = 0;
        //await this.AnimationShowPass.FadeTo(0.1, 150);
        if ((e.Parameter?.ToString() ?? "") != "1")
        {
            if (showingPass)
            {
                MainEntry.IsPassword = true;
                showingPass = false;
                ShowPassButton.Text = CustomIconsFont.icon_eyeOpen;
            }
            else
            {
                MainEntry.IsPassword = false;
                showingPass = true;
                ShowPassButton.Text = CustomIconsFont.icon_eyeOpen;
            }
        }

        //await this.AnimationShowPass.FadeTo(0, 150);
    }

    private async void ClearTapped(object sender, TappedEventArgs e)
    {
        //this.AnimationClear.Opacity = 0;
        //await this.AnimationClear.FadeTo(0.1, 150);
        if ((e.Parameter?.ToString() ?? "") != "1")
            Text = string.Empty;
        //await this.AnimationClear.FadeTo(0, 150);
    }

    public static BindableProperty IsPasswordProperty = BindableProperty.Create(
        nameof(IsPassword),
        typeof(bool),
        typeof(OutlinedEntry),
        defaultValue: false,
        defaultBindingMode: BindingMode.OneWay);

    public bool IsPassword
    {
        get => (bool)GetValue(IsPasswordProperty);
        set => SetValue(IsPasswordProperty, value);
    }

    public static BindableProperty PlaceholderProperty = BindableProperty.Create(
        nameof(Placeholder),
        typeof(string),
        typeof(OutlinedEntry),
        defaultValue: "",
        defaultBindingMode: BindingMode.OneWay);

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public static BindableProperty BorderColorProperty = BindableProperty.Create(
        nameof(BorderColor),
        typeof(Color),
        typeof(OutlinedEntry),
        defaultValue: Color.FromRgb(0, 0, 0),
        defaultBindingMode: BindingMode.OneWay);

    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    public static BindableProperty CornerRadiusProperty = BindableProperty.Create(
        nameof(CornerRadius),
        typeof(CornerRadius),
        typeof(OutlinedEntry),
        defaultValue: new CornerRadius(0, 0, 0, 0),
        defaultBindingMode: BindingMode.OneWay);

    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public static BindableProperty FontSizeProperty = BindableProperty.Create(
        nameof(FontSize),
        typeof(double),
        typeof(OutlinedEntry),
        defaultValue: 14d,
        defaultBindingMode: BindingMode.OneWay);

    public double FontSize
    {
        get => (double)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    public static BindableProperty IsIconVisibleProperty = BindableProperty.Create(
        nameof(IsIconVisible),
        typeof(bool),
        typeof(OutlinedEntry),
        defaultValue: false,
        defaultBindingMode: BindingMode.OneWay);

    public bool IsIconVisible
    {
        get => (bool)GetValue(IsIconVisibleProperty);
        set => SetValue(IsIconVisibleProperty, value);
    }

    public static BindableProperty IconFontFamilyProperty = BindableProperty.Create(
        nameof(IconFontFamily),
        typeof(string),
        typeof(OutlinedEntry),
        defaultValue: "",
        defaultBindingMode: BindingMode.OneWay);

    public string IconFontFamily
    {
        get => (string)GetValue(IconFontFamilyProperty);
        set => SetValue(IconFontFamilyProperty, value);
    }

    public static BindableProperty IconProperty = BindableProperty.Create(
        nameof(Icon),
        typeof(string),
        typeof(OutlinedEntry),
        defaultValue: "",
        defaultBindingMode: BindingMode.OneWay);

    public string Icon
    {
        get => (String)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public static BindableProperty IconSizeProperty = BindableProperty.Create(
        nameof(IconSize),
        typeof(double),
        typeof(OutlinedEntry),
        defaultValue: 30d,
        defaultBindingMode: BindingMode.OneWay);

    public double IconSize
    {
        get => (double)GetValue(IconSizeProperty);
        set => SetValue(IconSizeProperty, value);
    }

    public static BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text),
        typeof(string),
        typeof(OutlinedEntry),
        defaultValue: "",
        defaultBindingMode: BindingMode.TwoWay);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static BindableProperty HasClearButtonProperty = BindableProperty.Create(
        nameof(HasClearButton),
        typeof(bool),
        typeof(OutlinedEntry),
        defaultValue: false,
        defaultBindingMode: BindingMode.OneWay);

    public bool HasClearButton
    {
        get => (bool)GetValue(HasClearButtonProperty);
        set => SetValue(HasClearButtonProperty, value);
    }

    public static BindableProperty ShowPasswordButtonVisibleProperty = BindableProperty.Create(
        nameof(ShowPasswordButtonVisible),
        typeof(bool),
        typeof(OutlinedEntry),
        defaultValue: false,
        defaultBindingMode: BindingMode.OneWay);

    public bool ShowPasswordButtonVisible
    {
        get => (bool)GetValue(ShowPasswordButtonVisibleProperty);
        set => SetValue(ShowPasswordButtonVisibleProperty, value);
    }

    public static BindableProperty TextFontFamilyProperty = BindableProperty.Create(
        nameof(TextFontFamily),
        typeof(string),
        typeof(OutlinedEntry),
        defaultValue: "",
        defaultBindingMode: BindingMode.OneWay);

    public string TextFontFamily
    {
        get => (string)GetValue(TextFontFamilyProperty);
        set => SetValue(TextFontFamilyProperty, value);
    }

    public static BindableProperty TextColorProperty = BindableProperty.Create(
        nameof(TextColor),
        typeof(Color),
        typeof(OutlinedEntry),
        defaultValue: Color.FromRgb(0, 0, 0),
        defaultBindingMode: BindingMode.OneWay);

    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public static BindableProperty IconColorProperty = BindableProperty.Create(
        nameof(IconColor),
        typeof(Color),
        typeof(OutlinedEntry),
        defaultValue: Color.FromRgb(0, 0, 0),
        defaultBindingMode: BindingMode.OneWay);

    public Color IconColor
    {
        get => (Color)GetValue(IconColorProperty);
        set => SetValue(IconColorProperty, value);
    }

    public static BindableProperty TextCharacterSpacingProperty = BindableProperty.Create(
        nameof(TextCharacterSpacing),
        typeof(double),
        typeof(OutlinedEntry),
        defaultValue: 0d,
        defaultBindingMode: BindingMode.OneWay);

    public double TextCharacterSpacing
    {
        get => (double)GetValue(TextCharacterSpacingProperty);
        set { SetValue(TextCharacterSpacingProperty, value); }
    }

    public static BindableProperty FocusedBorderColorProperty = BindableProperty.Create(
        nameof(FocusedBorderColor),
        typeof(Color),
        typeof(OutlinedEntry),
        defaultValue: Color.FromRgb(0, 0, 0),
        defaultBindingMode: BindingMode.OneWay);

    public Color FocusedBorderColor
    {
        get => (Color)GetValue(FocusedBorderColorProperty);
        set => SetValue(FocusedBorderColorProperty, value);
    }

    public static BindableProperty PlaceholderColorProperty = BindableProperty.Create(
        nameof(PlaceholderColor),
        typeof(Color),
        typeof(OutlinedEntry),
        defaultValue: Color.FromRgb(0, 0, 0),
        defaultBindingMode: BindingMode.OneWay);

    public Color PlaceholderColor
    {
        get => (Color)GetValue(PlaceholderColorProperty);
        set => SetValue(PlaceholderColorProperty, value);
    }

    public static BindableProperty KeyboardProperty = BindableProperty.Create(
        nameof(Keyboard),
        typeof(Keyboard),
        typeof(OutlinedEntry),
        defaultValue: Keyboard.Text,
        defaultBindingMode: BindingMode.OneWay);

    public Keyboard Keyboard
    {
        get => (Keyboard)GetValue(KeyboardProperty);
        set => SetValue(KeyboardProperty, value);
    }

    public static BindableProperty TextHorizaontalTextAligmentProperty = BindableProperty.Create(
        nameof(TextHorizaontalTextAligment),
        typeof(TextAlignment),
        typeof(OutlinedEntry),
        defaultValue: TextAlignment.Start,
        defaultBindingMode: BindingMode.OneWay);

    public TextAlignment TextHorizaontalTextAligment
    {
        get => (TextAlignment)GetValue(TextHorizaontalTextAligmentProperty);
        set => SetValue(TextHorizaontalTextAligmentProperty, value);
    }

    public static BindableProperty TextMarginProperty = BindableProperty.Create(
        nameof(TextMargin),
        typeof(Thickness),
        typeof(OutlinedEntry),
        defaultValue: new Thickness(15, 8, 5, 8),
        defaultBindingMode: BindingMode.OneWay);

    public Thickness TextMargin
    {
        get => (Thickness)GetValue(TextMarginProperty);
        set => SetValue(TextMarginProperty, value);
    }

    public static BindableProperty CursorPositionProperty = BindableProperty.Create(
        nameof(CursorPosition),
        typeof(int),
        typeof(OutlinedEntry),
        defaultValue: 0,
        defaultBindingMode: BindingMode.TwoWay);

    public int CursorPosition
    {
        get => (int)GetValue(CursorPositionProperty);
        set => SetValue(CursorPositionProperty, value);
    }

    public static BindableProperty ReadOnlyProperty = BindableProperty.Create(
        nameof(ReadOnly),
        typeof(bool),
        typeof(OutlinedEntry),
        defaultValue: false,
        defaultBindingMode: BindingMode.TwoWay);

    public bool ReadOnly
    {
        get => (bool)GetValue(ReadOnlyProperty);
        set { SetValue(ReadOnlyProperty, value); }
    }

    public static BindableProperty MaxLengthProperty = BindableProperty.Create(
        nameof(MaxLength),
        typeof(int),
        typeof(OutlinedEntry),
        defaultValue: int.MaxValue,
        defaultBindingMode: BindingMode.OneWay);

    public int MaxLength
    {
        get => (int)GetValue(MaxLengthProperty);
        set => SetValue(MaxLengthProperty, value);
    }
}