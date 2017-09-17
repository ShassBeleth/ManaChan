using System;
using System.Collections.ObjectModel;
using System.Windows;
using ManaChan.ClipBoardManager.Models.Publishers.ClosePopUp;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;

namespace ManaChan.ClipBoardManager.ViewModels {

	/// <summary>
	/// クリップボード管理のViewModel
	/// </summary>
	public partial class ClipBoardManagerViewModel : BindableBase {
		
		/// <summary>
		/// ダイアログを閉じるための発行者
		/// </summary>
		[Dependency]
		public CloseClipBoardPopUpPublisher CloseClipBoardPopUpPublisher { set; get; }

		#region タイトル

		public string TitleContent { get; } = "クリップボード";

		#endregion

		#region クリップボード保存データ一覧

		#region 固定文言

		/// <summary>
		/// クリップボードに登録するボタンヘッダ文字列
		/// </summary>
		public string InsertButtonHeader { get; } = "使う";

		/// <summary>
		/// クリップボードに登録するボタン文字列
		/// </summary>
		public string InsertButtonContent { get; } = "→";

		/// <summary>
		/// 登録日時ヘッダ文字列
		/// </summary>
		public string TimeHeader { get; } = "登録日時";

		/// <summary>
		/// 簡易形式ヘッダ文字列
		/// </summary>
		public string SimpleFormatHeader { get; } = "形式";

		/// <summary>
		/// 内容ヘッダ文字列
		/// </summary>
		public string ContentHeader { get; } = "内容";

		/// <summary>
		/// 履歴から削除するボタンヘッダ文字列
		/// </summary>
		public string RemoveButtonHeader { get; } = "削除";

		/// <summary>
		/// 履歴から削除するボタン文字列
		/// </summary>
		public string RemoveButtonContent { get; } = "→";

		#endregion

		/// <summary>
		/// クリップボード監視者
		/// </summary>
		private ClipBoardMonitor clipBoardMonitor = new ClipBoardMonitor();

		/// <summary>
		/// クリップボード保存データ一覧
		/// </summary>
		public ObservableCollection<ClipBoardData> ClipBoardDataList { set; get; } = new ObservableCollection<ClipBoardData>();

		/// <summary>
		/// クリップボード更新時イベントを動かすかどうか
		/// </summary>
		private bool isChangeEventActive = true;

		/// <summary>
		/// クリップボード更新時イベント
		/// </summary>
		private void OnClipBoardContentChanged() {
			
			if( !this.isChangeEventActive ) {
				this.isChangeEventActive = true;
				return;
			}
			
			this.ClipBoardDataList.Add( new ClipBoardData( Clipboard.GetDataObject() ) );
			
		}
			
		/// <summary>
		/// 選択中のアイテム
		/// </summary>
		public ClipBoardData SelectedItem { set; get; }

		#region 使用ボタン

		/// <summary>
		/// 使用ボタンコマンド
		/// </summary>
		private DelegateCommand insertClipBoardDataCommand;

		/// <summary>
		/// 使用ボタンコマンド
		/// </summary>
		public DelegateCommand InsertClipBoardDataCommand {
			private set => SetProperty( ref this.insertClipBoardDataCommand , value );
			get => this.insertClipBoardDataCommand;
		}

		/// <summary>
		/// 使用ボタン実行
		/// </summary>
		/// <returns></returns>
		private Action InsertClipBoardDataExecute() => () => {
			this.isChangeEventActive = false;
			Clipboard.SetDataObject( this.SelectedItem.DataObject );
		};

		/// <summary>
		/// 使用ボタン実行可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanInsertClipBoardDataExecute() => () => true;

		#endregion

		#region 削除ボタン

		/// <summary>
		/// 削除ボタンコマンド
		/// </summary>
		private DelegateCommand removeClipBoardDataCommand;

		/// <summary>
		/// 削除ボタンコマンド
		/// </summary>
		public DelegateCommand RemoveClipBoardDataCommand {
			private set => SetProperty( ref this.removeClipBoardDataCommand , value );
			get => this.removeClipBoardDataCommand;
		}

		/// <summary>
		/// 削除ボタン実行
		/// </summary>
		/// <returns></returns>
		private Action RemoveClipBoardDataExecute() => () => this.ClipBoardDataList.Remove( this.SelectedItem );

		/// <summary>
		/// 削除ボタン実行可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanRemoveClipBoardDataExecute() => () => true;

		#endregion

		#endregion

		#region 閉じるボタン

		/// <summary>
		/// 閉じるボタン文字列
		/// </summary>
		public string CloseButtonContent { get; } = "閉じる";

		/// <summary>
		/// 閉じるボタンコマンド
		/// </summary>
		private DelegateCommand closeButtonCommand;

		/// <summary>
		/// 閉じるボタンコマンド
		/// </summary>
		public DelegateCommand CloseButtonCommand {
			private set => SetProperty( ref this.closeButtonCommand , value );
			get => this.closeButtonCommand;
		}

		/// <summary>
		/// 閉じるボタン実行
		/// </summary>
		/// <returns></returns>
		private Action CloseButtonExecute() => () => {
			this.CloseClipBoardPopUpPublisher.Publish();
		};

		/// <summary>
		/// 閉じるボタン実行可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanCloseButtonExecute() => () => true;

		#endregion

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ClipBoardManagerViewModel() {
			this.clipBoardMonitor.OnClipboardContentChanged += ( sender , e ) => this.OnClipBoardContentChanged();
			this.RemoveClipBoardDataCommand = new DelegateCommand( this.RemoveClipBoardDataExecute() , this.CanRemoveClipBoardDataExecute() );
			this.InsertClipBoardDataCommand = new DelegateCommand( this.InsertClipBoardDataExecute() , this.CanInsertClipBoardDataExecute() );
			this.CloseButtonCommand = new DelegateCommand( this.CloseButtonExecute() , this.CanCloseButtonExecute() );
		}
		
	}

}
