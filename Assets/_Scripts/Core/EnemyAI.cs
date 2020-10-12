using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LP.TickyTacky.Core
{
    public class EnemyAI : MonoBehaviour
    {
        private GameController Controller;
        public List<Image> AvailableSpaces;
        private void OnEnable()
        {
            Controller = GetComponent<GameController>();

            SetEnemyAIReferenceOnButtons();

            foreach(Image i in Controller.GridSpaces)
            {
                AvailableSpaces.Add(i);
                i.gameObject.GetComponent<Button>().interactable = true;
            }
        }

        private void SetEnemyAIReferenceOnButtons()
        {
            for (int i = 0; i < Controller.GridSpaces.Length; i++)
            {
                Controller.GridSpaces[i].GetComponentInParent<GridSpace>().SetEnemyAIReference(this);
            }
        }

        public IEnumerator PlayEnemyTurn()
        {
            yield return new WaitForSeconds(1);

            if (AvailableSpaces.Count != 0)
            {
                int i = Random.Range(0, AvailableSpaces.Count);
                AvailableSpaces[i].gameObject.GetComponent<GridSpace>().SetSpace();
            }
            else
            {
                Controller.GameOver("Tie!");
            }
        }
    }
}

