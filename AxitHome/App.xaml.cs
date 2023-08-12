using AxitHome.Views.Controls;
using Microsoft.Maui.Platform;

namespace AxitHome;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		SetHandlers();
		MainPage = new AppShell();
	}

    private void SetHandlers()
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, entry) =>
        {
            if (entry is BorderlessEntry)
            {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif __IOS__
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
                handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Thin;
#endif
            }
        });
    }
}
