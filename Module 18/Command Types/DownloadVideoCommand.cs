using YoutubeExplode;
using YoutubeExplode.Videos;
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
            // послесловие с вопросом, у меня если бы я не сделал вот этот прикол со скачивание в "загрузки" юзера, то видео бы скачивалось в ...SkillFactory\Module 18\bin\Debug\net6.0
            // вроде как и не проблема, но кажется мне что, с учетом того, что в уроках такие вопросы прямо в корне работали и все скачивали, а не на три уровня ниже в bin\Debug\net6
            // короче вопрос как сделать проще или вот так как есть норм и катит?
        }
    }

}
