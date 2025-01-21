using System;
using System.Collections.Generic;

namespace CSLab.CoreTypes.Delegates
{
    public class Main
    {
        public static void Run()
        {
            var video = new Video() { Title = "Dependency injection in C#" };
            var videoEncoder = new VideoEncoder();

            var mailService = new MailService();
            var messageService = new MessageService();

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

            videoEncoder.Encode(video);

            List<string> plNames = new List<string>();
            plNames.Add("C#"); plNames.Add("Rust"); plNames.Add("Go"); plNames.Add("Swift"); plNames.Add("Perl");
            plNames.Add("C++"); plNames.Add("Python"); plNames.Add("PHP");

            List<string> repeatedPLNames;
            
            repeatedPLNames = plNames.FindAll(delegate (string name) { return name.StartsWith("P"); });
            repeatedPLNames = plNames.FindAll(new Predicate<string>(name => name.Length <= 3 && (name.Contains('#') || name.Contains("++"))));            
        }
    }
}
