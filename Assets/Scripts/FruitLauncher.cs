using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FruitLauncher : MonoBehaviour
{
    // Global Vars
    public GameObject fruitList;
    public float launchVelocity_x = 200f;
    public float launchVelocity_y = 200f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject fruit = Instantiate(fruitList,
            transform.position, transform.rotation);
        fruit.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(launchVelocity_x, launchVelocity_y));
    }

    // Update is called once per frame
    void Update()
    {

    }
}