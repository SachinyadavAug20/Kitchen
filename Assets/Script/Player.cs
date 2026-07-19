using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
    [SerializeField]private float moveSpeed=0.5f;
    [SerializeField]private float _rotationSpeed=8f;

    private bool isWalking;

    PlayerInput _playerInput;
    Rigidbody _rb;
    Animator _animator;

    private void Awake() {
        _playerInput = GetComponent<PlayerInput>();
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
    }
    private void Update() {
        var horizontalInput = moveSpeed * _playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(horizontalInput.x, 0, horizontalInput.y);
        _rb.linearVelocity = moveDirection * 10;

        isWalking = moveDirection.magnitude > 0;
        _animator.SetBool("IsWalking", isWalking);
        if (moveDirection != Vector3.zero) {
            transform.forward = Vector3.Slerp(transform.forward, -moveDirection, Time.deltaTime * _rotationSpeed);
        }
    }
}
