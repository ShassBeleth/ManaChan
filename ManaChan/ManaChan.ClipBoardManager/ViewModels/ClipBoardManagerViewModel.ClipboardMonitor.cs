using Prism.Mvvm;
using System;
using System.Windows.Interop;

namespace ManaChan.ClipBoardManager.ViewModels {
	public partial class ClipBoardManagerViewModel : BindableBase {

		/// <summary>
		/// クリップボードモニター
		/// </summary>
		public class ClipBoardMonitor : IDisposable {

			/// <summary>
			/// クリップボードの内容が変更された時のイベントハンドラ
			/// </summary>
			public event EventHandler OnClipboardContentChanged;

			/// <summary>
			/// 新規にインスタンスを作る
			/// </summary>
			private HwndSource hwndSource = new HwndSource( 0 , 0 , 0 , 0 , 0 , 0 , 0 , null , NativeMethods.HWND_MESSAGE );

			/// <summary>
			/// コンストラクタ
			/// </summary>
			public ClipBoardMonitor() {
				this.hwndSource.AddHook( this.WndProc );
				NativeMethods.AddClipboardFormatListener( this.hwndSource.Handle );
			}

			/// <summary>
			/// インスタンス削除時
			/// </summary>
			public void Dispose() {
				if( this.hwndSource != null ) {
					NativeMethods.RemoveClipboardFormatListener( this.hwndSource.Handle );
					this.hwndSource.RemoveHook( this.WndProc );
					this.hwndSource.Dispose();
				}
			}

			private IntPtr WndProc( IntPtr hwnd , int msg , IntPtr wParam , IntPtr lParam , ref bool handled ) {

				// UPDATE時のみクリップボードの変更イベントを発火させる
				if( msg == NativeMethods.WM_CLIPBOARDUPDATE )
					OnClipboardContentChanged?.Invoke( this , EventArgs.Empty );

				return IntPtr.Zero;

			}

		}
		
	}
}
