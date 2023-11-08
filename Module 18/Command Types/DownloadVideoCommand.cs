using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace Module18.Types
{
    class DownloadVideoCommand : ICommand
    {
        private readonly string _videoUrl;
        private readonly string _outputFilePath;

        public DownloadVideoCommand(string videoUrl, string outputFilePath)
        {
            _videoUrl = videoUrl;
            _outputFilePath = outputFilePath;
        }

        public async Task ExecuteAsync()
        {
            var youtube = new YoutubeClient().Videos;
            try
            {
                var streamManifest = await youtube.Streams.GetManifestAsync(_videoUrl);
                var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
                var stream = await youtube.Streams.GetAsync(streamInfo);
                if (streamInfo != null)
                {
                    Console.WriteLine($"Загрузка видео {_videoUrl}...");
                    await youtube.Streams.DownloadAsync(streamInfo, $"{_outputFilePath}{streamInfo.Container}");
                    Console.WriteLine($"Видео загружено в {_outputFilePath}{streamInfo.Container}");
                }
            }
            catch (Exception ex)
            {
                // да, этот блок пригодился... ну и практика хорошая
                Console.WriteLine("Возникло исключение! Скорее всего видео недоступно :(");
                Console.WriteLine($"Исключение: {ex.Message}");
                Console.WriteLine($"Метод: {ex.TargetSite}");
                Console.WriteLine($"Трассировка стека: {ex.StackTrace}");
            }
        }
    }

}
