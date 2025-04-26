using Milo.Core.Encoding;

namespace Milo.Apps.Encoding.MAUI.Views;

public partial class KeyViewer : IMiloSection
{
    public static readonly BindableProperty EncoderKeyProperty = BindableProperty.Create(nameof(EncoderKey), typeof(IEncoderKey), typeof(KeyViewer), propertyChanged:OnEncoderKeyChanged);

    public IEncoderKey EncoderKey
    {
        get => (IEncoderKey)GetValue(EncoderKeyProperty);
        set => SetValue(EncoderKeyProperty, value);
    }

    public object Header => "Key Viewer";

    public KeyViewer()
	{
		InitializeComponent();
	}

    private static void OnEncoderKeyChanged(BindableObject sender, object oldValue, object newValue)
    {
        if (sender is KeyViewer viewer)
        {

        }
    }
}