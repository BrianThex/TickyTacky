using System;
using UnityEngine;
using UnityEngine.UI;

namespace LP.TickyTacky.Menu
{
    public class Selection : MonoBehaviour
    {
        public int CurrentPos = 1;
        public GameObject StartPos, OptionsPos;

        private void Update()
        {
            CurrentPos = Mathf.Clamp(CurrentPos, 1, 2);
            SelectionInputs();
        }

        private void SelectionInputs()
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                CurrentPos += 1;
                UpdateSelection();
            }
            else if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                CurrentPos -= 1;
                UpdateSelection();
            }
        }

        private void UpdateSelection()
        {
            switch (CurrentPos)
            {
                case 1:
                    transform.position = new Vector3(transform.position.x, StartPos.transform.position.y, transform.position.z);
                    break;
                case 2:
                    transform.position = new Vector3(transform.position.x, OptionsPos.transform.position.y, transform.position.z);
                    break;
                default:
                    Debug.Log($"Current Menu Pos:{CurrentPos} can not move in this direction!");
                    break;

            }
        }
    }
}

