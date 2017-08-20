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

namespace ManaChan.Twitter {
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window {

		public MainWindow() {

			InitializeComponent();
			
			string consumerKey = "";
			string consumerSecret = "";

			OAuth.OAuthSession session = OAuth.Authorize( consumerKey , consumerSecret );
			
			Uri url = session.AuthorizeUri;
			System.Diagnostics.Process.Start( url.ToString() );
			
			Tokens tokens = OAuth.GetTokens( session , "" );

			ListedResponse<Status> timeline = tokens.Statuses.HomeTimeline();

			foreach( Status status in timeline ) {
				Console.Write( status.FullText );
			}

		}

	}

}
