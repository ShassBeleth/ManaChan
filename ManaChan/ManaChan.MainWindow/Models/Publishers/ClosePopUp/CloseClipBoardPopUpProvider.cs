using ManaChan.Infrastructure.Models.Events.ClosePopUpEvent;
using Prism.Events;
using Prism.Mvvm;

namespace ManaChan.MainWindow.Models.Publishers.ClosePopUp {

	/// <summary>
	/// クリップボードポップアップを閉じるための購読者
	/// </summary>
	public class CloseClipBoardPopUpProvider : BindableBase , ICloseClipBoardPopUpProvider {

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
		public CloseClipBoardPopUpProvider( IEventAggregator eventAggregator )
			=> eventAggregator.GetEvent<PubSubEvent<CloseClipBoardPopUpEventValue>>()
			.Subscribe(
				x => this.Guid = x.Guid ,
				ThreadOption.UIThread
			);

	}
}
