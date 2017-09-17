using ManaChan.Weather.Services.Weather;
using ManaChan.Weather.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

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
		/// Region管理
		/// </summary>
		[Dependency]
		public IRegionManager RegionManager { set; get; }

		/// <summary>
		/// 初期設定
		/// </summary>
		public void Initialize() {

			// Serviceをコンテナに登録
			this.Container.RegisterType<IWeatherService , WeatherService>( new ContainerControlledLifetimeManager() );
			
			// Regionの登録
			this.RegionManager.RegisterViewWithRegion( "WeatherDetailRegion" , typeof( DetailPopUpView ) );

		}

	}

}
