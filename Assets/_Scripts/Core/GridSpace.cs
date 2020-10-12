using UnityEngine;
using UnityEngine.UI;

namespace LP.TickyTacky.Core
{
    public class GridSpace : MonoBehaviour
    {
        public Button button;
        public Image buttonImage;
        public Sprite playerSide;

        private GameController gameController;

        public void SetGameControllerReference(GameController controller)
        {
            gameController = controller;
        }
        public void SetSpace()
        {
            buttonImage.sprite = gameController.GetPlayerSprite();
            buttonImage.color = new Color32 (0, 0, 0, 255);
            button.interactable = false;
            gameController.EndTurn();
        }
    }
}

