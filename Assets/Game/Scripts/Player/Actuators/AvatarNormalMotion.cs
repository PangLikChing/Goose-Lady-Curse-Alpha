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
            //Set animation in the blend tree
            avatarAnimator.SetFloat(SpeedParameter, agent.velocity.magnitude/agent.speed);
            //Set animation playback speed
            avatarAnimator.SetFloat(SpeedMultiplierParameter, agent.speed);
        }

        base.Update();
    }
}
