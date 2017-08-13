using System.Windows;

namespace ManaChan {

	/// <summary>
	/// App.xaml の相互作用ロジック
	/// </summary>
	public partial class App : Application {

		/// <summary>
		/// Bootstrapperの起動
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Application_Startup( object sender , StartupEventArgs e ) => new Bootstrapper().Run();

	}

}