﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ConsoleApp1
{
    internal class Program
    {

        //static async Task HandleUpdteAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        //{
        //    if (update.Message is not { } message)
        //        return;
        //    if (message.Text is not { } messageText)
        //        return;
        //    var chatId = message.Chat.Id;

        //    Console.WriteLine($"Получно '{messageText}' сообщение в чате {chatId}.");

        //    Message sentMessage = await botClient.SendTextMessageAsync(
        //        chatId: chatId,
        //        text: "Вы написали:\n" + messageText,
        //        cancellationToken: cancellationToken);

        //    if (message.Text == "Проверка" | message.Text == "проверка")
        //    {
        //        await botClient.SendTextMessageAsync(
        //        chatId: chatId,
        //        text: "Проверка прошла успешно.",
        //        cancellationToken: cancellationToken);
        //    }
        //}


        static async Task HandleUpdteAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Only process Message updates: https://core.telegram.org/bots/api#message
            if (update.Message is not { } message)
                return;
            // Only process text messages
            if (message.Text is not { } messageText)
                return;

            var chatId = message.Chat.Id;

            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

            // Echo received message text
            Message sentMessage = await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "You said:\n" + messageText,
                cancellationToken: cancellationToken);
        }

        static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException =>
                $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}".ToString()
            };
            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            var result = await client.GetAsync("https://localhost:7178/api/User");
            Console.WriteLine(result);

            var test = await result.Content.ReadAsStringAsync();
            Console.WriteLine(test);
            Domain.Models.User[] user = JsonConvert.DeserializeObject<Domain.Models.User[]>(test);
            foreach(var good in user)
            {
                Console.WriteLine(good.IdUser + " " + good.UserLogin + " " + good.IsDeleted);
            }
            var botClient = new TelegramBotClient("6106201495:AAFFD10Hq56Ce55f-uQuhnGEhD7kfzayibA");
            using CancellationTokenSource cts = new();

            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };

            botClient.StartReceiving(
                updateHandler: HandleUpdteAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token);

            var me = await botClient.GetMeAsync();

            Console.WriteLine($"Начало диолога для @{me.Username}");
   
            Console.ReadLine();

            cts.Cancel();
        }
    }
}