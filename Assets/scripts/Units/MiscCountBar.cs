using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class MiscCountBar : MonoBehaviour
    {


        //GameObject.GetComponent("Unit") as Unit).soldierCount

        // Start is called before the first frame update
        [SerializeField] public Slider slider;

        [SerializeField] public GameObject unit;

        public void SetMaxMisc(int miscCount)
        {
            slider.maxValue = miscCount;
            slider.value = miscCount;


        }

        public void SetMiscCount(int miscCount)
        {
            slider.value = miscCount;
        }


        void Start()
        {
            //unit.GetComponent<Unit>().soldierCount = 1;


            
            if ((unit.GetComponent("Unit") as Unit) != null)
            {

                if ((slider.name).Equals("SoldierCountSlider"))
                {
                    SetMaxMisc((unit.GetComponent("Unit") as Unit).soldierCount);
                }
                else if ((slider.name).Equals("AmmoCountSlider"))
                {
                    SetMaxMisc((unit.GetComponent("Unit") as Unit).ammoCount);
                }

            }
            


        }

        void Update()
        {
            //SoldierCountSlider

            if ((unit.GetComponent("Unit") as Unit) != null)
            {
                if ((slider.name).Equals("SoldierCountSlider"))
                {
                    SetMiscCount((unit.GetComponent("Unit") as Unit).soldierCount);
                }
                else if ((slider.name).Equals("AmmoCountSlider")) 
                {
                    SetMiscCount((unit.GetComponent("Unit") as Unit).ammoCount);
                }
                


            }
            

        }


    }

}
