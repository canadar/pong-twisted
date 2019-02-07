using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour
{

    private const int PlayerSpeed = 10;

    [SerializeField] 
    private Ball _ball;
    
    private void Update()
    {
        MoveToBall();
    }

    private void MoveToBall()
    {
        var pos = _ball.transform.position;

        if (pos.x > transform.position.x)
        {
            MoveLeft();
        }
        else if (pos.x < transform.position.x)
        {
            MoveRight();
        }
    }

    private void MoveLeft()
    {
        transform.position += transform.right * PlayerSpeed * Time.deltaTime;
    }

    private void MoveRight()
    {
        transform.position += transform.right * PlayerSpeed * -1 * Time.deltaTime;
    }
}
