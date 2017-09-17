using ManaChan.Infrastructure.Enums;

namespace ManaChan.Infrastructure.Models.Events.ClosePopUps {

	/// <summary>
	/// ポップアップを閉じることを通知するイベント
	/// </summary>
	public class ClosePopUpEventValue {

		/// <summary>
		/// ポップアップ名
		/// </summary>
		public PopUpNames PopUpName { set; get; }

		/// <summary>
		/// 変更検知用GUID
		/// </summary>
		public string Guid { set; get; }
		
	}

}
