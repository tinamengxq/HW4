using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    //pipe moving speed
    [SerializeField]private float pipeSpeed = 1f;

    //pipes
    [SerializeField]private GameObject pipePrefab;
    [SerializeField]private GameObject initialPipe;

    //pipe appear interval
    [SerializeField]private float appearTimeDifference = 5f;

    //pipe appear height difference
    [SerializeField]private float appearHeightRange = 3f;

    [SerializeField]private bool pipecontroller = false;

    void Start()
    {
        Locator.Instance.Player.playerDied += PipeDie;
    }

    void PipeDie()
    {
        Destroy(this);
    }

    void Update()
    {
        if (pipecontroller)
        {
            appearTimeDifference -= Time.deltaTime;
            if (appearTimeDifference <= 0f)
            {
                Appear();
                appearTimeDifference = 5f;
            }
        }
        else
        {
            Move();
        }
        
    }


    void Appear()
    {
        //Position.x
        float appearXposition = initialPipe.transform.position.x + 2f;

        //Position.y
        float randomYposition = Random.Range(-appearHeightRange, appearHeightRange);
        Vector3 appearPosition = new Vector3(appearXposition,randomYposition,0);
        Instantiate(pipePrefab,appearPosition,transform.rotation);
    }

    void Move()
    {
        transform.Translate(Vector3.left * pipeSpeed * Time.deltaTime);
    }
}
