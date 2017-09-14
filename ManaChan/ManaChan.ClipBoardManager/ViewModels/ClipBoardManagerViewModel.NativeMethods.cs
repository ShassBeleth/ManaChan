using Prism.Mvvm;
using System;
using System.Runtime.InteropServices;

namespace ManaChan.ClipBoardManager.ViewModels {
	public partial class ClipBoardManagerViewModel : BindableBase {

		/// <summary>
		/// ネイティブメソッド格納クラス
		/// </summary>
		private static class NativeMethods {

			/// <summary>
			/// クリップボードの内容が変更された時に送信される値
			/// </summary>
			private const int wM_CLIPBOARDUPDATE = 0x031D;
			
			/// <summary>
			/// クリップボードの内容が変更された時に送信される値
			/// </summary>
			public static int WM_CLIPBOARDUPDATE => wM_CLIPBOARDUPDATE;

			/// <summary>
			/// メッセージのみのウィンドウを検索するのに必要なパラメータ値
			/// </summary>
			private static IntPtr hWND_MESSAGE = new IntPtr( -3 );

			/// <summary>
			/// メッセージのみのウィンドウを検索するのに必要なパラメータ値
			/// </summary>
			public static IntPtr HWND_MESSAGE {
				set => hWND_MESSAGE = value;
				get => hWND_MESSAGE;
			}
			
			/// <summary>
			/// 指定のウィンドウをリスナーに追加
			/// </summary>
			/// <param name="hwnd"></param>
			/// <returns></returns>
			[DllImport( "user32.dll" , SetLastError = true )]
			[return: MarshalAs( UnmanagedType.Bool )]
			public static extern bool AddClipboardFormatListener( IntPtr hwnd );

			/// <summary>
			/// 指定のウィンドウをリスナーから削除
			/// </summary>
			/// <param name="hwnd"></param>
			/// <returns></returns>
			[DllImport( "user32.dll" , SetLastError = true )]
			[return: MarshalAs( UnmanagedType.Bool )]
			public static extern bool RemoveClipboardFormatListener( IntPtr hwnd );

		}
		
	}
}
