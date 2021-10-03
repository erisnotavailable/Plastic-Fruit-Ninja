using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    // Global Vars
    public GlobalVars.FruitType type;
    public float minScale = 0.3f;
    public float maxScale = 0.5f;
    private string nameInit = "W";
    private bool hasCut = false;
    private Sprite raw;
    private Sprite cut;

    // Start is called before the first frame update
    void Start()
    {
        FruitLauncher parentScript = GameObject.Find("FruitLauncher").GetComponent<FruitLauncher>();
        parentScript.numOfChildIncrement();
        // assign fruit's name
        nameInit = type.ToString().ToLower().Substring(0, 1);
        Debug.Log("Initial: " + nameInit);
        // load and change fruit's sprite
        raw = Resources.Load<Sprite>(type.ToString().ToLower());
        cut = Resources.Load<Sprite>(type.ToString().ToLower() + "_cut");
        GetComponent<SpriteRenderer>().sprite = raw;
        Debug.Log("Sprites/" + type.ToString().ToLower());
        // scale down the sprite
        float scale = Random.Range(minScale, maxScale);
        GetComponent<Transform>().localScale = new Vector3(scale, scale, scale);
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
                GetComponent<SpriteRenderer>().sprite = cut;
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
