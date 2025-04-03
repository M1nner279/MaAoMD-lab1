using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using lab1.Models;

namespace lab1.Views;

public partial class MainWindow : Window
{
    private readonly Canvas _canvas;
    private KMeans _kMeans;
    private readonly int _numPoints = 2000; // get from User
    private readonly int _k = 6; // get from User

    public MainWindow()
    {
        InitializeComponent();
        _canvas = this.FindControl<Canvas>("DrawingCanvas");
    }

    private void OnInitializeClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        // Генерация случайных точек
        var random = new Random();
        var points = new List<Point>();
        for (int i = 0; i < _numPoints; i++)
        {
            points.Add(new Point(random.NextDouble() * 400, random.NextDouble() * 400));
        }

        // Инициализация KMeans
        _kMeans = new KMeans(points, _k);
        _kMeans.InitializeCentroids();

        // Отрисовка начального состояния
        DrawCanvas();
    }

    private void OnStepClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_kMeans == null) return;

        // Выполнение одного шага алгоритма
        bool changed = _kMeans.AssignClusters();
        bool moved = _kMeans.UpdateCentroids();

        // Перерисовка канваса
        DrawCanvas();

        // Если ничего не изменилось, уведомляем
        if (!changed && !moved)
        {
            Console.WriteLine("Алгоритм завершён.");
        }
    }

    private void DrawCanvas()
    {
        if (_kMeans == null) return;

        // Очистка канваса
        _canvas.Children.Clear();

        // Получение текущего состояния
        var (points, centroids) = _kMeans.GetCurrentState();

        // Цвета для кластеров
        var clusterColors = new[]
        {
            Brushes.Blue, Brushes.Green, Brushes.Purple, Brushes.Orange, Brushes.Cyan, Brushes.Magenta, Brushes.Yellow
        };

        // Отрисовка точек
        foreach (var point in points)
        {
            var ellipse = new Ellipse
            {
                Width = 5,
                Height = 5,
                Fill = point.Cluster >= 0 ? clusterColors[point.Cluster % clusterColors.Length] : Brushes.Gray
            };
            Canvas.SetLeft(ellipse, point.X - 2.5); // Центрируем точку
            Canvas.SetTop(ellipse, point.Y - 2.5);
            _canvas.Children.Add(ellipse);
        }

        // Отрисовка центроидов
        foreach (var centroid in centroids)
        {
            var ellipse = new Ellipse
            {
                Width = 10,
                Height = 10,
                Fill = Brushes.Red
            };
            Canvas.SetLeft(ellipse, centroid.X - 5); // Центрируем центроид
            Canvas.SetTop(ellipse, centroid.Y - 5);
            _canvas.Children.Add(ellipse);
        }
    }
}
