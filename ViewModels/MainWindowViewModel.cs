using System.Collections.ObjectModel;
using lab1.Models;
using ReactiveUI;

namespace lab1.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    private readonly int _numPoints = 2000;
    private readonly int _k = 6;

    private KMeans _kMeans;
    private ObservableCollection<Point> _points;
    private ObservableCollection<Point> _centroids;
    
}