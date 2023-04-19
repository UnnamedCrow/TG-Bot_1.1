using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;
using Telegram.Bot;
using System.Threading.Tasks;
using TG_Bot_1._1.Controllers;
using TG_Bot_1._1.Services;
using TG_Bot_1._1.Configuration;

namespace TG_Bot_1._1
{
    public class Program
    {
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            // Объект, отвечающий за постоянный жизненный цикл приложения
            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) => ConfigureServices(services)) // Задаем конфигурацию
                .UseConsoleLifetime() // Позволяет поддерживать приложение активным в консоли
                .Build(); // Собираем

            Console.WriteLine("Сервис запущен");
            // Запускаем сервис

                await host.RunAsync();

            Console.WriteLine("Сервис остановлен");
        }

        static void ConfigureServices(IServiceCollection services)
        {
            // Инициализация конфигурации
            AppSettings appSettings = BuildAppSettings();
            services.AddSingleton(appSettings);
            // Регистрируем объект TelegramBotClient c токеном подключения
            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient(appSettings.BotToken));
            // Подключаем контроллеры сообщений и нажатия кнопок
            services.AddTransient<DefaultMessageController>();
            services.AddTransient<VoiceMessageController>();
            services.AddTransient<TextMessageController>();
            services.AddTransient<InlineKeyboardController>();
            
            // Регистрируем хранилище сессий
            services.AddSingleton<IStorage, MemoryStorage>();
            // Регистрируем сервис для скачивания файла
            services.AddSingleton<IFileHandler, AudioFileHandler>();
            // Регистрируем постоянно активный сервис бота
            services.AddHostedService<Bot>();
        }
        static AppSettings BuildAppSettings()
        {
            return new AppSettings()
            {
                BotToken = "6258311066:AAHsijI3L05-PYva_1snYTSpzudrV9eVlQg",
                DownloadsFolder = "C:\\Users\\Professional\\Downloads",               
                AudioFileName = "audio",
                InputAudioFormat = "ogg",
                OutputAudioFormat = "wav",
                InputAudioBitrate = 48000
            };
        }
    }
}