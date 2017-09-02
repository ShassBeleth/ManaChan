using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using ManaChan.Infrastructure.Models.Passer.Providers;
using ManaChan.Infrastructure.Models.Passer.Publishers;

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
		public void Initialize() {

			this.Container.RegisterType<IProviderOfPasser , ProviderOfPasser>();
			this.Container.RegisterType<IPublisherOfPasser , PublisherOfPasser>();
			
		}

	}

}
