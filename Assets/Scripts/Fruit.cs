using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    // Global Vars
    public string nameInit = "W";
    private bool hasCut = false;

    // Start is called before the first frame update
    void Start()
    {
        FruitLauncher parentScript = GameObject.Find("FruitLauncher").GetComponent<FruitLauncher>();
        parentScript.numOfChildIncrement();
    }

    // Update is called once per frame
    void Update()
    {
        // Detect key pressed, do nothing for keys other than WASD
        if (!hasCut)
        {
            if (Input.GetKeyDown(nameInit.ToLower()))
            {
                hasCut = true;
                Debug.Log("Correct");
            }
            else if (Input.GetKeyDown(KeyCode.W) ||
              Input.GetKeyDown(KeyCode.A) ||
              Input.GetKeyDown(KeyCode.S) ||
              Input.GetKeyDown(KeyCode.D))
            {
                hasCut = true;
                Debug.Log("Incorrect");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collide with border");
        FruitLauncher parentScript = GameObject.Find("FruitLauncher").GetComponent<FruitLauncher>();
        parentScript.numOfChildDecrement();
        Object.Destroy(this.gameObject);
        Debug.Log("Destroyed cloned `Fruit`");
    }
}
