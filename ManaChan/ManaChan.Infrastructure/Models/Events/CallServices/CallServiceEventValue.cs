using ManaChan.Infrastructure.Enums;

namespace ManaChan.Infrastructure.Models.Events.CallServices {

	/// <summary>
	/// サービス呼び出しイベント
	/// </summary>
	public class CallServiceEventValue {

		/// <summary>
		/// サービス名
		/// </summary>
		public ServiceNames ServiceName { set; get; }

		/// <summary>
		/// 変更検知用GUID
		/// </summary>
		public string Guid { set; get; }

	}

}
