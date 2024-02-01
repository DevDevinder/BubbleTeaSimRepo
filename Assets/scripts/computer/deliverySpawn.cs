using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deliverySpawn : MonoBehaviour
{
    [SerializeField] GameObject ingredient;
    [SerializeField] GameObject parent;
    [SerializeField] GameObject cup;
  //  [SerializeField] GameObject bankAccount;
    public bankBallence account;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SpendMoney()
    {
       // account.spend = 10;
     //   account.SpendMoney(account.ballance, account.spend);
        
        
            SpawnIngredients();
        
    }

    public void SpawnIngredients()
    {
        
        Instantiate(ingredient, parent.transform.position, Quaternion.Euler(0,0,0));
        Debug.Log("spawnd");
    }
    public void SpawnCup()
    {
        Instantiate(cup, parent.transform.position + new Vector3(0.5f,0f,0f), Quaternion.Euler(0, 0, 0));
    }


}
