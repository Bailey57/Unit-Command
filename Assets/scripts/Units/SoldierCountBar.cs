using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class SoldierCountBar : MonoBehaviour
    {


        //GameObject.GetComponent("Unit") as Unit).soldierCount

        // Start is called before the first frame update
        [SerializeField] public Slider slider;

        [SerializeField] public GameObject unit;

        public void SetMaxSoldiers(int soldierCount)
        {
            slider.maxValue = soldierCount;
            slider.value = soldierCount;


        }

        public void SetSoldierCount(int soldierCount)
        {
            slider.value = soldierCount;
        }


        void Start()
        {
            //unit.GetComponent<Unit>().soldierCount = 1;


            
            if ((unit.GetComponent("Unit") as Unit) != null)
            {
                SetMaxSoldiers((unit.GetComponent("Unit") as Unit).soldierCount);


            }
            


        }

        void Update()
        {
            
            if ((unit.GetComponent("Unit") as Unit) != null)
            {
                SetSoldierCount((unit.GetComponent("Unit") as Unit).soldierCount);


            }
            

        }


    }

}
