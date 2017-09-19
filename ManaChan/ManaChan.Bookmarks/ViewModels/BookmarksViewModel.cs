using Prism.Mvvm;
using System;
using System.IO;

namespace ManaChan.Bookmarks.ViewModels {

	/// <summary>
	/// ブックマークのViewModel
	/// </summary>
	public class BookmarksViewModel : BindableBase {

		/// <summary>
		/// Chromeのブックマークフォルダパス
		/// </summary>
		private string ChromeBookmarksFolderPath { get; } = Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData ) + @"\Google\Chrome\User Data\Default";

		/// <summary>
		/// Chromeのブックマークファイルパス
		/// </summary>
		private string ChromeBookmarksFilePath { get; } = "Bookmarks";

		/// <summary>
		/// ファイル管理
		/// </summary>
		private FileSystemWatcher FileSystemWatcher { get; set; }

		/// <summary>
		/// ファイル管理初期化
		/// </summary>
		private void InitializedFileSystemWatcher() {
			
			this.FileSystemWatcher = new FileSystemWatcher() {
				Path = this.ChromeBookmarksFolderPath ,
				NotifyFilter = (
					NotifyFilters.LastAccess |
					NotifyFilters.LastWrite |
					NotifyFilters.FileName |
					NotifyFilters.DirectoryName
				) ,
				Filter = this.ChromeBookmarksFilePath
			};

			this.FileSystemWatcher.Changed += ( _ , e ) => this.ChangedFileSystemWatcher();

		}
		
		/// <summary>
		/// ファイル管理開始
		/// </summary>
		private void StartFileSystemWatcher() => this.FileSystemWatcher.EnableRaisingEvents = true;

		/// <summary>
		/// ファイル管理終了
		/// </summary>
		private void StopFileSystemWatcher() => this.FileSystemWatcher.EnableRaisingEvents = false;

		/// <summary>
		/// ファイル変更時イベント
		/// </summary>
		private void ChangedFileSystemWatcher() => Console.WriteLine( "チェンジ" );

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public BookmarksViewModel() {
			this.InitializedFileSystemWatcher();
			this.StartFileSystemWatcher();
		}

	}

}
