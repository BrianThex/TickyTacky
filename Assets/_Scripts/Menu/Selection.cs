using System;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using UnityEngine;

namespace LP.TickyTacky.Menu
{
    public class Selection : MonoBehaviour
    {
        public int CurrentPos = 0;
        public GameObject[] MenuPosisitions;
        public AudioSource Source;
        public AudioClip Clip;
        public bool MoveOnX = false, MoveOnY = false;


        private void Update()
        {
            SelectionInputs();
        }

        private void SelectionInputs()
        {
            if (MoveOnY)
            {
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (CurrentPos != MenuPosisitions.Length - 1)
                    {
                        CurrentPos += 1;
                    }
                    else
                    {
                        CurrentPos = 0;
                    }
                    UpdateSelection();
                }
                else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (CurrentPos != 0)
                    {
                        CurrentPos -= 1;
                    }
                    else
                    {
                        CurrentPos = MenuPosisitions.Length - 1;
                    }
                    UpdateSelection();
                }
            }
            else if (MoveOnX)
            {
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (CurrentPos != MenuPosisitions.Length - 1)
                    {
                        CurrentPos += 1;
                    }
                    else
                    {
                        CurrentPos = 0;
                    }
                    UpdateSelection();
                }
                else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (CurrentPos != 0)
                    {
                        CurrentPos -= 1;
                    }
                    else
                    {
                        CurrentPos = MenuPosisitions.Length - 1;
                    }
                    UpdateSelection();
                }
            }
            else
            {
                Debug.Log("Menue till not moving on any axis!");
            }


        }

        public void UpdateSelection()
        {
            if (MoveOnX)
            {
                transform.position = new Vector3(MenuPosisitions[CurrentPos].transform.position.x, transform.position.y, transform.position.z);

            }
            else if (MoveOnY)
            {
                transform.position = new Vector3(transform.position.x, MenuPosisitions[CurrentPos].transform.position.y, transform.position.z);

            }
            PlaySound();
        }

        private void MakeSelection()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                
            }        
        }

        public void PlaySound()
        {
            Source.PlayOneShot(Clip);

        }
    }
}

