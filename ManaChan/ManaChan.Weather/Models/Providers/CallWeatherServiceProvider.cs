using ManaChan.Infrastructure.Models.Events.CallWeatherServiceEvent;
using Prism.Events;
using Prism.Mvvm;

namespace ManaChan.Weather.Models.Providers {

	public class CallWeatherServiceProvider : BindableBase , ICallWeatherServiceProvider{

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
		public CallWeatherServiceProvider( IEventAggregator eventAggregator )
			=> eventAggregator.GetEvent<PubSubEvent<CallWeatherServiceEventValue>>()
			.Subscribe(
				x => this.Guid = x.Guid ,
				ThreadOption.UIThread
			);

	}

}
