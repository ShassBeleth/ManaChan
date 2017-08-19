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
		protected override void InitializeShell() {

			base.InitializeShell();

			Application.Current.MainWindow = (Window)this.Shell;
			Application.Current.MainWindow.Show();

		}

		/// <summary>
		/// モジュールの設定
		/// </summary>
		protected override void ConfigureModuleCatalog() {

			base.ConfigureModuleCatalog();

			// TODO 自身のModelsもコンテナに登録したい

			ModuleCatalog catalog = (ModuleCatalog)this.ModuleCatalog;
			catalog.AddModule( typeof( MainCharacterModule ) );
			
		}

	}

}