using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Avalonia.VisualTree;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace TestColoredRectangle;

public class UnitTests {

	[Fact]
	public async void TestMainWindowHeightAndWidth () {
		var window = AvaloniaApp.GetMainWindow();

		await Task.Delay(100);

		var expectedWidth = 300;
		var expectedHeight = 300;

		Assert.Equal(expectedHeight, window?.Height);
		Assert.Equal(expectedWidth, window?.Width);
	}

	[Fact]
	public async void TestColorChanging () {
		var app = AvaloniaApp.GetApp();
		var window = AvaloniaApp.GetMainWindow();

		await Task.Delay(100);

		var buttons = window.GetVisualDescendants().OfType<Button>();

		foreach (var button in buttons) {
			var expectedColorName = button.Content as string;

			button.Command.Execute(button.CommandParameter);

			var rectangle = button.GetVisualDescendants().OfType<Rectangle>().First();

			await Task.Delay(50);

			var rectColor = (rectangle.Fill as SolidColorBrush)?.Color;

			Assert.StrictEqual(Color.Parse(expectedColorName), rectColor);
		}
	}

}
