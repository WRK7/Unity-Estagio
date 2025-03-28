using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;

    public float speed = 5f;
    public float gravity = 9.81f;
    public float rotSpeed = 180f;
    public float jumpSpeed = 8f;

    private float rot;
    private Vector3 moveDirection;
    private bool isDead = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        if (controller == null)
        {
            Debug.LogError("CharacterController não encontrado!");
        }
        if (anim == null)
        {
            Debug.LogError("Animator não encontrado!");
        }
    }

    void Update()
    {
        if (!isDead)
        {
            Move();
        }
        if (isDead)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            SkinnedMeshRenderer renderer = GetComponentInChildren<SkinnedMeshRenderer>();
            if (renderer != null)
            {
                renderer.enabled = true;
                renderer.transform.position = transform.position;
                renderer.transform.localScale = Vector3.one;
                Debug.Log("Update: Transition Atual: " + anim.GetInteger("Transition") + " | Posição Ch14: " + renderer.transform.position);
            }
        }
    }

    void Move()
    {
        if (controller.isGrounded)
        {
            moveDirection = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
            {
                moveDirection += Vector3.forward * speed;
                anim.SetInteger("Transition", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                moveDirection += Vector3.back * speed;
                anim.SetInteger("Transition", 1);
            }
            else
            {
                anim.SetInteger("Transition", 0);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
                anim.SetInteger("Transition", 2);
            }
        }
        else
        {
            if (moveDirection.y < 0)
            {
                anim.SetInteger("Transition", 0);
            }
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDirection.y -= gravity * Time.deltaTime;

        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * Time.deltaTime);
    }

    public void Die()
{
    isDead = true;
    controller.enabled = false;
    transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    SkinnedMeshRenderer renderer = GetComponentInChildren<SkinnedMeshRenderer>();
    if (renderer != null)
    {
        renderer.enabled = true;
        renderer.transform.position = transform.position;
        renderer.transform.localScale = Vector3.one;
        StartCoroutine(SetTransitionAfterDelay());
    }
}

private System.Collections.IEnumerator SetTransitionAfterDelay()
{
    yield return new WaitForSeconds(0.1f); 
    anim.SetInteger("Transition", 3);
    Debug.Log("Die: Transition = 3 setado após delay. Posição: " + transform.position);
}
}