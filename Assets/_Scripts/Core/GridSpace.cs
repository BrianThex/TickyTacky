using UnityEngine;
using UnityEngine.UI;

namespace LP.TickyTacky.Core
{
    public class GridSpace : MonoBehaviour
    {
        public Button button;
        public Image buttonImage;
        public Sprite playerSide;
        public AudioSource Source;
        public AudioClip Clip;

        private GameController GameController;
        private EnemyAI Enemy;

        private void OnEnable()
        {
            buttonImage.sprite = null;
            buttonImage.color = new Color32(255, 255, 255, 1);
        }
        public void SetGameControllerReference(GameController controller)
        {
            GameController = controller;
        }
        public void SetEnemyAIReference(EnemyAI ai)
        {
            Enemy = ai;
        }
        public void SetSpace()
        {
            Enemy.AvailableSpaces.Remove(buttonImage);
            buttonImage.sprite = GameController.GetPlayerSprite();
            buttonImage.color = new Color32 (0, 0, 0, 255);
            PlaySound();
            button.interactable = false;
            GameController.EndTurn();
        }

        public void PlaySound()
        {
            Source.PlayOneShot(Clip);
        }
    }
}

