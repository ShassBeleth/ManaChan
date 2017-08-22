using System;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Prism.Commands;
using ManaChan.Models;

namespace ManaChan.ViewModels {

	public class InputPinCodeViewModel : BindableBase , IInteractionRequestAware {
		
		public Action FinishInteraction { get; set; }

		private INotification notification;

		public INotification Notification {
			set {
				this.notification = value;
				this.InputText = "";
			}
			get => this.notification;
		}

		private string inputText;

		public string InputText {
			set => SetProperty( ref this.inputText , value );
			get => this.inputText;
		}

		public DelegateCommand OKCommand { get; }

		public InputPinCodeViewModel()
			=> this.OKCommand = new DelegateCommand(
				() => {
					( (InputPinCodeNotification)this.Notification ).InputPinCode = int.Parse( this.InputText );
					Console.WriteLine( "OK押された" );
					this.FinishInteraction();
				} ,
				() => !string.IsNullOrWhiteSpace( this.InputText ) )
				.ObservesProperty( () => this.InputText );
		
	}

}
