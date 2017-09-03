using ManaChan.Infrastructure.Enums;
using ManaChan.Infrastructure.Models.Events.ChangeCharacterTypeEvent;
using Prism.Events;
using Prism.Mvvm;

namespace ManaChan.MainCharacter.Models.Providers.ChangeCharacterType {

	/// <summary>
	/// キャラクター種別値購読者
	/// </summary>
	public class ChangeCharacterTypeProvider : BindableBase , IChangeCharacterTypeProvider {

		/// <summary>
		/// キャラクター種別
		/// </summary>
		private CharacterType characterType;

		/// <summary>
		/// キャラクター種別
		/// </summary>
		public CharacterType CharacterType {
			private set => this.SetProperty( ref this.characterType , value );
			get => this.characterType;
		}
		
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="eventAggregator">イベントアグリゲータ</param>
		public ChangeCharacterTypeProvider( IEventAggregator eventAggregator )
			=> eventAggregator.GetEvent< PubSubEvent < ChangeCharacterTypeEventValue > >()
			.Subscribe( 
				x => this.CharacterType = x.CharacterType ,
				ThreadOption.UIThread 
			);

	}

}
