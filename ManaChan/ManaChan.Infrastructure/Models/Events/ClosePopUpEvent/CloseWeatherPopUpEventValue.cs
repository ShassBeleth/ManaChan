namespace ManaChan.Infrastructure.Models.Events.ClosePopUpEvent {

	/// <summary>
	/// 天気情報ポップアップを閉じることを通知するイベント
	/// </summary>
	public class CloseWeatherPopUpEventValue {
		
		/// <summary>
		/// ポップアップ変更検知用GUID
		/// </summary>
		public string Guid { set; get; }
		
	}

}
