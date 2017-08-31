using ManaChan.Infrastructure.Enums;
using ManaChan.Infrastructure.Models.Passer.Events;
using Prism.Events;
using Prism.Mvvm;

namespace ManaChan.Infrastructure.Models.Passer.Providers {

	/// <summary>
	/// キャラクター種別値購読者
	/// </summary>
	public class ProviderOfPasser : BindableBase , IProviderOfPasser {

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
		/// PINコード
		/// </summary>
		private int pinCode;

		public int PinCode {
			private set => this.SetProperty( ref this.pinCode , value );
			get => this.pinCode;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="eventAggregator">イベントアグリゲータ</param>
		public ProviderOfPasser( IEventAggregator eventAggregator )
			=> eventAggregator.GetEvent< PubSubEvent < EventOfPasser > >()
			.Subscribe( 
				x => {
					this.CharacterType = x.CharacterType;
					this.PinCode = x.PinCode;
				} , 
				ThreadOption.UIThread 
			);

	}

}
