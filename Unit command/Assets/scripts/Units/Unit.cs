using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Assets 
{ 
public class Unit : MonoBehaviour
{
    [SerializeField] public string faction;
    [SerializeField] private string unitName;
    [SerializeField] private decimal moralLevel;
    [SerializeField] private int soldierCount;
    [SerializeField] private int vehivleCount;
    [SerializeField] private decimal foodCount;
    [SerializeField] private int ammoCount;
    [SerializeField] private decimal fuelCount;
    [SerializeField] private string order;
    [SerializeField] private BoxCollider2D boxCollider;

        //hours of combat experience the unit has combined
        //looses experience if it gains new recruits
        [SerializeField] private BoxCollider2D experience;


    

    [SerializeField] private string speed;



        private bool EnemyInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size,
            0, Vector2.positiveInfinity, 10);
        return hit.collider != null;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center, boxCollider.bounds.size);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyInSight()) 
        {
            //attack
        }
        
    }




}


}