using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 10f)]
    private float JumpPower = 3f;
    [SerializeField]
    private float buttonTime = 0.3f;

    private bool isJumping = false;
    private bool isFly = false;
    private float jumpTime = 0.0f;

    private Rigidbody2D rigidBody;
    private Animator animator;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isJumping)
        {
            rigidBody.velocity = new Vector2(0f, JumpPower);
            jumpTime += Time.deltaTime;

            if (JumpKeyUp() || jumpTime > buttonTime)
            {
                JumpEnd();
            }
        }
        else
        {
            bool isSliding = animator.GetBool("IsDown");

            if (isSliding == false && isFly == false && JumpKeyDown())
            {
                JumpStart();
            }
        }
    }

    private void JumpStart()
    {
        SetFly(true);
        isJumping = true;
        jumpTime = 0.0f;
        Debug.Log("JUMP START");
    }

    private void JumpEnd()
    {
        isJumping = false;
        Debug.Log("JUMP END");

    }

    private bool JumpKeyDown()
    {
        return Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow);
    }

    private bool JumpKeyUp()
    {
        return Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow);
    }

    private void SetFly(bool fly)
    {
        isFly = fly;
        animator.SetBool("IsFly", fly);

        Debug.Log($"FLY : {fly}");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.CompareTag("Ground"))
        {
            Debug.Log("OnCollsion");
            SetFly(false);
        }
    }
}
