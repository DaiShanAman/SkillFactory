using YoutubeExplode;
using YoutubeExplode.Videos;

namespace Module18.Types
{
    class GetVideoInfoCommand : ICommand
    {
        private readonly string _videoUrl;
        private Video _video;

        public GetVideoInfoCommand(string videoUrl)
        {
            _videoUrl = videoUrl;
        }

        public async Task ExecuteAsync()
        {
            var videos = new YoutubeClient().Videos;
            
            _video = await videos.GetAsync(_videoUrl);
            Console.WriteLine($"Название видео: {_video.Title}");
            Console.WriteLine($"Описание: {_video.Description}");
        }

        public Video GetVideo()
        {
            return _video;
        }
    }
}
