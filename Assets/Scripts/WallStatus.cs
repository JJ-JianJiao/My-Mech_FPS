using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallStatus : MonoBehaviour
{

    [SerializeField]
    float paintedCubeNum, maxNum;
    [SerializeField]
    GameObject destructible;

    // Start is called before the first frame update
    void Start()
    {
        maxNum = transform.childCount;
        paintedCubeNum = 0;
    }

    public void GetPainted()
    {

        paintedCubeNum++;

        if (paintedCubeNum >= maxNum) {

            Death();
        
        }
        //currentHealth -= damage;

        //if (currentHealth <= 0)
        //{
        //    Death();
        //}
    }

    void Death()
    {
        gameObject.SetActive(false);
        if (destructible != null)
        {
            GameObject destructableWall = Instantiate(destructible, transform.position, transform.rotation);
            if (destructableWall.transform.childCount == transform.childCount) {

                for (int i = 0; i < transform.childCount; i++)
                {
                    destructableWall.GetComponentsInChildren<Renderer>()[i].material.color = transform.GetComponentsInChildren<Renderer>()[i].material.color;
                }
            
            
            }
        }
    }
}
