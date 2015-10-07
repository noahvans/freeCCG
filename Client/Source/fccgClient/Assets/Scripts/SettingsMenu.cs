using UnityEngine;
using UnityEngine.UI;

namespace Noahv.Game.Fccg.Client
{
    public class SettingsMenu : MonoBehaviour
    {
        private void Awake()
        {
            // Initialization for the Settings menu
            var dpd_LanguageOpt = this.GetComponentInChildren<Dropdown>();
            dpd_LanguageOpt.value = (int)GameSettings.Current.Language;
            foreach (var btn in this.GetComponentsInChildren<Button>(true))
            {
                switch (btn.name)
                {
                    case "btn_SaveSettings":
                        btn.onClick.AddListener(() =>
                        {
                            GameSettings.Current.Language = (UILanguage)dpd_LanguageOpt.value;
                            GameSettings.Current.Save();
                            this.OnEnable();
                        });
                        break;

                    case "btn_ExitSettings":
                        btn.onClick.AddListener(() =>
                        {
                            var pnl_MainMenu = GameObject.Find("Canvas").transform.Find("pnl_MainMenu").gameObject;
                            this.gameObject.SetActive(false);
                            pnl_MainMenu.SetActive(true);
                        });
                        break;

                    case "btn_About":
                        btn.onClick.AddListener(() =>
                        {
                            var pnl_AboutWindow = GameObject.Find("Canvas").transform.Find("pnl_AboutWindow").gameObject;
                            this.gameObject.SetActive(false);
                            pnl_AboutWindow.SetActive(true);
                        });
                        break;
                }
            }
            this.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            // Initialization for the Settings menu
            foreach (var btn in this.GetComponentsInChildren<Button>(true))
            {
                switch (btn.name)
                {
                    case "btn_SaveSettings":
                        btn.GetComponentInChildren<Text>().text = Localization.GetString("btnSaveSettings");
                        break;

                    case "btn_ExitSettings":
                        btn.GetComponentInChildren<Text>().text = Localization.GetString("btnExitSettings");
                        break;

                    case "btn_About":
                        btn.GetComponentInChildren<Text>().text = Localization.GetString("btnAbout");
                        break;
                }
            }
        }
    }
}