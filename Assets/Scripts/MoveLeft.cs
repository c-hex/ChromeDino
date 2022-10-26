using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float StartMoveSpeed = 4.5f;
    private float MoveSpeed;
    private float SpeedUp = 0.0005f;

    private void Start()
    {
        MoveSpeed = StartMoveSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        MoveSpeed += SpeedUp;
        transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
    }
}