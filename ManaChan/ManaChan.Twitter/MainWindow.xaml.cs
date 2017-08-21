using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CoreTweet;
using CoreTweet.Core;
using ManaChan.Twitter.Services;

namespace ManaChan.Twitter {
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window {

		private AuthenticatedService service;

		public MainWindow() {

			InitializeComponent();

			this.service = new AuthenticatedService();

		}
		

		private void Auth( object sender , RoutedEventArgs e ) => this.service.Authorize();

		private void SetPin( object sender , RoutedEventArgs e ) {
			string inputPin = this.inputPin.Text;
			this.service.SetPinCode( int.Parse( inputPin ) );
		}
	}

}
