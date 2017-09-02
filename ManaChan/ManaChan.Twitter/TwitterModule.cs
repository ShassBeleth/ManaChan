using Microsoft.Practices.Unity;
using Prism.Modularity;
using ManaChan.Twitter.Services;

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
			this.Container.RegisterType<IAuthenticatedService , AuthenticatedService>();

	}

}
