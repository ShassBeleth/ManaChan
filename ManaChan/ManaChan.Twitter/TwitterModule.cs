using Microsoft.Practices.Unity;
using Prism.Modularity;
using System.Linq;

namespace ManaChan.Twitter {

	/// <summary>
	/// Twitterモジュールのエントリポイント
	/// </summary>
	public class TwitterModule : IModule {

		/// <summary>
		/// コンテナ
		/// </summary>
		[Dependency]
		public IUnityContainer Container { set; get; }

		/// <summary>
		/// 初期設定
		/// </summary>
		public void Initialize() =>

			// Serviceをコンテナに登録
			this.Container.RegisterTypes(
				AllClasses.FromAssemblies( typeof( TwitterModule ).Assembly )
					.Where( x => x.Namespace.Contains( ".Services" ) ) ,
				getFromTypes: WithMappings.FromAllInterfaces ,
				getLifetimeManager: WithLifetime.ContainerControlled
			);

	}

}
