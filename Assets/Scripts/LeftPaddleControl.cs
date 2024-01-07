using UnityEngine;
using UnityEngine.InputSystem;

public class LeftPaddleControl : MonoBehaviour
{
    private Vector3 velocity;
    private Vector3 screenPosition;
    private Vector3 worldPosition;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float xOffset;
    [SerializeField] private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector2.zero;
        screenPosition.y = Screen.height / 2;
    }

    // Update is called once per frame
    void Update()
    {
        screenPosition.x = xOffset;
        screenPosition.y += velocity.y * Time.deltaTime * moveSpeed;

        if (screenPosition.y < 0)
            screenPosition.y = 0;

        if (screenPosition.y > Screen.height)
            screenPosition.y = Screen.height;

        worldPosition = mainCamera.ScreenToWorldPoint(screenPosition);
        worldPosition.z = 0;
        transform.position = worldPosition;
    }

    private void OnLeftMove(InputValue inputValue)
    {
        velocity.y = inputValue.Get<float>();
    }

}
