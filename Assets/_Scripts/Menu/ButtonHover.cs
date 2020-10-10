using UnityEngine;

namespace LP.TickyTacky.Menu
{
    public class ButtonHover : MonoBehaviour
    {
        public int MenuIndex;
        public GameObject SelectionTills;
        private Selection _Selection;

        private void Start()
        {
            _Selection = SelectionTills.GetComponent<Selection>();
        }

        public void MouseEnter()
        {
            if (_Selection.CurrentPos != MenuIndex)
            {
                _Selection.CurrentPos = MenuIndex;
                _Selection.UpdateSelection();
            }
        }
    } 
}

