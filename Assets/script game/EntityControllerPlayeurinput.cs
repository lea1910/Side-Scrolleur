using UnityEngine;
using UnityEngine.InputSystem;

public class EntityControllerPlayerInput : MonoBehaviour
{
    private float _axis;
    public float speed = 1.0f;

    private void Update()
    {
        transform.position += Vector3.right * _axis * speed * Time.deltaTime;
    }
    private void OnJump()
    {
        Debug.Log("JUMP");
    }

    private void OnMove(InputValue value)
    {
        _axis = value.Get<float>();
    }
}