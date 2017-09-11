using System.ComponentModel;

namespace ManaChan.MainWindow.Models.Providers.ClosePopUp {

	/// <summary>
	/// 天気情報ポップアップを閉じるための購読者
	/// </summary>
	public interface ICloseWeatherPopUpProvider : INotifyPropertyChanged {

		/// <summary>
		/// 変更検知用GUID
		/// </summary>
		string Guid { get; }

	}

}