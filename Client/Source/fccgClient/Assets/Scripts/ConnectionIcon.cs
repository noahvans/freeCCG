using UnityEngine;
using UnityEngine.UI;
using Noahv.Game.Fccg;

namespace Noahv.Game.Fccg.Client
{
    public class ConnectionIcon : MonoBehaviour
    {
        private int m_hideOnlineIconTimer;

        protected User m_CurrentUser = null;

        public Sprite OnlineIcon;
        public Sprite OfflineIcon;
        public int HideOnlineIconTimer = 10000;

        // Use this for initialization
        void Awake()
        {
            m_hideOnlineIconTimer = HideOnlineIconTimer;

            var btnConnection = this.GetComponentInChildren<Button>();
            btnConnection.image.sprite = (m_CurrentUser != null && m_CurrentUser.Connected) ? OnlineIcon : OfflineIcon;
            //TODO: hide after keeping online 10 sec.

            btnConnection.onClick.AddListener(() =>
            {
                transform.Find("pnl_Login").gameObject.SetActive(true);
                btnConnection.gameObject.SetActive(false);
            });

            transform.Find("pnl_Login").gameObject.SetActive(false);
        }

        void Update()
        {
            var btn_ConnectionIcon = GameObject.Find("ConnIconCanvas").transform.Find("btn_ConnectionIcon").GetComponent<Button>();
            if (m_CurrentUser != null && m_CurrentUser.Connected)
            {
                if (btn_ConnectionIcon.image.sprite == OfflineIcon)
                    btn_ConnectionIcon.image.sprite = OnlineIcon;
                m_hideOnlineIconTimer = m_hideOnlineIconTimer >= 0 ? m_hideOnlineIconTimer - 1 : 0;
                if (m_hideOnlineIconTimer == 0)
                    btn_ConnectionIcon.gameObject.SetActive(false);
            }
            else
            {
                btn_ConnectionIcon.image.sprite = OfflineIcon;
                m_hideOnlineIconTimer = HideOnlineIconTimer;
            }
        }
    }
}