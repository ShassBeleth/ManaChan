using ManaChan.MainCharacter.Models.Providers.ChangeCharacterEmotionType;
using ManaChan.MainCharacter.Models.Providers.ChangeCharacterType;
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

			this.Container.RegisterType<MainCharacterView>();
			this.Container.RegisterType<IChangeCharacterTypeProvider , ChangeCharacterTypeProvider>( new ContainerControlledLifetimeManager() );
			this.Container.RegisterType<IChangeCharacterEmotionTypeProvider , ChangeCharacterEmotionTypeProvider>( new ContainerControlledLifetimeManager() );

			this.RegionManager.RegisterViewWithRegion( "MainCharacterRegion" , typeof( MainCharacterView ) );
			
		}

	}

}
