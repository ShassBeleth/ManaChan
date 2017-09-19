using ManaChan.Bookmarks.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace ManaChan.Bookmarks {

	/// <summary>
	/// ブックマークモジュールのエントリポイント
	/// </summary>
	public class BookmarksModule : IModule {

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
		=> this.RegionManager.RegisterViewWithRegion( "BookmarksRegion" , typeof( BookmarksView ) );

	}

}
