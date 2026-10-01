public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
{
    "Think of a time when you stood up for someone else.",
    "Think of a time when you did something really difficult.",
    "Think of a time when you helped someone.",
    "Think of a time when you overcame a challenge."
};
    private List<string> _questions = new List<string>
{
    "What did you learn from that experience?",
    "How did that experience help you grow?",
    "What can you learn from that situation?",
    "Why was this experience meaningful to you?",
    "How can you use what you learned in the future?"
};
    private Random _random = new Random();
    public ReflectionActivity()
        : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience."
        )
    {
    }
    public void Run()
    {
        DisplayStartingMessage();

        int elapsedTime = 0;

        int index = _random.Next(_prompts.Count);
        Console.WriteLine(_prompts[index]);

        ShowCountdown(5);

        while (elapsedTime < GetDuration())
        {
            int questionIndex = _random.Next(_questions.Count);
            Console.WriteLine(_questions[questionIndex]);

            int questionTime = Math.Min(5, GetDuration() - elapsedTime);
            ShowCountdown(questionTime);

            elapsedTime += questionTime;
        }    

                    DisplayEndingMessage();
    }
}