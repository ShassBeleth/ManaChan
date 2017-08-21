using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using System.Linq;

namespace ManaChan.Twitter {

	public class TwitterModule : IModule {

		/// <summary>
		/// コンテナ
		/// </summary>
		[Dependency]
		public IUnityContainer Container { get; set; }
		
		/// <summary>
		/// 初期設定
		/// </summary>
		public void Initialize() =>

			// Serviceをコンテナに登録
			// TODO できれば末尾でなくServices配下のクラスすべてを登録できるようにしたい
			this.Container.RegisterTypes(
				AllClasses.FromAssemblies( typeof( TwitterModule ).Assembly )
					.Where( x => x.Namespace.EndsWith( ".Services" ) ) ,
				getFromTypes: WithMappings.FromAllInterfaces ,
				getLifetimeManager: WithLifetime.ContainerControlled
			);

	}

}
