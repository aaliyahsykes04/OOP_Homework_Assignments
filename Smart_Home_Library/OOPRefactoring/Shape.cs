using OOPRefactoring;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace OOPRefactoring
{

    //Base Case
    public interface IShape
    {
        double CalculateArea();
    }

    public class Circle : IShape
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Rectangle: IShape
    {
        private double _w, _h;
        public Rectangle(double w, double h)
        {
            _w = w;
            _h = h;
        }

        public double CalculateArea()
        {
            return _w * _h;
        }
    }
}


public interface ILogger
{
  void Log(string message);
}

public class FileLogger : ILogger
{
  private string _filePath;
  public FileLogger(string filePath)
  {
    _filePath = filePath;
  }
  public void Log(string message)
  {
    System.IO.File.AppendAllText(_filePath, message + Environment.NewLine);
  }
}

public class ShapeService
{
  private ILogger _logger;
  public ShapeService(ILogger logger)
  {
    _logger = logger;
  }
  public void Run(IShape shape)
  {
    double area = shape.CalculateArea();
    _logger.Log($"Calculated area: {area}");
  }
}

public class ShapeProcessor
{
    private readonly ILogger _logger;
    private readonly List<string> History;

    public ShapeProcessor(ILogger logger)
    {
        _logger = logger;
        History = new List<string>();
    }

    public void Process(IShape shape)
    {
        double area = shape.CalculateArea();
        string report = $"The area of the shape is: {area}";
        History.Add(report);
        _logger.Log(report);
        Console.WriteLine("DEBUG:" + report);
    }
}