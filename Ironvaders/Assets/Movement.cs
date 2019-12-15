using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 10f;
    private Vector3 move;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector3(movementSpeed, 0, 0);
        this.transform.Translate(move * Time.deltaTime);

    }
}
