
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
        public int money = 1;
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];
        public float sensitivity = 100f;
        // Ваши сохранения
        public Dictionary<string, bool> videoStates = new Dictionary<string, bool>();

        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны

        // Инициализация полей
        public SavesYG()
        {
            // Пример инициализации по умолчанию
            openLevels[1] = true;
            videoStates = new Dictionary<string, bool>();
        }
    }

}
