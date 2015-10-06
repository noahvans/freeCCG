using UnityEngine;
using UnityEngine.UI;

namespace Noahv.Game.Fccg.Client
{
    public class MainMenu : MonoBehaviour
    {
        private void Awake()
        {
            // Initialization for the main menu
            foreach (var btn in this.GetComponentsInChildren<Button>(true))
            {
                switch (btn.name)
                {
                    case "btn_NewTable":
                        break;

                    case "btn_JoinTable":
                        break;

                    case "btn_ManageCards":
                        break;

                    case "btn_SettingsAbout":
                        btn.onClick.AddListener(() =>
                        {
                            var pnl_SettingsMenu = GameObject.Find("Canvas").transform.Find("pnl_SettingsMenu").gameObject;
                            this.gameObject.SetActive(false);
                            pnl_SettingsMenu.SetActive(true);
                        });
                        break;
                }
            }
        }

        private void OnEnable()
        {
            // Initialization for the main menu
            foreach (var btn in this.GetComponentsInChildren<Button>(true))
            {
                switch (btn.name)
                {
                    case "btn_NewTable":
                        btn.GetComponentInChildren<Text>().text = Localization.GetString("btnNewTable");
                        break;

                    case "btn_JoinTable":
                        btn.GetComponentInChildren<Text>().text = Localization.GetString("btnJoinTable");
                        break;

                    case "btn_ManageCards":
                        btn.GetComponentInChildren<Text>().text = Localization.GetString("btnManageCards");
                        break;

                    case "btn_SettingsAbout":
                        btn.GetComponentInChildren<Text>().text = Localization.GetString("btnSettingsAbout");
                        break;
                }
            }
        }
    }
}