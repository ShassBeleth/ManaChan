using System;
using System.Windows;
using System.Windows.Data;

namespace ManaChan.Converter {

	/// <summary>
	/// EnumとBooleanの変換
	/// </summary>
	public class EnumToBooleanConverter : IValueConverter {

		/// <summary>
		/// 変換
		/// </summary>
		/// <param name="value"></param>
		/// <param name="targetType"></param>
		/// <param name="parameter"></param>
		/// <param name="culture"></param>
		/// <returns></returns>
		public object Convert( object value , Type targetType , object parameter , System.Globalization.CultureInfo culture ) {

			string parameterString = parameter as string;
			if( parameterString == null )
				return DependencyProperty.UnsetValue;

			if( Enum.IsDefined( value.GetType() , value ) == false )
				return DependencyProperty.UnsetValue;

			object parameterValue = Enum.Parse( value.GetType() , parameterString );

			return parameterValue.Equals( value );

		}

		/// <summary>
		/// 逆変換
		/// </summary>
		/// <param name="value"></param>
		/// <param name="targetType"></param>
		/// <param name="parameter"></param>
		/// <param name="culture"></param>
		/// <returns></returns>
		public object ConvertBack( object value , Type targetType , object parameter , System.Globalization.CultureInfo culture )
			=> parameter as string == null ? DependencyProperty.UnsetValue : Enum.Parse( targetType , parameter as string );

	}

}