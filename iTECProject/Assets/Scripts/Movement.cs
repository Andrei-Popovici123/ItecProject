using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float _moveX = 0f;
        float _moveY = 0f;

        if (Keyboard.current.dKey.isPressed) _moveX += 1f;
        else if (Keyboard.current.aKey.isPressed) _moveX -= 1f;
        if (Keyboard.current.wKey.isPressed) _moveY += 1f;
        else if (Keyboard.current.sKey.isPressed) _moveY -= 1f;

        Vector3 moveDirection = new Vector3(_moveX, _moveY, 0);

        moveDirection = moveDirection.normalized;

        Vector3 moveAmount = moveDirection * (_moveSpeed * Time.deltaTime);

        transform.Translate(moveAmount);
    }
}