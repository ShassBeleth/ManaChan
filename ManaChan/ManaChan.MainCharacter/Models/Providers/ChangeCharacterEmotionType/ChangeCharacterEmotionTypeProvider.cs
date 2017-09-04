using ManaChan.Infrastructure.Enums;
using ManaChan.Infrastructure.Models.Events.ChangeCharacterEmotionTypeEvent;
using Prism.Events;
using Prism.Mvvm;

namespace ManaChan.MainCharacter.Models.Providers.ChangeCharacterEmotionType {

	/// <summary>
	/// キャラクター表情種別値購読者
	/// </summary>
	public class ChangeCharacterEmotionTypeProvider : BindableBase , IChangeCharacterEmotionTypeProvider {

		/// <summary>
		/// キャラクター表情種別
		/// </summary>
		private CharacterEmotionType characterEmotionType;

		/// <summary>
		/// キャラクター表情種別
		/// </summary>
		public CharacterEmotionType CharacterEmotionType {
			private set => SetProperty( ref this.characterEmotionType , value );
			get => this.characterEmotionType;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="eventAggregator">イベントアグリゲータ</param>
		public ChangeCharacterEmotionTypeProvider( IEventAggregator eventAggregator )
			=> eventAggregator.GetEvent<PubSubEvent<ChangeCharacterEmotionTypeEventValue>>()
			.Subscribe(
				x => this.CharacterEmotionType = x.CharacterEmotionType ,
				ThreadOption.UIThread
			);

	}

}
