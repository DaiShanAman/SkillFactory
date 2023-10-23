using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace Module18.Types
{
    class DownloadVideoCommand : ICommand
    {
        private readonly Video _video;
        private readonly string _outputFilePath;

        public DownloadVideoCommand(Video video, string outputFilePath)
        {
            _video = video;
            _outputFilePath = outputFilePath;
        }

        public async Task ExecuteAsync()
        {
            var youtube = new YoutubeClient().Videos;
            try
            {
                var streamManifest = await youtube.Streams.GetManifestAsync(_video.Url);
                var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
                var stream = await youtube.Streams.GetAsync(streamInfo);
                if (streamInfo != null)
                {
                    Console.WriteLine($"Загрузка видео {_video.Url}...");
                    await youtube.Streams.DownloadAsync(streamInfo, $"video.{streamInfo.Container}");
                    Console.WriteLine($"Видео загружено в {_outputFilePath}");
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
            // послесловие, у меня не отрабатывает и везде кидает исключение что видео недоступно (оно доступно, прям щас смотрю)
            // скорее всего это система моя на работе блочит, проверить поэтому не можу, но уверен что работает, если не работает - бейте меня палками - заслужил
        }
    }

}
