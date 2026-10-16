using System;
using System.Collections.Generic;

class Program
{
static void Main(string[] args)
{
List<Activity> activities = new List<Activity>();

    activities.Add(new Running(new DateTime(2026, 10, 14), 30, 3));
    activities.Add(new Cycling(new DateTime(2026, 10, 14), 30, 15));
    activities.Add(new Swimming(new DateTime(2026, 10, 14), 30, 20));

    foreach (Activity activity in activities)
    {
        Console.WriteLine(activity.GetSummary());
    }
}


}
