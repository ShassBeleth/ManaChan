using Prism.Commands;
using Prism.Mvvm;
using System;
using System.IO;

namespace ManaChan.ClipBoardManager.ViewModels {

	/// <summary>
	/// クリップボード管理のViewModel
	/// </summary>
	public class ClipBoardManagerViewModel : BindableBase {

		/// <summary>
		/// ファイル監視者
		/// </summary>
		private FileSystemWatcher FileSystemWatcher { set; get; }

		#region テスト用

		public string test = "123123123awefawfwfwfwfwefwefwfwe";

		public string Test {
			private set => SetProperty( ref this.test , value );
			get => this.test;
		}

		#endregion

		#region 監視切り替えボタン

		/// <summary>
		/// 実行中かどうか
		/// </summary>
		private bool IsExecuting { set; get; } = false;

		/// <summary>
		/// 監視切り替えボタン文字列
		/// </summary>
		private string watcherSwitchContent = "クリップボード監視開始";

		/// <summary>
		/// 監視切り替えボタン文字列
		/// </summary>
		public string WatcherSwitchContent {
			private set => SetProperty( ref this.watcherSwitchContent , value );
			get => this.watcherSwitchContent;
		}

		/// <summary>
		/// 監視切り替えボタンコマンド
		/// </summary>
		private DelegateCommand watcherSwitchCommand;

		/// <summary>
		/// 監視切り替えボタンコマンド
		/// </summary>
		public DelegateCommand WatcherSwitchCommand {
			private set => SetProperty( ref this.watcherSwitchCommand , value );
			get => this.watcherSwitchCommand;
		}

		/// <summary>
		/// 監視切り替えボタン実行
		/// </summary>
		/// <returns></returns>
		private Action WatcherSwitchExecute() => () => {
			
			this.IsExecuting = !this.IsExecuting;
			
			// 監視の開始
			if( this.IsExecuting ) {
				this.WatcherSwitchContent = "クリップボード監視停止";
				this.FileSystemWatcher.EnableRaisingEvents = true;
				Console.WriteLine( "File System Watcher Start" );
			}
			// 監視の停止
			else {
				this.WatcherSwitchContent = "クリップボード監視開始";
				this.FileSystemWatcher.EnableRaisingEvents = false;
				Console.WriteLine( "File System Watcher Stop" );
			}

		};

		/// <summary>
		/// 監視切り替えボタン実行可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanWatcherSwitchExecute() => () => true;

		#endregion

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ClipBoardManagerViewModel() {

			this.FileSystemWatcher = new FileSystemWatcher() {
				Path = @"C:\Unity" ,
				NotifyFilter = ( NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName ) ,
				Filter = ""
			};
			this.FileSystemWatcher.Changed += ( _ , e ) => { Console.WriteLine( "チェンジ" ); };
			this.FileSystemWatcher.Created += ( _ , e ) => { Console.WriteLine( "クリエイト" ); };
			this.FileSystemWatcher.Deleted += ( _ , e ) => { Console.WriteLine( "デリート" ); };
			this.FileSystemWatcher.Renamed += ( _ , e ) => { Console.WriteLine( "リネーム" ); };
			
			this.WatcherSwitchCommand = new DelegateCommand( this.WatcherSwitchExecute() , this.CanWatcherSwitchExecute() );

		}
	}

}
