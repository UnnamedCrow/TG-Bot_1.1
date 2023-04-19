﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TG_Bot_1._1.Configuration
{
    public class AppSettings
    {
        /// <summary>
        /// Токен Telegram API
        /// </summary>
        public string BotToken { get; set; }

        /// <summary>
        /// Папка загрузки аудио файлов
        /// </summary>
        public string DownloadsFolder { get; set; }
        /// <summary>
        /// Имя файла при загрузке
        /// </summary>
        public string AudioFileName { get; set; }
        /// <summary>
        /// Формат аудио при загрузке
        /// </summary>
        public string InputAudioFormat { get; set; }

        public string OutputAudioFormat { get; set; }
        /// <summary>
        /// Битрейт аудио при загрузке
        /// </summary>
        public float InputAudioBitrate { get; set; }
    }
}
