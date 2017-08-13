using Microsoft.Practices.Unity;
using Prism.Unity;
using System.Windows;
using ManaChan.Views;
using Prism.Modularity;
using ManaChan.MainCharacter;

namespace ManaChan {

	/// <summary>
	/// Boootstrapper
	/// </summary>
	public class Bootstrapper : UnityBootstrapper {

		/// <summary>
		/// コンテナからShellを作成
		/// </summary>
		/// <returns></returns>
		protected override DependencyObject CreateShell() => this.Container.Resolve<Shell>();

		/// <summary>
		/// Shellの表示
		/// </summary>
		protected override void InitializeShell() => ( (Window)this.Shell ).Show();

		/// <summary>
		/// モジュールの設定
		/// </summary>
		protected override void ConfigureModuleCatalog() {

			base.ConfigureModuleCatalog();

			ModuleCatalog catalog = (ModuleCatalog)this.ModuleCatalog;
			catalog.AddModule( typeof( MainCharacterModule ) );

		}

	}

}