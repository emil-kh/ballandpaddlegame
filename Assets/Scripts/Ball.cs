using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 4f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    // state
    Vector2 paddleToBallVector;
    bool HasStarted = false;

    // cached components reference
    AudioSource myaudioSource;
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myaudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!HasStarted)
        {
            LockBallToPaddle();
            LaunchBallOnClick();
        }
    
    }

    private void LaunchBallOnClick()
    {
        if (Input.GetMouseButton(0))
        {
            HasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }    
    }


    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (HasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
           myaudioSource.PlayOneShot(clip);
        }
    }
}

