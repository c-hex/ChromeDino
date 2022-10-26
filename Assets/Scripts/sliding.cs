using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliding : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D boxCollider;

    [SerializeField]
    private float offsetY = 0.25f;
    [SerializeField]
    private float sizeY = 0.45f;

    private bool isSliding = false;

    private Vector2 startOffSet;
    private Vector2 startSize;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        startOffSet = boxCollider.offset;
        startSize = boxCollider.size;
        // animator.getBool

    }

    // Update is called once per frame
    void Update()
    {
        bool canSlide = animator.GetBool("IsFly") == false;

        if(canSlide)
        {
            if (isSliding)
            {
                bool iskeyUp = Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.DownArrow);
                if (iskeyUp)
                {
                    EndSlide();
                }
            }
            else
            {
                bool iskeyDown = Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.DownArrow);
                if (iskeyDown)
                {
                    StartSlide();
                }
            }
        }
    }
    private void StartSlide()
    {
        boxCollider.offset = new Vector2(startOffSet.x, offsetY);
        boxCollider.size = new Vector2(startSize.x, sizeY);

        isSliding = true;
        animator.SetBool("IsDown", isSliding);
    }
    private void EndSlide()
    {
        boxCollider.offset = startOffSet;
        boxCollider.size = startSize;

        isSliding = false;
        animator.SetBool("IsDown", isSliding);
    }
}
