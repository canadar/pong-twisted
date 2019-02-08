using UnityEngine;

public class Ball : MonoBehaviour
{
    private int _ballSpeed = 5;
    private int _left;
    private int _up;

    private Vector3 _startLocation;

    private void Start()
    {
        RandomizeDirection();
        _startLocation = transform.position;
    }

    private void Update()
    {
        MoveBall();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            _left *= -1;
            _ballSpeed++;
        }

        if (other.gameObject.name.Equals("Wall"))
        {
            _up *= -1;
        }
    }

    private void MoveBall()
    {
        transform.position += transform.forward * _ballSpeed * Time.deltaTime * _left;
        transform.position += transform.right *_ballSpeed * Time.deltaTime * _up;
    }

    private void RandomizeDirection()
    {
        var rand = new System.Random();
        var values = new [] {-1, 1};
        
        _left = values[rand.Next(0, values.Length)];
        _up = values[rand.Next(0, values.Length)];
    }

    public void ResetBall()
    {
        transform.position = _startLocation;
        RandomizeDirection();
        _ballSpeed = 5;
    }

    public void HasBeenShot(Vector3 dir)
    {
       //need logic here to dart ball to proper direction
       Debug.Log(dir);
    }
}
