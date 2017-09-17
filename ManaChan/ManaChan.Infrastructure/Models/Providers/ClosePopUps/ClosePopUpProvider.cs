using ManaChan.Infrastructure.Enums;
using ManaChan.Infrastructure.Models.Events.ClosePopUps;
using Prism.Events;
using Prism.Mvvm;

namespace ManaChan.Infrastructure.Models.Providers.ClosePopUps {

	/// <summary>
	/// ポップアップを閉じる通知購読者
	/// </summary>
	public class ClosePopUpProvider : BindableBase, IClosePopUpProvider {

		/// <summary>
		/// ポップアップ名
		/// </summary>
		private PopUpNames popUpName;

		/// <summary>
		/// ポップアップ名
		/// </summary>
		public PopUpNames PopUpName {
			private set => this.SetProperty( ref this.popUpName , value );
			get => this.popUpName;
		}

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
		public ClosePopUpProvider( IEventAggregator eventAggregator )
			=> eventAggregator.GetEvent<PubSubEvent<ClosePopUpEventValue>>()
			.Subscribe(
				x => {
					this.PopUpName = x.PopUpName;
					this.Guid = x.Guid;
				} ,
				ThreadOption.UIThread
			);

	}

}
