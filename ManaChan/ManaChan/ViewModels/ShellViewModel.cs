using ManaChan.Models.ScreenSize;
using Microsoft.Practices.Unity;
using Prism.Mvvm;
using System;

namespace ManaChan.ViewModels {

	/// <summary>
	/// ShellのViewModel
	/// </summary>
	public class ShellViewModel : BindableBase {

		[Dependency]
		public PrimaryScreenSize PrimaryScreenSize { get; } = new PrimaryScreenSize();

		public ShellViewModel() => Console.WriteLine( this.PrimaryScreenSize.ToString() );

	}

}