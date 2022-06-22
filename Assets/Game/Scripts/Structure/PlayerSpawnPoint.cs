using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    private AvatarActions actions;
    private bool hasActions;
    // Start is called before the first frame update
    void Start()
    {
        hasActions = GameObject.FindGameObjectWithTag("Player").TryGetComponent<AvatarActions>(out actions);
    }

    public void SetSpawnPoint()
    {
        if (hasActions)
        {
            actions.spawnPoint = transform;
        }
    }
}
