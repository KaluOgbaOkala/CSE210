using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "What was the strongest emotion you felt today?",
        "What did you learn today?",
        "What are you grateful for today?",
        "What was the most interesting thing you saw today?",
        "What is something you would like to improve?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}