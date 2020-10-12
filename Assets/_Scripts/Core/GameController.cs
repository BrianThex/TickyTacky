using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace LP.TickyTacky.Core
{
    public class GameController : MonoBehaviour
    {
        public Image[] GridSpaces;

        public Sprite PlayerX, PlayerO, YouWin, YouLose, EnemyWin, OutOfTime;

        private Sprite PlayerSprite;

        private EnemyAI Enemy;

        public ShittyCounter Counter;

        public Image EndScreen, LossReason;

        public GameObject GamePlay;

        private void OnEnable()
        {
            SetGameControllerReferenceOnButtons();
            Enemy = GetComponent<EnemyAI>();
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
                GameOver("Three In A Row!");
            }

            else if (GridSpaces[3].sprite == PlayerSprite && GridSpaces[4].sprite == PlayerSprite && GridSpaces[5].sprite == PlayerSprite)
            {
                GameOver("Three In A Row!");
            }

            else if (GridSpaces[6].sprite == PlayerSprite && GridSpaces[7].sprite == PlayerSprite && GridSpaces[8].sprite == PlayerSprite)
            {
                GameOver("Three In A Row!");
            }

            else if (GridSpaces[0].sprite == PlayerSprite && GridSpaces[3].sprite == PlayerSprite && GridSpaces[6].sprite == PlayerSprite)
            {
                GameOver("Three In A Row!");
            }

            else if (GridSpaces[1].sprite == PlayerSprite && GridSpaces[4].sprite == PlayerSprite && GridSpaces[7].sprite == PlayerSprite)
            {
                GameOver("Three In A Row!");
            }

            else if (GridSpaces[2].sprite == PlayerSprite && GridSpaces[5].sprite == PlayerSprite && GridSpaces[8].sprite == PlayerSprite)
            {
                GameOver("Three In A Row!");
            }

            else if (GridSpaces[0].sprite == PlayerSprite && GridSpaces[4].sprite == PlayerSprite && GridSpaces[8].sprite == PlayerSprite)
            {
                GameOver("Three In A Row!");
            }

            else if (GridSpaces[2].sprite == PlayerSprite && GridSpaces[4].sprite == PlayerSprite && GridSpaces[6].sprite == PlayerSprite)
            {
                GameOver("Three In A Row!");
            }

            else
            {
                ChangeSides();
            }

        }

        public void ChangeSides()
        {
            PlayerSprite = (PlayerSprite == PlayerX) ? PlayerO : PlayerX;
            Debug.Log("Changing Sides!");
            if (PlayerSprite == PlayerO)
            {
                for (int i = 0; i < Enemy.AvailableSpaces.Count; i++)
                {
                    Enemy.AvailableSpaces[i].GetComponent<Button>().interactable = false;
                }
                Enemy.StartCoroutine(Enemy.PlayEnemyTurn());
            }
            else
            {
                for (int i = 0; i < Enemy.AvailableSpaces.Count; i++)
                {
                    Enemy.AvailableSpaces[i].GetComponent<Button>().interactable = true;
                }
            }
        }

        public void GameOver(string WinCondition)
        {
            for (int i = 0; i < GridSpaces.Length; i++)
            {
                GridSpaces[i].GetComponentInParent<Button>().interactable = false;
            }

            // Stop Counter
            Counter.StopAllCoroutines();
            // Check Why Game ended
            switch (WinCondition)
            {
                case "Three In A Row!": 
                    if (PlayerSprite == PlayerX)
                    {
                        Debug.Log($"Congradulations! You Win!"); //THIS IS A WIN
                        EndScreen.gameObject.SetActive(true);
                        LossReason.gameObject.SetActive(false);
                        EndScreen.sprite = YouWin;
                        GamePlay.SetActive(false);
                    }
                    else
                    {
                        Debug.Log($"The Enemy Has Won!"); //THIS IS A LOSS
                        StartCoroutine(SetLoseScreen(EnemyWin));
                    }
                    break;
                case "Out Of Time!": //THS IS A LOSS
                    Debug.Log($"Looks you are are... {WinCondition}");
                    StartCoroutine(SetLoseScreen(OutOfTime));
                    break;
                case "Tie!": //THIS IS A LOSS
                    Debug.Log(WinCondition);
                    StartCoroutine(SetLoseScreen(EnemyWin));
                    break;
            }

            // Show Correct End Game Screen
            Debug.Log("GameOver!");
        }

        private IEnumerator SetLoseScreen(Sprite reason)
        {
            yield return new WaitForSeconds(2);
            EndScreen.gameObject.SetActive(true);
            LossReason.gameObject.SetActive(true);
            EndScreen.sprite = YouLose;
            LossReason.sprite = reason;
            GamePlay.SetActive(false);
        }
    }
}

