using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;
using UnityEngine.SceneManagement;

public class LoboScript : MonoBehaviour
{
    public static bool moveBlock; //controla se o jogador pode ou não se mover
    public LayerMask wallLayer;
    float moveDistance = 2.55f, checkRadius = 0.05f;

    void Update()
    {
        if (!moveBlock)
        {
            Move();
        }

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
   
    void TryMove(Vector2 direction) //ações que ocorrem quando o personagem tenta se mover
    {
        Vector2 currentPos = transform.position;
        Vector2 targetPos = currentPos + direction * moveDistance;

        Collider2D hit = Physics2D.OverlapCircle(targetPos, checkRadius, wallLayer); //esse código checa se há paredes por perto e impede que o personagem se mova em direção a uma

        if (hit == null) //caso não haja parede, o personagem se move
        {
            transform.position = targetPos;
            GameManager.numSteps--; 
        }
        else //caso haja parede, o número de passos desce mas o personagem não se move
        {
            GameManager.numSteps--;
        }

        if (GameManager.numSteps <= 0) //seacabarem o número de passos, o jogador dá game over
        {
            GameManager.GameOver();
            GameManager.numSteps = 0;
            moveBlock = true;
        }
        else
        {
            Debug.Log("Número de passos: " + GameManager.numSteps); //atualiza o número de passos na interface
        }
    }
}
