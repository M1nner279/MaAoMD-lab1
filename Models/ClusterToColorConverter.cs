using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;

namespace lab1.Models;

public class ClusterToColorConverter : IValueConverter
{
    private static readonly Color[] Colors = new[]
    {
        Avalonia.Media.Colors.Cyan, 
        Avalonia.Media.Colors.Green, 
        Avalonia.Media.Colors.Purple, 
        Avalonia.Media.Colors.Orange, 
        Avalonia.Media.Colors.Cyan, 
        Avalonia.Media.Colors.Magenta, 
        Avalonia.Media.Colors.Yellow
    };

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int cluster)
        {
            return new SolidColorBrush(cluster >= 0 ? Colors[cluster % Colors.Length] : Avalonia.Media.Colors.Gray);
        }
        return new SolidColorBrush(Avalonia.Media.Colors.Gray);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class CentroidOffsetConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is double coord)
        {
            return coord - 5; // Смещение для центрирования эллипса
        }
        return 0.0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}