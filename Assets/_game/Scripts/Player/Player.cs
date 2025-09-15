using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [field: Header("References")]
    [field: SerializeField] public PlayerSO Data { get; private set; }
    public Rigidbody rb { get; private set; }
    public PlayerInput playerInput { get; private set; }

    public Transform MainCameraTransform { get; private set; }

    [Header("Ground check Settings")]
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private float groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    PlayerMovementStateMachine movementStateMachine;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        movementStateMachine = new PlayerMovementStateMachine(this);
        playerInput = GetComponent<PlayerInput>();

        MainCameraTransform = Camera.main.transform;
    }
    private void Start()
    {
        movementStateMachine.ChangeState(movementStateMachine.idleState);
    }
    private void Update()
    {
        movementStateMachine.HandleInput();
        movementStateMachine.Update();
    }
    private void FixedUpdate()
    {
        movementStateMachine.PhysicUpdate();
    }

    public bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheckTransform.position, groundCheckDistance, groundLayer);
    }

    void OnDrawGizmos()
    {
        if (groundCheckTransform == null)
        {
            return;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheckTransform.position, groundCheckDistance);
    }
}
