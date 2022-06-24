using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGoosePosition : MonoBehaviour
{
    public Transform playerAvatar;
    public Vector3 offset;
    public void ResetPosition()
    {
        transform.position = playerAvatar.GetComponent<AvatarActions>().spawnPoint.position + offset;
    }
}
