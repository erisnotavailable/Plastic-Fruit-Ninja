using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    // Global Vars
    public GlobalVars.FruitType type;
    public Sprite raw;
    private string nameInit = "W";
    private bool hasCut = false;

    // Start is called before the first frame update
    void Start()
    {
        FruitLauncher parentScript = GameObject.Find("FruitLauncher").GetComponent<FruitLauncher>();
        parentScript.numOfChildIncrement();
        // assign fruit's name
        nameInit = type.ToString().ToLower().Substring(0, 1);
        Debug.Log("Initial: " + nameInit);
        // load and change fruit's sprite
        // Sprite raw = Resources.Load<Sprite>("Sprites/" + type.ToString().ToLower());
        Sprite raw = Resources.Load<Sprite>("watermelon");
        GetComponent<SpriteRenderer>().sprite = raw;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        Debug.Log("Sprites/" + type.ToString().ToLower());
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
