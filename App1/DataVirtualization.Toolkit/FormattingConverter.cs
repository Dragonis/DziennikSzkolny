﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace DataVirtualization.Toolkit
{
       /// <summary>
    /// A value converter that delegates to String.Format
    /// </summary>
    public class FormattingConverter : IValueConverter
    {
       

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string formatString = parameter as string;
            if (formatString != null)
            {
                return string.Format(formatString, value);
            }
            else
            {
                return value.ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

