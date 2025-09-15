using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirBorneState : PlayerMovementState
{
    protected readonly PlayerAirborneData airborneData;
    public PlayerAirBorneState(PlayerMovementStateMachine stateMachine) : base(stateMachine)
    {
        airborneData = stateMachine.player.Data.airborneData;
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        ApplyGravity();
    }
    public override void Update()
    {
        base.Update();

        if (stateMachine.player.IsGrounded())
        {
            stateMachine.ChangeState(stateMachine.landingState);
        }
    }

    private void ApplyGravity()
    {
        Vector3 gravityForce = Vector3.down * airborneData.FallData.GravityForce;
        stateMachine.player.rb.AddForce(gravityForce, ForceMode.Acceleration);
    }
}
