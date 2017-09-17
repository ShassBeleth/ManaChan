using System.ComponentModel;
using ManaChan.Infrastructure.Enums;

namespace ManaChan.Infrastructure.Models.Providers.CallServices {

	/// <summary>
	/// サービス呼び出し購読者
	/// </summary>
	public interface ICallServiceProvider : INotifyPropertyChanged {

		/// <summary>
		/// サービス名
		/// </summary>
		ServiceNames ServiceName { get; }

		/// <summary>
		/// 変更検知用GUID
		/// </summary>
		string Guid { get; }

	}

}
