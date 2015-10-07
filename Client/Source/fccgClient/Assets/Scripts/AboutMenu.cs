using UnityEngine;
using UnityEngine.UI;

namespace Noahv.Game.Fccg.Client
{
    public class AboutMenu : MonoBehaviour
    {
        private void Awake()
        {
            // Initialization for the About window
            this.GetComponentInChildren<Button>().onClick.AddListener(() =>
            {
                var pnl_SettingsMenu = GameObject.Find("Canvas").transform.Find("pnl_SettingsMenu").gameObject;
                this.gameObject.SetActive(false);
                pnl_SettingsMenu.SetActive(true);
            });
            this.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            this.transform.Find("pnl_About").GetComponentInChildren<Text>().text = Localization.GetString("txtAbout");
            this.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = Localization.GetString("btnCloseAbout");
        }
    }
}