#if ANDROID
using BudgetBuddy.Platforms.Android;
#endif
//#if IOS
//using BudgetBuddy.Platforms.iOS;
//#endif

using Microsoft.Extensions.Logging;

namespace BudgetBuddy;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .ConfigureMauiHandlers(handlers => {
#if ANDROID
                handlers.AddHandler<CustomViewCell, CustomViewCellHandler>();
#endif

//#if IOS
//				handlers.AddHandler<CustomViewCell, CustomViewCellHandler>();
//#endif
			})
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
