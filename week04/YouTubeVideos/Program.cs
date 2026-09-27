using System;
using System.Collections.Generic;

namespace YouTubeVideoTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            List< Video > videos = new List< Video >();

            Video video1 = new Video("C# Object-Oriented Programming Fundamentals", "Code Academy", 720);
            video1.AddComment(new Comment("Alice", "Great explanation of classes and objects!"));
            video1.AddComment(new Comment("Bob", "This made abstraction finally click for me."));
            video1.AddComment(new Comment("Charlie", "Could you cover interfaces in the next video?"));
            videos.Add(video1);

            Video video2 = new Video("10 Minute Daily Full Body Workout", "Fitness Hub", 600);
            video2.AddComment(new Comment("Dave", "Awesome routine, really feeling energized."));
            video2.AddComment(new Comment("Ella", "Loved the stretches at the end."));
            video2.AddComment(new Comment("Frank", "Short and effective, thanks!"));
            videos.Add(video2);

            Video video3 = new Video("Python vs C#: Which Should You Learn First?", "Tech Talk", 850);
            video3.AddComment(new Comment("Grace", "C# for structure, Python for quick scripts."));
            video3.AddComment(new Comment("Hank", "Very balanced comparison. Subscribed!"));
            video3.AddComment(new Comment("Ivy", "The visual breakdown of syntax differences was super helpful."));
            videos.Add(video3);

            Video video4 = new Video("Async/Await Best Practices in C#", "Dev Insights", 540);
            video4.AddComment(new Comment("Jack", "Avoiding deadlocks is always a timely reminder."));
            video4.AddComment(new Comment("Karen", "Straight to the point without fluff."));
            video4.AddComment(new Comment("Leo", "Sharing this with my development team today."));
            videos.Add(video4);

            foreach (Video video in videos)
            {
                Console.WriteLine("========================================");
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
                Console.WriteLine($"Comment Count: {video.GetCommentCount()}");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Comments:");

                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($"  - {comment.CommenterName}: \"{comment.Text}\"");
                }

                Console.WriteLine();
            }
        }
    }
}