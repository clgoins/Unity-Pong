using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private int selection = 1;
    [SerializeField] GameObject selector;
    [SerializeField] GameManager manager;

    void Update()
    {
        
    }

    private void OnLeftMove(InputValue inputValue)
    {
        if (inputValue.Get<float>() > 0)
            moveUp();

        if (inputValue.Get<float>() < 0)
            moveDown();
    }

    private void OnRightMove(InputValue inputValue)
    {
        if (inputValue.Get<float>() > 0)
            moveUp();

        if (inputValue.Get<float>() < 0)
            moveDown();
    }

    private void OnConfirm()
    {


        if (selection == 1)
        {
            manager.newGame(1);
        }

        if (selection == 2)
        {
            manager.newGame(2);
        }

        if (selection == 3)
        {
            Debug.Log("enter");
            Application.Quit();
        }
    }

    private void moveUp()
    {
        if (selection == 1)
            return;

        selection--;
        selector.transform.position += new Vector3(0,75,0);

    }

    private void moveDown()
    {
        if (selection == 3)
            return;

        selection++;
        selector.transform.position -= new Vector3(0, 75, 0);
    }

}
