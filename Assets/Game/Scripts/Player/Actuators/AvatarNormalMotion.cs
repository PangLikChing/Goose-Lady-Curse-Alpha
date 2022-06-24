using UnityEngine;

/// <summary>
/// This class moves the avatar with unity native navmesh agent
/// </summary>
public class AvatarNormalMotion : AvatarLocomotion
{

    private readonly int SpeedParameter = Animator.StringToHash("speed");
    private readonly int SpeedMultiplierParameter = Animator.StringToHash("speed multiplier");

    /// <summary>
    /// The update method
    ///     1) Set the animator parameter
    ///     2) Set the animation playback speed according to the agent's speed
    /// </summary>
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
