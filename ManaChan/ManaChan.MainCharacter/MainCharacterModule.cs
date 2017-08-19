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
			
			// Modelをコンテナに登録
			// TODO できれば末尾でなくModels配下のクラスすべてを登録できるようにしたい
			this.Container.RegisterTypes(
				AllClasses.FromAssemblies( typeof( MainCharacterModule ).Assembly )
					.Where( x => x.Namespace.EndsWith( ".Models" ) ) ,
				getFromTypes : WithMappings.FromAllInterfaces ,
				getLifetimeManager : WithLifetime.ContainerControlled 
			);

			// Viewをコンテナに登録
			// TODO できれば末尾でなくViews配下のクラスすべてを登録できるようにしたい
			this.Container.RegisterTypes(
				AllClasses.FromAssemblies( typeof( MainCharacterModule ).Assembly )
					.Where( x => x.Namespace.EndsWith( ".Views" ) ) ,
				getFromTypes: _ => new[] { typeof( object ) } ,
				getName: WithName.TypeName );

			// Region登録
			this.RegionManager.RegisterViewWithRegion( "MainRegion" , typeof( MainCharacterView ) );
			
		}

	}

}
