using System;
using System.Collections.Generic;
using System.Threading;

namespace CSLab.CoreTypes.Delegates
{
    public class VideoEventArgs: EventArgs
    {
        public Video Video { get; set; }
    }

    public class VideoEncoder
    {
        
        public delegate void VideoEncoderEventHandler(object source, VideoEventArgs args);        
        public event VideoEncoderEventHandler VideoEncoded;
        //public event EventHandler<VideoEventArgs> VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine($"Encoding video ({video.Title})...");
            Thread.Sleep(3000);

            OnVideoEncoded(video);
        }

        protected virtual void OnVideoEncoded(Video video)
        {
            VideoEncoded?.Invoke(this, new VideoEventArgs() { Video = video});
        }
    }
}
