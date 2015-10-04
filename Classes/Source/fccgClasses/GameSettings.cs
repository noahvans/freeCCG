using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Noahv.Game.Fccg
{
    //A class to store game settings
    [System.Serializable]
    public class GameSettings
    {
        private static GameSettings m_Current = null;
        public static GameSettings Current { get { return m_Current; } }

        //Load saved game setting file
        static GameSettings()
        {
            var configFilePath = Application.persistentDataPath + Path.DirectorySeparatorChar + "GameSettings.cnf";
            try
            {
                BinaryFormatter binFormat = new BinaryFormatter();
                if (File.Exists(configFilePath))
                    using (var fsGameSettings = File.OpenRead(configFilePath))
                    {
                        m_Current = (GameSettings)binFormat.Deserialize(fsGameSettings);
                        fsGameSettings.Close();
                    }
                else m_Current = new GameSettings();
            }
            catch
            {
                m_Current = new GameSettings();
            }
        }

        //Save current game settings to file
        public bool Save()
        {
            var configFilePath = Application.persistentDataPath + Path.DirectorySeparatorChar + "GameSettings.cnf";
            try
            {
                BinaryFormatter binFormat = new BinaryFormatter();
                using (var fsGameSettings = File.OpenWrite(configFilePath))
                {
                    binFormat.Serialize(fsGameSettings, this);
                    fsGameSettings.Close();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        //Language
        private UILanguage m_Language = UILanguage.en_US;
        public UILanguage Language
        {
            get { return m_Language; }
            set { m_Language = value; }
        }
    }
}