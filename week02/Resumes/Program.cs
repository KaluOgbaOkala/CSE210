class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();

        job1._jobTitle = "Business Development Manager";
        job1._company = "PHHLINKS LTD";
        job1._startYear = 2018;
        job1._endYear = 2022;

        Job job2 = new Job();

        job2._jobTitle = "Sales Executive";
        job2._company = "Flora Truworth";
        job2._startYear = 2022;
        job2._endYear = 2025;

        Resume myResume = new Resume();

        myResume._name = "Kalu Ogba Okala";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}