﻿using UnityEngine;

namespace Noahv.Game.Fccg
{
    public class ClientMain : MonoBehaviour
    {
        // Use this for initialization
        private void Start()
        {
            //Hide useless game objects
            GameObject.Find("pnl_SettingsMenu").SetActive(false);
        }
    }
}