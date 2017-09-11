namespace ManaChan.Weather.Models.Publishers.ClosePopUp {

	/// <summary>
	/// 天気情報ポップアップを閉じるための発行者
	/// </summary>
	public interface ICloseWeatherPopUpPublisher {
		
		/// <summary>
		/// 発行
		/// </summary>
		void Publish();
		
	}

}
