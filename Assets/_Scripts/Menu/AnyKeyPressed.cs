using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LP.TickyTacky.Menu
{
    public class AnyKeyPressed : MonoBehaviour
    {
        public GameObject MainMenu;
        void Update()
        {
            if (Input.anyKeyDown)
            {
                MainMenu.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}

