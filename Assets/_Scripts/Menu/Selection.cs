using System;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using UnityEngine;

namespace LP.TickyTacky.Menu
{
    public class Selection : MonoBehaviour
    {
        public int CurrentPos = 1;
        public GameObject StartPos, OptionsPos;
        public AudioSource Source;
        public AudioClip Clip;


        private void Update()
        {
            SelectionInputs();
        }

        private void SelectionInputs()
        {
            
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (CurrentPos == 2)
                {
                    CurrentPos -= 1;
                }
                else
                {
                    CurrentPos += 1;
                }
                UpdateSelection();
            }
            else if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (CurrentPos == 1)
                {
                    CurrentPos += 1;
                }
                else
                {
                    CurrentPos -= 1;
                }
                UpdateSelection();
            }
        }

        public void UpdateSelection()
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
            Source.PlayOneShot(Clip);
        }

        private void MakeSelection()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                switch (CurrentPos)
                {
                    case 1:
                        //load start stuff
                        break;
                    case 2:
                        //load options stuff
                        break;
                    default:
                        Debug.Log($"Current Menu Pos:{CurrentPos} can not move in this direction!");
                        break;
                }
            }        
        }
    }
}

