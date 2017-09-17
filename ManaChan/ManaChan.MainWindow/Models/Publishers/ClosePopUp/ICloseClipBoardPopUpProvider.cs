using System.ComponentModel;

namespace ManaChan.MainWindow.Models.Publishers.ClosePopUp {

	/// <summary>
	/// クリップボードポップアップを閉じるための購読者
	/// </summary>
	public interface ICloseClipBoardPopUpProvider : INotifyPropertyChanged {

		/// <summary>
		/// 変更検知用GUID
		/// </summary>
		string Guid { get; }

	}

}