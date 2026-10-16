using System;

public abstract class Activity
{
    private DateTime _date;
    private int _length;

    public Activity(DateTime date, int length)
    {
        _date = date;
        _length = length;
    }

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_length} min): " +
               $"Distance: {GetDistance():F2} miles, " +
               $"Speed: {GetSpeed():F2} mph, " +
               $"Pace: {GetPace():F2} min per mile";
    }

    protected int GetLength()
    {
        return _length;
    }
}