using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    // Global Vars
    private string nameInit = "W";

    // Start is called before the first frame update
    void Start()
    {
        FruitLauncher parentScript = GameObject.Find("FruitLauncher").GetComponent<FruitLauncher>(); 
        parentScript.numOfChildIncrement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Collide with border");
        FruitLauncher parentScript = GameObject.Find("FruitLauncher").GetComponent<FruitLauncher>(); 
        parentScript.numOfChildDecrement();
        Object.Destroy(this.gameObject);
        Debug.Log("Destroyed cloned `Fruit`");
    }
}
