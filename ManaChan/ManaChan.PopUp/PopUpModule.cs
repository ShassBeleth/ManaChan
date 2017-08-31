using ManaChan.PopUp.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			
			// Viewをコンテナに登録
			this.Container.RegisterTypes(
				AllClasses.FromAssemblies( typeof( PopUpModule ).Assembly )
					.Where( x => x.Namespace.Contains( ".Views" ) ) ,
				getFromTypes: _ => new[] { typeof( object ) } ,
				getName: WithName.TypeName
			);

			// Region登録
			this.RegionManager.RegisterViewWithRegion( "InputPinCodePopUpRegion" , typeof( InputPinCodePopUpView ) );

		}

	}
}

