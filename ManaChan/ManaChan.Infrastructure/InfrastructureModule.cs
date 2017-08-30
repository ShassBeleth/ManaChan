using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using System.Linq;

namespace ManaChan.Infrastructure {

	/// <summary>
	/// Infrastructureモジュールのエントリポイント
	/// </summary>
	public class InfrastructureModule : IModule {

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
		public void Initialize() =>

			// Modelをコンテナに登録
			this.Container.RegisterTypes(
				AllClasses.FromAssemblies( typeof( InfrastructureModule ).Assembly )
					.Where( x => x.Namespace.Contains( ".Models" ) ) ,
				getFromTypes: WithMappings.FromAllInterfaces ,
				getLifetimeManager: WithLifetime.ContainerControlled
			);

	}

}
