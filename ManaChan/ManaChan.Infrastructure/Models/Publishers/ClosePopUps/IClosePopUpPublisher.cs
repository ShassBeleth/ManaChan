using ManaChan.Infrastructure.Enums;

namespace ManaChan.Infrastructure.Models.Publishers.ClosePopUps {

	/// <summary>
	/// ポップアップを閉じる通知発行者
	/// </summary>
	public interface IClosePopUpPublisher {

		/// <summary>
		/// 発行
		/// </summary>
		/// <param name="popUpName">ポップアップ名</param>
		void Publish( PopUpNames popUpName );
		
	}

}
