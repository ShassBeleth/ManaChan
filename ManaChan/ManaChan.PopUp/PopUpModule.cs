using ManaChan.PopUp.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace ManaChan.PopUp {

	/// <summary>
	/// PopUpモジュールのエントリポイント
	/// </summary>
	public class PopUpModule : IModule {

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
			
			this.Container.RegisterType<InputPinCodePopUpView>();

			this.RegionManager.RegisterViewWithRegion( "InputPinCodePopUpRegion" , typeof( InputPinCodePopUpView ) );

		}

	}
}

