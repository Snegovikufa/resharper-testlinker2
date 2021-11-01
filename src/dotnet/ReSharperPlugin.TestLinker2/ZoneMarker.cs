using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.TextControl;

namespace ReSharperPlugin.TestLinker2
{
	[ZoneMarker]
	public class ZoneMarker
		: JetBrains.ReSharper.UnitTestFramework.ZoneMarker,
			IRequire<ILanguageCSharpZone>,
			IRequire<DaemonEngineZone>,
			IRequire<ITextControlsZone>
	{
	}
}