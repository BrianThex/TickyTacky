using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace LP.TickyTacky.Core
{
    public class ShittyCounter : MonoBehaviour
    {
        private Image Image;
        public Image MinuteNumber;
        public Sprite[] Sprites;
        private int CurrentImage;

        public GameController Controller;

        private void OnEnable()
        {
            Image = GetComponent<Image>();
            CurrentImage = 0;
            StartCoroutine(CountDownTimer());
        }

        private IEnumerator CountDownTimer()
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
            else
            {
                Controller.GameOver("Out Of Time!");

            }
            yield return new WaitForEndOfFrame();
        }
    }
}

