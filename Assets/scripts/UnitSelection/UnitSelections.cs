using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets
{
    public class UnitSelections : MonoBehaviour
    {
        public List<GameObject> unitList = new List<GameObject>();
        public List<GameObject> unitsSelected = new List<GameObject>();

        private static UnitSelections _instance;

        public static UnitSelections Instance { get { return _instance; } }


        void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        public void ClickSelect(GameObject unitToAdd)
        {
            DeSelectAll();
            unitsSelected.Add(unitToAdd);
        }

        public void ShiftClickSelect(GameObject unitToAdd)
        {
            if (!unitsSelected.Contains(unitToAdd))
            {
                unitsSelected.Add(unitToAdd);

            }
            else
            {
                unitsSelected.Remove(unitToAdd);
            }
        }

        public void DragSelect(GameObject unitToAdd)
        {
            //TODO: Add a drag select to select all units in a drawn box
        }

        public void DeSelectAll()
        {
            unitsSelected.Clear();
        }


        public void DeSelect(GameObject unitToAdd)
        {
            unitsSelected.Remove(unitToAdd);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
