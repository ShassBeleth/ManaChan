using System.ComponentModel;
using ManaChan.Infrastructure.Enums;

namespace ManaChan.Infrastructure.Models.Providers.ClosePopUps {

	/// <summary>
	/// ポップアップを閉じる通知購読者
	/// </summary>
	public interface IClosePopUpProvider : INotifyPropertyChanged {

		/// <summary>
		/// ポップアップ名名
		/// </summary>
		PopUpNames PopUpName { get; }
		
		/// <summary>
		/// 変更検知用GUID
		/// </summary>
		string Guid { get; }
	}

}
