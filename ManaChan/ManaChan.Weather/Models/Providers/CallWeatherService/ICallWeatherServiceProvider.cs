using System.ComponentModel;

namespace ManaChan.Weather.Models.Providers.CallWeatherService {

	/// <summary>
	/// 天気情報サービス呼び出し購読者
	/// </summary>
	public interface ICallWeatherServiceProvider : INotifyPropertyChanged {

		/// <summary>
		/// 変更検知用GUID
		/// </summary>
		string Guid { get; }

	}

}
