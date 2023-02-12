using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using Avalonia;
using Avalonia.ReactiveUI;
using Avalonia.Headless;
using ColoredRectangle.Views;
using ColoredRectangle;
using System;

namespace TestColoredRectangle;

public static class AvaloniaApp {
	// DI registrations
	/* public static void RegisterDependencies() =>
				Bootstrapper.Register(AvaloniaLocator.CurrentMutable, AvaloniaLocator.Current);*/

	// stop app and cleanup
	public static void Stop () {
		var app = GetApp();
		if (app is IDisposable disposable) {
			Dispatcher.UIThread.Post(disposable.Dispose);
		}

		Dispatcher.UIThread.Post(() => app?.Shutdown());
	}

	public static MainWindow? GetMainWindow () => GetApp()?.MainWindow as MainWindow;

	public static IClassicDesktopStyleApplicationLifetime? GetApp () =>
			Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime;

	public static AppBuilder BuildAvaloniaApp () =>
			AppBuilder
					.Configure<App>()
					.UsePlatformDetect()
					.UseReactiveUI()
					.UseHeadless(); // Need a package Avalonia.Headless 10.18 from NuGet for this method
}
