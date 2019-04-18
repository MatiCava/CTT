﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]

public class PlayerController : MonoBehaviour {

    public Animator anim;
    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";
    public float rotationRate = 360;
    public float movSpeed = 10;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float moveAxis = Input.GetAxis(moveInputAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);

        ApplyInput(moveAxis, turnAxis);

        Attack();
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
                if(hit.collider.tag == "enemgio" || hit.collider.tag == "comida")
                {
                    //manejar danho
                }
            }
        }
    }

    private void ApplyInput(float moveInput, float turnInput)
    {
        move(moveInput);
        turn(turnInput);
    }

    private void move(float input)
    {
        anim.SetFloat("Speed", input);
        rb.AddForce(transform.forward * input * movSpeed, ForceMode.Force);
    }

    private void turn(float input)
    {
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }
}
