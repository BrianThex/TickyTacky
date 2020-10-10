using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace LP.TickyTacky.Core
{
    public class ShittyCounter : MonoBehaviour
    {
        private Image Image;
        public Image MinuteNumber;
        public Sprite[] Sprites;
        private int CurrentImage = 0;

        private void Start()
        {
            Image = GetComponent<Image>();
            StartCoroutine(CountDownTimer());
        }

        IEnumerator CountDownTimer()
        {
            if(CurrentImage != Sprites.Length)
            {
                if (CurrentImage >= 59)
                {
                    MinuteNumber.color = new Color32(0,0,0,0);
                }
                Image.sprite = Sprites[CurrentImage];
                yield return new WaitForSeconds(1);
                CurrentImage += 1;
                StartCoroutine(CountDownTimer());
            }
            yield return new WaitForEndOfFrame();
        }
    }
}

