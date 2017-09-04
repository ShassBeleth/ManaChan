using ManaChan.Weather.Services;
using Microsoft.Practices.Unity;
using Prism.Modularity;

namespace ManaChan.Weather {

	/// <summary>
	/// Weatherモジュールのエントリポイント
	/// </summary>
	public class WeatherModule : IModule {

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
			this.Container.RegisterType<IWeatherService , WeatherService>( new ContainerControlledLifetimeManager() );

	}

}
