using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
    PlayerInput _playerInput;
    Rigidbody _rb;
    private void Awake() {
        _playerInput = GetComponent<PlayerInput>();
        _rb = GetComponent<Rigidbody>();
    }
    private void Update() {
        var horizontalInput = _playerInput.actions["Move"].ReadValue<Vector2>();
        Debug.Log(horizontalInput);
        _rb.linearVelocity = new Vector3(horizontalInput.x, 0, horizontalInput.y) * 10;

    }
}
