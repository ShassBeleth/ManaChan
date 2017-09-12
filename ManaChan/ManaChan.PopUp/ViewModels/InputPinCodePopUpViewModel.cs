using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;
using System;
using ManaChan.PopUp.Models.PinCode;

namespace ManaChan.PopUp.ViewModels {

	public class InputPinCodePopUpViewModel : BindableBase {

		/// <summary>
		/// モジュール橋渡し発行者
		/// </summary>
		[Dependency]
		public IPinCodePublisher PinCodePublisher { set; get; }

		private string pinCode = "";

		public string PinCode {
			set => SetProperty( ref this.pinCode , value );
			get => this.pinCode;
		}
		
		#region OKボタン

		/// <summary>
		/// OKボタン文字列
		/// </summary>
		public string OkContext { get; } = "OK";

		/// <summary>
		/// OKボタンコマンド
		/// </summary>
		private DelegateCommand okCommand;

		/// <summary>
		/// OKボタンコマンド
		/// </summary>
		public DelegateCommand OkCommand {
			private set => SetProperty( ref this.okCommand , value );
			get => this.okCommand;
		}

		/// <summary>
		/// OKボタンイベント
		/// </summary>
		/// <returns></returns>
		private Action OkExecute() => () => this.PinCodePublisher.Publish( int.Parse( this.PinCode ) );

		/// <summary>
		/// OKボタンイベント可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanOkExecute() => () => true;

		#endregion

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public InputPinCodePopUpViewModel() => this.OkCommand = new DelegateCommand( this.OkExecute() , this.CanOkExecute() );

	}

}
