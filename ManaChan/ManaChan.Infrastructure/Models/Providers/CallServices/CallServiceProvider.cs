using ManaChan.Infrastructure.Enums;
using ManaChan.Infrastructure.Models.Events.CallServices;
using Prism.Events;
using Prism.Mvvm;

namespace ManaChan.Infrastructure.Models.Providers.CallServices {

	/// <summary>
	/// サービス呼び出し購読者
	/// </summary>
	public class CallServiceProvider : BindableBase , ICallServiceProvider {

		/// <summary>
		/// サービス名
		/// </summary>
		private ServiceNames serviceName;

		/// <summary>
		/// サービス名
		/// </summary>
		public ServiceNames ServiceName {
			private set => this.SetProperty( ref this.serviceName , value );
			get => this.serviceName;
		}

		/// <summary>
		/// 変更検知用GUID
		/// </summary>
		private string guid;

		/// <summary>
		/// 変更検知用GUID
		/// </summary>
		public string Guid {
			private set => this.SetProperty( ref this.guid , value );
			get => this.guid;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="eventAggregator">イベントアグリゲータ</param>
		public CallServiceProvider( IEventAggregator eventAggregator )
			=> eventAggregator.GetEvent<PubSubEvent<CallServiceEventValue>>()
			.Subscribe(
				x => {
					this.ServiceName = x.ServiceName;
					this.Guid = x.Guid;
				} ,
				ThreadOption.UIThread
			);

	}

}
