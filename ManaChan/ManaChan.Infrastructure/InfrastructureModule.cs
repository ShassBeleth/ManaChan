using ManaChan.Infrastructure.Models.Providers.CallServices;
using ManaChan.Infrastructure.Models.Providers.ClosePopUps;
using ManaChan.Infrastructure.Models.Publishers.CallServices;
using ManaChan.Infrastructure.Models.Publishers.ClosePopUps;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

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

			this.Container.RegisterType<ICallServicePublisher , CallServicePublisher>( new ContainerControlledLifetimeManager() );
			this.Container.RegisterType<ICallServiceProvider , CallServiceProvider>( new ContainerControlledLifetimeManager() );

			this.Container.RegisterType<IClosePopUpPublisher , ClosePopUpPublisher>( new ContainerControlledLifetimeManager() );
			this.Container.RegisterType<IClosePopUpProvider , ClosePopUpProvider>( new ContainerControlledLifetimeManager() );

		}

	}

}
