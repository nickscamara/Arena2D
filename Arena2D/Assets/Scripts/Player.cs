using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 1f;
    // public GameObject ex;

    

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(horizontal, vertical, 0f);
        //Instantiate(ex, transform.position, transform.rotation);
    }
}