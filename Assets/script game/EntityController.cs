using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class EntityController : MonoBehaviour
{

    public InputActionAsset inputAsset;
    public float speed = 1;

    private float _axis;

    private void OnEnable()
    {
        inputAsset.FindAction("gameplay/jump").started += HandleJump;

        inputAsset.FindAction("gameplay/move").performed += HandeleMove;
        inputAsset.FindAction("gameplay/move").canceled += HandeleMove;

        inputAsset.Enable();
    }

    private void OnDisable()
    {
        inputAsset.FindAction("gameplay/move").started -= HandleJump;

        inputAsset.FindAction("gameplay/move").performed -= HandeleMove;
        inputAsset.FindAction("gameplay/move").canceled -= HandeleMove;

        inputAsset.Disable();
    }

    private void Update()
    {
        transform.position += Vector3.right * _axis * speed * Time.deltaTime;
    }

    private void HandleJump(InputAction.CallbackContext ctx)
    {
        Debug.Log($"JUMP: Phase = {ctx.phase}");
    }

    private void HandeleMove(InputAction.CallbackContext ctx)
    {
        _axis = ctx.ReadValue<float>();
        Debug.Log($"Move: Phase = {ctx.phase}, Axis = {_axis}");
    }
}
