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
        if (ball == null)
            ball = GameObject.FindGameObjectWithTag("ball");

        calculateVelocity();

        screenPosition.x = Screen.width - xOffset;
        screenPosition.y += velocity.y * Time.deltaTime * moveSpeed;

        if (screenPosition.y < 0)
            screenPosition.y = 0;

        if (screenPosition.y > Screen.height)
            screenPosition.y = Screen.height;

        worldPosition = mainCamera.ScreenToWorldPoint(screenPosition);
        worldPosition.z = 0;
        transform.position = worldPosition;
    }

    private void calculateVelocity()
    {
        if (ball.transform.position.y < transform.position.y)
            velocity.y = -1;
        else if (ball.transform.position.y > transform.position.y)
            velocity.y = 1;
        else
            velocity.y = 0;


    }
}
