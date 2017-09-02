using ManaChan.MainWindow.VIews;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace ManaChan.MainWindow {

	/// <summary>
	/// 
	/// </summary>
	public class MainWindowModule : IModule {

		/// <summary>
		/// コンテナ
		/// </summary>
		[Dependency]
		public IUnityContainer Container { set; get; }

		/// <summary>
		/// Region管理
		/// </summary>
		[Dependency]
		public IRegionManager RegionManager { set; get; }

		/// <summary>
		/// 初期設定
		/// </summary>
		public void Initialize() {

			this.Container.RegisterType<MainWindowView>();

			this.RegionManager.RegisterViewWithRegion( "MainWindowRegion" , typeof( MainWindowView ) );



		}

	}

}
