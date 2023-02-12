using NUnit.Framework;
using Avalonia;
using ColoredRectangle;
using Avalonia.ReactiveUI;
using Avalonia.Controls.ApplicationLifetimes;
using ColoredRectangle.Views;
using System.Threading.Tasks;

namespace TestColoredRectangle;

public class Tests {
	private IClassicDesktopStyleApplicationLifetime? _app;
	private MainWindow? _mainWindow;

	[SetUp]
	public void Setup () {
		AppBuilder
				.Configure<App>()
				.UsePlatformDetect()
				.UseReactiveUI();

		_app = Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime;
		_mainWindow = (MainWindow?) (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;
	}

	[Test]
	public void Test1 () {
		var expectedWidth = 300;
		var expectedHeight = 300;

		Assert.That(_mainWindow?.Width, Is.EqualTo(expectedWidth));
		Assert.That(_mainWindow?.Height, Is.EqualTo(expectedHeight));
	}
}