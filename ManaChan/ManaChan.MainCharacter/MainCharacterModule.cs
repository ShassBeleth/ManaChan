using System.Linq;
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
			
			// Modelをコンテナに登録
			this.Container.RegisterTypes(
				AllClasses.FromAssemblies( typeof( MainCharacterModule ).Assembly )
					.Where( x => x.Namespace.Contains( ".Models" ) ) ,
				getFromTypes : WithMappings.FromAllInterfaces ,
				getLifetimeManager : WithLifetime.ContainerControlled 
			);

			// Viewをコンテナに登録
			this.Container.RegisterTypes(
				AllClasses.FromAssemblies( typeof( MainCharacterModule ).Assembly )
					.Where( x => x.Namespace.Contains( ".Views" ) ) ,
				getFromTypes: _ => new[] { typeof( object ) } ,
				getName: WithName.TypeName 
			);

			// Region登録
			this.RegionManager.RegisterViewWithRegion( "MainCharacterRegion" , typeof( MainCharacterView ) );
			
		}

	}

}
