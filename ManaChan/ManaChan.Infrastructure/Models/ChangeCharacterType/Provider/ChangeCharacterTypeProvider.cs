using ManaChan.Infrastructure.Enums;
using ManaChan.Infrastructure.Models.ChangeCharacterType.Events;
using Prism.Events;
using Prism.Mvvm;

namespace ManaChan.Infrastructure.Models.ChangeCharacterType.Provider {

	/// <summary>
	/// キャラクター種別値購読者
	/// </summary>
	public class ChangeCharacterTypeProvider : BindableBase , IChangeCharacterTypeProvider {

		/// <summary>
		/// キャラクター種別
		/// </summary>
		private CharacterType value;

		/// <summary>
		/// キャラクター種別
		/// </summary>
		public CharacterType Value {
			private set => this.SetProperty( ref this.value , value );
			get => this.value;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="eventAggregator">イベントアグリゲータ</param>
		public ChangeCharacterTypeProvider( IEventAggregator eventAggregator )
			=> eventAggregator.GetEvent< PubSubEvent < ChangeCharacterTypeEvent > >()
			.Subscribe( x => this.Value = x.Value , ThreadOption.UIThread );

	}

}
