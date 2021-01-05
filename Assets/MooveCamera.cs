using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MooveCamera : MonoBehaviour
{
    float speed = 0.20f,speedUp = 0.001f;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.Find("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x+speed, 15.43f, 0);
        speed += speedUp;
        anim.speed = 1 + speed;
        if (speed > 0.65f) speedUp = 0.0002f;
    }
    private void OnDisable()
    {
        anim.speed = 1;
    }
}
