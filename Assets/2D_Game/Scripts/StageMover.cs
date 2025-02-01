using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMover : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private void Update()
    {
        MoveLeft();
    }

    private void MoveLeft()
    {
        transform.position += Vector3.left * Time.deltaTime * moveSpeed;
    }
}
