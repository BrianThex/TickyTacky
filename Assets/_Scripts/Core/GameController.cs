using LP.TickyTacky.Core.GamePlay;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;
using UnityEngineInternal;

namespace LP.TickyTacky.Core
{
    public class GameController : MonoBehaviour
    {
        public Image[] GridSpaces;

        public Sprite PlayerX, PlayerO;

        private Sprite PlayerSprite;

        private void Awake()
        {
            SetGameControllerReferenceOnButtons();
            PlayerSprite = PlayerX;
        }

        private void SetGameControllerReferenceOnButtons()
        {
            for (int i = 0; i < GridSpaces.Length; i++)
            {
                GridSpaces[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
            }
        }

        public Sprite GetPlayerSprite()
        {
            return PlayerSprite;
        }

        public void EndTurn()
        {
            if (GridSpaces[0].sprite == PlayerSprite && GridSpaces[1].sprite == PlayerSprite && GridSpaces[2].sprite == PlayerSprite)
            {
                GameOver();
            }

            if (GridSpaces[3].sprite == PlayerSprite && GridSpaces[4].sprite == PlayerSprite && GridSpaces[5].sprite == PlayerSprite)
            {
                GameOver();
            }

            if (GridSpaces[6].sprite == PlayerSprite && GridSpaces[7].sprite == PlayerSprite && GridSpaces[8].sprite == PlayerSprite)
            {
                GameOver();
            }

            if (GridSpaces[0].sprite == PlayerSprite && GridSpaces[3].sprite == PlayerSprite && GridSpaces[6].sprite == PlayerSprite)
            {
                GameOver();
            }

            if (GridSpaces[1].sprite == PlayerSprite && GridSpaces[4].sprite == PlayerSprite && GridSpaces[7].sprite == PlayerSprite)
            {
                GameOver();
            }

            if (GridSpaces[2].sprite == PlayerSprite && GridSpaces[5].sprite == PlayerSprite && GridSpaces[8].sprite == PlayerSprite)
            {
                GameOver();
            }

            if (GridSpaces[0].sprite == PlayerSprite && GridSpaces[4].sprite == PlayerSprite && GridSpaces[8].sprite == PlayerSprite)
            {
                GameOver();
            }

            if (GridSpaces[2].sprite == PlayerSprite && GridSpaces[4].sprite == PlayerSprite && GridSpaces[6].sprite == PlayerSprite)
            {
                GameOver();
            }
            ChangeSides();
        }

        public void ChangeSides()
        {
            PlayerSprite = (PlayerSprite == PlayerX) ? PlayerO : PlayerX;
            Debug.Log("Changing Sides!");
        }

        public void GameOver()
        {
            for (int i = 0; i < GridSpaces.Length; i++)
            {
                GridSpaces[i].GetComponentInParent<Button>().interactable = false;
            }

            Debug.Log("GameOver!");
        }
    }
}

