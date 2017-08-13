using ManaChan.MainCharacter.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace ManaChan.MainCharacter {

	/// <summary>
	/// MainCharacterモジュールのエントリポイント
	/// </summary>
	public class MainCharacterModule : IModule {

		/// <summary>
		/// コンテナ
		/// </summary>
		[Dependency]
		public IUnityContainer Container { get; set; }

		/// <summary>
		/// Region管理
		/// </summary>
		[Dependency]
		public IRegionManager RegionManager { get; set; }

		/// <summary>
		/// 初期設定
		/// </summary>
		public void Initialize() {
			
			this.Container.RegisterType<object , MainCharacterView>( nameof( MainCharacterView ) );

			this.RegionManager.RequestNavigate( "MainRegion" , nameof( MainCharacterView ) );

		}

	}

}
