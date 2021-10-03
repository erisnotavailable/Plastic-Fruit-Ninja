using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FruitLauncher : MonoBehaviour
{
    // Global Vars
    public GameObject fruitList;
    public float velocityXMin = 300f;
    public float velocityXMax = 700f;
    public float velocityYMin = 300f;
    public float velocityYMax = 700f;
    private int numOfChild = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (numOfChild == 0)
        {
            GameObject fruit = Instantiate(fruitList,
                transform.position, transform.rotation);
            fruit.GetComponent<Renderer>().enabled = true;
            fruit.GetComponent<Fruit>().enabled = true;
            fruit.GetComponent<Fruit>().nameInit = "w";
            fruit.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            fruit.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(
                Random.Range(velocityXMin, velocityXMax), Random.Range(velocityYMin, velocityYMax)));
        }

    }

    public void numOfChildIncrement()
    {
        numOfChild++;
        Debug.Log("`numOfChild` increased to: " + numOfChild);
    }
    public void numOfChildDecrement()
    {
        numOfChild--;
        Debug.Log("`numOfChild` decreased to: " + numOfChild);
    }
}