namespace ManaChan.Infrastructure.Models.Events.CallWeatherServiceEvent {

	/// <summary>
	/// 天気情報サービス呼び出しイベント
	/// </summary>
	public class CallWeatherServiceEventValue {

		/// <summary>
		/// 変更検知用GUID
		/// </summary>
		public string Guid { set; get; }

	}

}
