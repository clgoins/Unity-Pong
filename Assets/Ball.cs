using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 velocity;
    [SerializeField] private Camera mainCamera;
    [SerializeField] float moveSpeed = 2;

    public void Init()
    {
        mainCamera = FindObjectOfType<Camera>();

        float x = Random.Range(-1, 1);
        float y = Random.Range(-1, 1);

        if (x == 0.0f)
            x = 1.0f;

        if (y == 0.0f)
            y = 1.0f;
        
        velocity = new Vector3(x,y,0);
        velocity.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenSpacePos = mainCamera.WorldToScreenPoint(transform.position);


        if (screenSpacePos.y > Screen.height || screenSpacePos.y < 0)
            velocity.y = -velocity.y;
        
        transform.position += velocity * Time.deltaTime * moveSpeed;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        velocity.x = -velocity.x;
        moveSpeed += 0.5f;
    }
}
