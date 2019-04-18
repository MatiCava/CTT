using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Animator anim;
    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";
    public float rotationRate = 360;
    public float movSpeed = 10;
    private Rigidbody rb;

    public float speed = 1.0f;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = GameObject.FindGameObjectWithTag("pj");
        float distance = Vector3.Distance(transform.position, target.transform.position);
        float step = speed * Time.deltaTime;

        if (distance < 20)
        {
            anim.SetFloat("Speed", step);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
            //TODO cuando este cerca probar que no se superponga y ahi ataque
            Attack();
        }
    }

    //TODO falta manejo de animacion en ataque
    private void Attack()
    {
        RaycastHit hit;
        Ray orgDirRay = new Ray(transform.position, Vector3.forward);
        float maxD = 1;

        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * maxD);

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxD))
            {
                if (hit.collider.tag == "pj" || hit.collider.tag == "comida")
                {
                    //manejar danho
                }
            }
        }
    }

    private void turn(float input)
    {
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }
}
