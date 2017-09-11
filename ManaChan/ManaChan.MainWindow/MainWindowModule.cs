using ManaChan.MainWindow.Models.Providers.ClosePopUp;
using ManaChan.MainWindow.Models.Providers.InputPinCode;
using ManaChan.MainWindow.Models.Publishers.CallWeatherService;
using ManaChan.MainWindow.Models.Publishers.ChangeCharacterEmotionType;
using ManaChan.MainWindow.Models.Publishers.ChangeCharacterType;
using ManaChan.MainWindow.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace ManaChan.MainWindow {

	/// <summary>
	/// 
	/// </summary>
	public class MainWindowModule : IModule {

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

			this.Container.RegisterType<IInputPinCodeProvider , InputPinCodeProvider>( new ContainerControlledLifetimeManager() );
			this.Container.RegisterType<IChangeCharacterTypePublisher , ChangeCharacterTypePublisher>( new ContainerControlledLifetimeManager() );
			this.Container.RegisterType<IChangeCharacterEmotionTypePublisher , ChangeCharacterEmotionTypePublisher>( new ContainerControlledLifetimeManager() );
			this.Container.RegisterType<ICallWeatherServicePublisher , CallWeatherServicePublisher>( new ContainerControlledLifetimeManager() );
			this.Container.RegisterType<ICloseWeatherPopUpProvider , CloseWeatherPopUpProvider>( new ContainerControlledLifetimeManager() );
			this.Container.RegisterType<MainWindowView>();

			this.RegionManager.RegisterViewWithRegion( "MainWindowRegion" , typeof( MainWindowView ) );
			
		}

	}

}
