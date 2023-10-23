using Module18.Types;
using Module18;

class Program
{
    static async Task Main(string[] args)
    {
        var videoUrl = "https://youtu.be/tE6tltXNpRU?si=5cNbiqempOxlmEJ7";
        var commandInvoker = new CommandInvoker();

        // получение информации
        var getVideoInfoCommand = new GetVideoInfoCommand(videoUrl);
        commandInvoker.SetCommand(getVideoInfoCommand);

        await commandInvoker.RunAsync();

        // скачивание
        var downloadVideoCommand = new DownloadVideoCommand(getVideoInfoCommand.GetVideo(), "video.mp4");
        commandInvoker.SetCommand(downloadVideoCommand);

        await commandInvoker.RunAsync();
    }
}
