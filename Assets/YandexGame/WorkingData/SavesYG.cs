
using System.Collections.Generic;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        public int money = 25;
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];
        public float sensitivity;
        // Ваши сохранения
        public Dictionary<string, bool> videoStates = new Dictionary<string, bool>();
        public string[] VideoName = new string[20];
        public bool[] VideoBool = new bool[20];
        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны
        public string[] KeysToSave = new string[100];
        // Инициализация полей public bool[] KeyStates = new bool[100];
        public bool[] KeyStates = new bool[100];
        public SavesYG()
        {
            if (YandexGame.EnvironmentData.isMobile)
            {
                sensitivity = 100;
            }
            else
            {
                sensitivity = 100;
            }
    
                VideoName = new string[20];
                VideoBool = new bool[20];

        }
    }

}
