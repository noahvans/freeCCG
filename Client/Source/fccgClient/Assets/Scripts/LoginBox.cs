using UnityEngine;
using UnityEngine.UI;

namespace Noahv.Game.Fccg.Client
{
    public class LoginBox : MonoBehaviour
    {
        // Use this for initialization
        void Awake()
        {
            foreach (var btn in this.GetComponentsInChildren<Button>())
            {
                switch (btn.name)
                {
                    case "btn_Login":
                        btn.onClick.AddListener(() =>
                        {
                        });
                        break;

                    case "btn_ExitLogin":
                        btn.onClick.AddListener(() =>
                        {
                            GameObject.Find("ConnIconCanvas").transform.Find("pnl_Login").gameObject.SetActive(false);
                            GameObject.Find("ConnIconCanvas").transform.Find("btn_ConnectionIcon").gameObject.SetActive(true);
                        });
                        break;
                }
            }
        }

        void OnEnable()
        {
            foreach (var btn in this.GetComponentsInChildren<Button>(true))
            {
                switch (btn.name)
                {
                    case "btn_Login":
                        btn.GetComponentInChildren<Text>().text = Localization.GetString("btnLogin");
                        break;

                    case "btn_ExitLogin":
                        btn.GetComponentInChildren<Text>().text = Localization.GetString("btnExitLogin");
                        break;
                }
            }
            foreach (var btn in this.GetComponentsInChildren<InputField>(true))
            {
                switch (btn.name)
                {
                    case "ipf_UserName":
                        foreach (var txt in btn.GetComponentsInChildren<Text>())
                            if (txt.name == "Placeholder")
                                txt.text = Localization.GetString("plhUsername");
                        break;

                    case "ipf_Password":
                        foreach (var txt in btn.GetComponentsInChildren<Text>())
                            if (txt.name == "Placeholder")
                                txt.text = Localization.GetString("plhPassword");
                        break;
                }
            }
        }
    }
}