
namespace ManaChan.MainWindow.Models.Publishers.CallWeatherService {

	/// <summary>
	/// 天気情報サービス呼び出し発行者
	/// </summary>
	public interface ICallWeatherServicePublisher {

		/// <summary>
		/// 発行
		/// </summary>
		void Publish();

	}

}
