using Microsoft.Practices.Unity;
using Prism.Unity;
using System.Windows;
using ManaChan.Views;

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

	}

}