namespace ManaChan.Infrastructure.Models.Events.ClosePopUpEvent {

	/// <summary>
	/// クリップボードポップアップを閉じることを通知するイベント
	/// </summary>
	public class CloseClipBoardPopUpEventValue {

		/// <summary>
		/// ポップアップ変更検知用GUID
		/// </summary>
		public string Guid { set; get; }

	}

}
