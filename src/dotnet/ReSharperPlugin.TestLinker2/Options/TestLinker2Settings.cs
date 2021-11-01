using JetBrains.Application.Settings;
using JetBrains.Application.Settings.WellKnownRootKeys;

namespace ReSharperPlugin.TestLinker2.Options
{
	[SettingsKey(typeof(EnvironmentSettings), "Settings for Test Linker 2")]
	public class TestLinkerSettings
	{
		[SettingsEntry("Test,Spec,Tests,Specs", "Naming Suffixes")]
		public string NamingSuffixes;

		[SettingsEntry("SubjectAttribute", "Typeof Attribute")]
		public string TypeofAttributeName;
	}
}
