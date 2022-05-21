using UnityEngine;


public class AvatarNormalMotion : AvatarLocomotion
{

    private readonly int SpeedParameter = Animator.StringToHash("speed");
    private readonly int SpeedMultiplierParameter = Animator.StringToHash("speed multiplier");

    // Update is called once per frame
    protected override void Update()
    {
        if (hasAnimator)
        {
            avatarAnimator.SetFloat(SpeedParameter, agent.velocity.magnitude/agent.speed);
            avatarAnimator.SetFloat(SpeedMultiplierParameter, agent.speed);
        }

        base.Update();
    }
}
