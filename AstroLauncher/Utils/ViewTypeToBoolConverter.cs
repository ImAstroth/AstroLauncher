using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace AstroLauncher.Utils;

public class ViewTypeToBoolConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null || parameter == null) return false;
        return value.GetType().Name == parameter.ToString();
    }
    
    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}