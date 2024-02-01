using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bankBallence : MonoBehaviour
{
    
    public static GameObject panel;
    public TextMeshProUGUI mtext;
    deliverySpawn spawn;
   public GameObject spawnPoint;

    public float ballance;
   public float spend;
   public float add;


    // Start is called before the first frame update
    void Start()
    {
        TextMesh mtext = GetComponent<TextMesh>();
        spawn = spawnPoint.GetComponent<deliverySpawn>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayBallance()
    {
        mtext.text = "You have: " + ballance.ToString();
    }
    public void purchasCup()
    {
        spend = 25;
        if (ballance >= spend)
        {
            spawn.SpawnCup();
            SpendMoney(ballance, spend);
        }
        else { mtext.text = "insufficient funds!!! \n you only have :" + ballance.ToString() + " left in the bank :( "; }
    }
        public void purchasBubble()
    {
        spend = 15;
        if (ballance >= spend)
        {
            spawn.SpawnIngredients();
        SpendMoney(ballance, spend);
        }
        else { mtext.text = "insufficient funds!!! \n you only have :" + ballance.ToString() +" left in the bank :( "; }
    }
    public void addFunds()
    {
        add = 70;

        AddMoney(ballance, add);
        mtext.text = ballance.ToString();
    }

    public void AddMoney(float bal, float add)
    {

        ballance += add;
        Debug.Log(ballance);
        mtext.text = ballance.ToString();
    }

    public void SpendMoney(float bal, float spend)
    {
        
        ballance -= spend;
        mtext.text = "you have: "+ballance.ToString()+ ".\n left in the bank";
        Debug.Log(ballance);

    }
}
