using ManaChan.Infrastructure.Models.Events.ClosePopUpEvent;
using Prism.Events;
using Prism.Mvvm;

namespace ManaChan.MainWindow.Models.Providers.ClosePopUp {

	/// <summary>
	/// 天気情報ポップアップを閉じるための購読者
	/// </summary>
	public class CloseWeatherPopUpProvider : BindableBase , ICloseWeatherPopUpProvider {

		/// <summary>
		/// 変更検知用GUID
		/// </summary>
		private string guid;

		/// <summary>
		/// 変更検知用GUID
		/// </summary>
		public string Guid {
			private set => this.SetProperty( ref this.guid , value );
			get => this.guid;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="eventAggregator">イベントアグリゲータ</param>
		public CloseWeatherPopUpProvider( IEventAggregator eventAggregator )
			=> eventAggregator.GetEvent<PubSubEvent<CloseWeatherPopUpEventValue>>()
			.Subscribe(
				x => this.Guid = x.Guid ,
				ThreadOption.UIThread
			);

	}

}
