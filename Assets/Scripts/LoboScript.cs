using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoboScript : MonoBehaviour
{
    public static bool leftLock, rightLock, upLock, downLock;
    public LayerMask wallLayer;
    float moveDistance = 2.55f, checkRadius = 0.05f;

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            TryMove(Vector2.up);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            TryMove(Vector2.down);
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            TryMove(Vector2.left);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            TryMove(Vector2.right);
    }

    void TryMove(Vector2 direction)
    {
        Vector2 currentPos = transform.position;
        Vector2 targetPos = currentPos + direction * moveDistance;

        Collider2D hit = Physics2D.OverlapCircle(targetPos, checkRadius, wallLayer);

        if (hit == null)
        {
            transform.position = targetPos;
        }
    }
}
