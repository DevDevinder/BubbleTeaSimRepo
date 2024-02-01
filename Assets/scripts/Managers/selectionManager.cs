using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectionManager : MonoBehaviour
{//comment
    GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
    }


    // Update is called once per frame
    void Update()
    {
        accessPC();
    }

    void accessPC()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1.5f))
            {
                pccheck phit = hit.collider.GetComponent<pccheck>();
                if (phit != null)
                {
                    computer.isOnPC = true;

                }
            }
        }
    }
}

