using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;
using Microsoft.VisualBasic;
using System.Threading;
using UtilityBot.Services;

namespace UtilityBot.Controllers
{
    public class TextMessageController
    {
        private readonly ITelegramBotClient _telegramClient;
        private readonly IStorage _memoryStorage;
        private readonly IFunction _function;

        public TextMessageController(ITelegramBotClient telegramBotClient, IStorage memoryStorage, IFunction function)
        {
            _telegramClient = telegramBotClient;
            _memoryStorage = memoryStorage;
            _function = function;
        }
        public async Task Handle(Message message, CancellationToken ct)
        {
            Console.WriteLine($"Контроллер {GetType().Name} получил сообщение");
            string userFunction = _memoryStorage.GetSession(message.Chat.Id).FunctionType; // Здесь получим тип функции из сессии пользователя
            switch (message.Text)
            {
                case "/start":

                    var buttons = new List<InlineKeyboardButton[]>();
                    buttons.Add(new[]
                    {
                        InlineKeyboardButton.WithCallbackData($" Посчитать количество знаков" , $"stringLength"),
                        InlineKeyboardButton.WithCallbackData($" Определить сумму чисел" , $"getSumNumbers")
                    });

                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"<b> Бот считает количество знаков в строке.</b> {Environment.NewLine}" +
                        $"{Environment.NewLine}А также считает сумму чисел, написанных через пробел.{Environment.NewLine}", cancellationToken: ct, parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(buttons));

                    break;
                default:
                    _function.Process(userFunction, message, ct);
                    break;
            }
            
        }
    }
}
