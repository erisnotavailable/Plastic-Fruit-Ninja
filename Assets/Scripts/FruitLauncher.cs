using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FruitLauncher : MonoBehaviour
{
    // Global Vars
    public GameObject fruitList;
    public float launchVelocity_x = 400f;
    public float launchVelocity_y = 400f;
    private int numOfChild = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("cloning...");
        GameObject fruit = Instantiate(fruitList,
            transform.position, transform.rotation);
        fruit.GetComponent<Renderer>().enabled = true;
        fruit.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        fruit.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(launchVelocity_x, launchVelocity_y));
    }

    // Update is called once per frame
    void Update()
    {

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