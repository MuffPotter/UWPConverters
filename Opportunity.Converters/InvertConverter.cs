﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Opportunity.Converters
{
    [Windows.UI.Xaml.Markup.ContentProperty(Name = nameof(InnerConverter))]
    public sealed class InvertConverter : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                return this.InnerConverter.ConvertBack(value, targetType, parameter, language);
            }
            catch(Exception)
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return this.InnerConverter.Convert(value, targetType, parameter, language);
        }

        protected override void OnInnerConverterChanged(DependencyPropertyChangedEventArgs e)
        {
            if(e.NewValue == null)
                throw new ArgumentNullException(nameof(InnerConverter));
        }
    }
}
