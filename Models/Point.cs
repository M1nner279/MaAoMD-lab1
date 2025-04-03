using System;

namespace lab1.Models;

public class Point
{
    public double X { get; set; }
    public double Y { get; set; }
    public int Cluster { get; set; }

    public int GetX { get; set; }
    public int GetY { get; set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
        Cluster = -1;
        GetX = (int)x;
        GetY = (int)y;
    }

    public double DistanceTo(Point dst)
    {
        return Math.Sqrt(Math.Pow(X - dst.X, 2) + Math.Pow(Y - dst.Y, 2));
    }
}