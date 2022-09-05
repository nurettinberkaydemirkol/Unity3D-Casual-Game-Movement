using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed = 500;

    private Touch touch;

    private Vector3 touchDown;
    private Vector3 touchUp;

    private bool dragStarted;
    private bool isMoving;

    int Coin;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                dragStarted = true;
                isMoving = true;
                touchDown = touch.position;
                touchUp = touch.position;
            }
        }

        if(dragStarted == true)
        {
            if(touch.phase == TouchPhase.Moved)
            {

                touchDown = touch.position;
            }
            if(touch.phase == TouchPhase.Ended)
            {
 
                touchDown = touch.position;
                isMoving = false;
                dragStarted = false;
            }

            gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, CalculateRotating(), rotationSpeed * Time.deltaTime);
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        }
    }

    Quaternion CalculateRotating()
    {
        Quaternion temp = Quaternion.LookRotation(calculateDirection(), Vector3.up);
        return temp;
    }

    Vector3 calculateDirection()
    {
        Vector3 temp = (touchDown - touchUp).normalized;
        temp.z = temp.y;
        temp.y = 0;
        return temp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Money")
        {
            Coin = PlayerPrefs.GetInt("Coin");
            Coin++;
            PlayerPrefs.SetInt("Coin", Coin);

            Destroy(other.gameObject);
        }
    }
}
