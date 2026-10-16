using System;

public class Swimming : Activity
{
private int _laps;

public Swimming(DateTime date, int length, int laps)
    : base(date, length)
{
    _laps = laps;
}

public override double GetDistance()
{
    double distanceInKilometers = (_laps * 50.0) / 1000;
    return distanceInKilometers * 0.62;
}

public override double GetSpeed()
{
    return (GetDistance() / GetLength()) * 60;
}

public override double GetPace()
{
    return GetLength() / GetDistance();
}

}
