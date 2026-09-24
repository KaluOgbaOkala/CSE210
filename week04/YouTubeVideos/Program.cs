List<Video> videos = new List<Video>();

Video video1 = new Video(
    "Learn C# Programming",
    "BYU Pathway",
    600
);

video1.AddComment(new Comment(
    "Kalu",
    "This is a very helpful lesson."
));

video1.AddComment(new Comment(
    "David",
    "I am learning C# too."
));

video1.AddComment(new Comment(
    "Grace",
    "The explanation was easy to understand."
));

videos.Add(video1);


Video video2 = new Video(
    "Introduction to Python",
    "Programming Academy",
    720
);

video2.AddComment(new Comment(
    "John",
    "Python is easier than I expected."
));

video2.AddComment(new Comment(
    "Mary",
    "Great explanation!"
));

video2.AddComment(new Comment(
    "Peter",
    "I will practice this today."
));

video2.AddComment(new Comment(
    "James",
    "Very useful video."
));

videos.Add(video2);


Video video3 = new Video(
    "How to Build a Website",
    "Web Development Channel",
    900
);

video3.AddComment(new Comment(
    "Samuel",
    "I learned something new today."
));

video3.AddComment(new Comment(
    "Chisom",
    "The HTML explanation was clear."
));

video3.AddComment(new Comment(
    "Michael",
    "I am going to try this myself."
));

videos.Add(video3);


Video video4 = new Video(
    "Understanding Object-Oriented Programming",
    "Code School",
    840
);

video4.AddComment(new Comment(
    "Daniel",
    "Classes make more sense now."
));

video4.AddComment(new Comment(
    "Esther",
    "I like the way this was explained."
));

video4.AddComment(new Comment(
    "Joseph",
    "Abstraction is interesting."
));

video4.AddComment(new Comment(
    "Ruth",
    "I need more practice with classes."
));

videos.Add(video4);


foreach (Video video in videos)
{
    Console.WriteLine("========================================");
    Console.WriteLine($"Title: {video.GetTitle()}");
    Console.WriteLine($"Author: {video.GetAuthor()}");
    Console.WriteLine($"Length: {video.GetLength()} seconds");
    Console.WriteLine($"Comments: {video.GetCommentCount()}");
    Console.WriteLine("----------------------------------------");

    foreach (Comment comment in video.GetComments())
    {
        Console.WriteLine($"- {comment.GetCommentText()}");
    }

    Console.WriteLine();
}