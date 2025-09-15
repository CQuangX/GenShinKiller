using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAirBorneState
{
    public PlayerJumpState(PlayerMovementStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Vector3 playerVelocity = stateMachine.player.rb.velocity;
        playerVelocity.y = 0;
        stateMachine.player.rb.velocity = playerVelocity;

        stateMachine.player.rb.AddForce(Vector3.up * airborneData.JumpData.JumpForce, ForceMode.VelocityChange);

        stateMachine.ChangeState(stateMachine.fallState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
