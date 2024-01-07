using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    private Vector3 velocity;
    private Vector3 screenPosition;
    private Vector3 worldPosition;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float xOffset;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector2.zero;
        screenPosition.y = Screen.height / 2;
        ball = GameObject.FindGameObjectWithTag("ball");
    }

    // Update is called once per frame
    void Update()
    {
        // Find the active ball in the scene
        if (ball == null)
            ball = GameObject.FindGameObjectWithTag("ball");

        // Calculate the desired paddle velocity
        calculateVelocity();

        // Determine the paddles desired position in screen space
        screenPosition.x = Screen.width - xOffset;
        screenPosition.y += velocity.y * Time.deltaTime * moveSpeed;

        // If the paddle tries to go off screen, stop it at the edge of the screen
        if (screenPosition.y < 0)
            screenPosition.y = 0;

        if (screenPosition.y > Screen.height)
            screenPosition.y = Screen.height;

        // Convert the paddles screen space position to its world space position
        worldPosition = mainCamera.ScreenToWorldPoint(screenPosition);
        worldPosition.z = 0;

        // Update the position of the paddle
        transform.position = worldPosition;
    }


    private void calculateVelocity()
    {
        // Get the direction that the ball is moving
        Vector2 ballDir = ball.GetComponent<Ball>().getDirection();

        // If ball is moving away from paddle, stop moving
        if (ballDir.x < 0)
        {
            velocity.y = 0;
        }

        // If ball is moving towards paddle, stop and wait for it to get close
        if (ballDir.x > 0)
        {
            if (ball.transform.position.x < 2)
                velocity.y = 0;
            else
            {
                // Once ball is on the paddles half of the screen, start moving to hit it
                if (ball.transform.position.y < transform.position.y)
                    velocity.y = -1;
                else if (ball.transform.position.y > transform.position.y)
                    velocity.y = 1;
                else
                    velocity.y = 0;
            }
        }
    }
}
