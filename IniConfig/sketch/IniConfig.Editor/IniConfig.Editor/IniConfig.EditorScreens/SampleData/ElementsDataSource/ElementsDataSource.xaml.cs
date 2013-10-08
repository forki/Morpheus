﻿//      *********    DO NOT MODIFY THIS FILE     *********
//      This file is regenerated by a design tool. Making
//      changes to this file can cause errors.
namespace Expression.Blend.SampleData.ElementsDataSource
{
	using System; 

// To significantly reduce the sample data footprint in your production application, you can set
// the DISABLE_SAMPLE_DATA conditional compilation constant and disable sample data at runtime.
#if DISABLE_SAMPLE_DATA
	internal class ElementsDataSource { }
#else

	public class ElementsDataSource : System.ComponentModel.INotifyPropertyChanged
	{
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		public ElementsDataSource()
		{
			try
			{
				System.Uri resourceUri = new System.Uri("/IniConfig.Editor.Screens;component/SampleData/ElementsDataSource/ElementsDataSource.xaml", System.UriKind.Relative);
				if (System.Windows.Application.GetResourceStream(resourceUri) != null)
				{
					System.Windows.Application.LoadComponent(this, resourceUri);
				}
			}
			catch (System.Exception)
			{
			}
		}

		private Elements _Elements = new Elements();

		public Elements Elements
		{
			get
			{
				return this._Elements;
			}
		}
	}

	public class ElementsItem : System.ComponentModel.INotifyPropertyChanged
	{
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		private string _Name = string.Empty;

		public string Name
		{
			get
			{
				return this._Name;
			}

			set
			{
				if (this._Name != value)
				{
					this._Name = value;
					this.OnPropertyChanged("Name");
				}
			}
		}

		private double _Value = 0;

		public double Value
		{
			get
			{
				return this._Value;
			}

			set
			{
				if (this._Value != value)
				{
					this._Value = value;
					this.OnPropertyChanged("Value");
				}
			}
		}

		private string _Remarks = string.Empty;

		public string Remarks
		{
			get
			{
				return this._Remarks;
			}

			set
			{
				if (this._Remarks != value)
				{
					this._Remarks = value;
					this.OnPropertyChanged("Remarks");
				}
			}
		}

		private string _Type = string.Empty;

		public string Type
		{
			get
			{
				return this._Type;
			}

			set
			{
				if (this._Type != value)
				{
					this._Type = value;
					this.OnPropertyChanged("Type");
				}
			}
		}
	}

	public class Elements : System.Collections.ObjectModel.ObservableCollection<ElementsItem>
	{ 
	}
#endif
}
