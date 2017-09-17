using ManaChan.ClipBoardManager.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace ManaChan.ClipBoardManager {

	/// <summary>
	/// ClipBoardモジュールのエントリポイント
	/// </summary>
	public class ClipBoardManagerModule : IModule {

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
		public void Initialize()
		=> this.RegionManager.RegisterViewWithRegion( "ClipBoardManagerRegion" , typeof( ClipBoardManagerView ) );

	}

}
