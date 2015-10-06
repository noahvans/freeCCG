using System.Collections.Generic;
using UnityEngine;

namespace Noahv.Game.Fccg.Client
{
    public enum UILanguage
    {
        en_US = 0,
        zh_CN = 1
        //add more languages here to support them
    }

    public class Localization
    {
        private static List<Dictionary<string, string>> m_locStrings = null;

        static Localization()
        {
            var lData = Resources.Load("locStr").ToString().Split('\n');
            m_locStrings = new List<Dictionary<string, string>>();
            for (int i = 0; i < 2; i++)//Note to change the number '2' while localizing new languages
            {
                m_locStrings.Add(new Dictionary<string, string>(lData.Length));
                foreach (var lRow in lData)
                {
                    var lRowData = lRow.Split('\t');
                    m_locStrings[i].Add(lRowData[0], lRowData[i + 1]);
                }
            }
        }

        //Call this to get localized strings
        public static string GetString(string locKeyName)
        {
            if (m_locStrings == null ||
                locKeyName == null ||
                locKeyName == string.Empty)
                return string.Empty;
            var currentDic = m_locStrings[(int)GameSettings.Current.Language];
            if (currentDic.ContainsKey(locKeyName))
                return currentDic[locKeyName];
            else
                return string.Empty;
        }
    }
}