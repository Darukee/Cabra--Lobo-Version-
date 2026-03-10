using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AnimalScript : MonoBehaviour
{
    public static bool deadAnimal; //checa se o animal está vivo ou morto
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col) //código entre a interação do lobo e do animal matado e com a fase
    {
        if (col.gameObject.tag.Equals("Lobo"))
        {
            Death();
            if (!deadAnimal)
            {
                GameManager.bloodLust++;
                
                deadAnimal = true;
                //Debug.Log("Animais Mortos: " + GameManager.bloodLust); //alterar na interface

                if (GameManager.bloodLust == GameManager.bloodLustMax) //
                {
                    GameManager.Win();
                }
            }

        }
    }

    public void Death() //dependendo do tipo de animal, podem rolar coisas diferentes
    {
        switch (gameObject.name)
        {
            case "Triangle":
                Destroy(gameObject);
                break;
        }
    }
}
