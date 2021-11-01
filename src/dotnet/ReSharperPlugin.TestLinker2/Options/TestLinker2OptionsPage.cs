using System;
using System.Linq.Expressions;
using JetBrains.Application.Settings;
using JetBrains.Application.UI.Options;
using JetBrains.Application.UI.Options.OptionPages;
using JetBrains.Application.UI.Options.Options.ThemedIcons;
using JetBrains.Application.UI.Options.OptionsDialog;
using JetBrains.DataFlow;
using JetBrains.IDE.UI.Extensions;
using JetBrains.IDE.UI.Options;
using JetBrains.Lifetimes;

namespace ReSharperPlugin.TestLinker2.Options
{
	[OptionsPage(Id, PageTitle, typeof(OptionsThemedIcons.EnvironmentGeneral), ParentId = ToolsPage.PID)]
	public class TestLinker2OptionsPage : BeSimpleOptionsPage
	{
		private new const string Id = nameof(TestLinker2OptionsPage);
		private const string PageTitle = "Test Linker 2";

		private readonly Lifetime _lifetime;

		public TestLinker2OptionsPage(
			Lifetime lifetime,
			OptionsPageContext optionsPageContext,
			OptionsSettingsSmartContext optionsSettingsSmartContext)
			: base(lifetime, optionsPageContext, optionsSettingsSmartContext)
		{
			_lifetime = lifetime;

			AddHeader("Navigation (Test Linker 2)");

			IProperty<string> namingSuffixes = new Property<string>(lifetime, "TestLinker2OptionsPage::NamingSuffixes");
			namingSuffixes.SetValue(optionsSettingsSmartContext.StoreOptionsTransactionContext.GetValue((TestLinkerSettings key) => key.NamingSuffixes));
			namingSuffixes.Change.Advise(lifetime, a =>
			{
				if (!a.HasNew)
				{
					return;
				}

				optionsSettingsSmartContext.StoreOptionsTransactionContext.SetValue((TestLinkerSettings key) => key.NamingSuffixes, a.New);
			});

			IProperty<string> typeofAttributeName = new Property<string>(lifetime, "TestLinker2OptionsPage::TypeofAttributeName");
			typeofAttributeName.SetValue(optionsSettingsSmartContext.StoreOptionsTransactionContext.GetValue((TestLinkerSettings key) => key.TypeofAttributeName));
			typeofAttributeName.Change.Advise(lifetime, a =>
			{
				if (!a.HasNew)
				{
					return;
				}

				optionsSettingsSmartContext.StoreOptionsTransactionContext.SetValue((TestLinkerSettings key) => key.TypeofAttributeName, a.New);
			});

			AddTextBox((TestLinkerSettings k) => k.NamingSuffixes, "Name suffixes for tests (comma-separated):");
			AddTextBox((TestLinkerSettings x) => x.TypeofAttributeName, "Attribute name for typeof mentions:");
		}

		private void AddTextBox<TKeyClass>(Expression<Func<TKeyClass, string>> lambdaExpression, string description)
		{
			var property = new Property<string>(description);
			OptionsSettingsSmartContext.SetBinding(_lifetime, lambdaExpression, property);
			var control = property.GetBeTextBox(_lifetime);
			AddControl(control.WithDescription(description, _lifetime));
		}
	}
}