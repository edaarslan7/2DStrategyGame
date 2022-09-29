using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoldierUnit : SpawnableObject
{
	#region Fields
	[SerializeField] private SpriteRenderer soldierImage;
    [SerializeField] private NavMeshAgent agent;
    #endregion

    #region Props
    #endregion

    #region Core
    public override void SetActiveWithPosition(Vector2 pos)
    {
        base.SetActiveWithPosition(pos);
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    public void SetSprite(Sprite soldier)
    {
        soldierImage.sprite = soldier;
    }
    #endregion

    public void Movement(Vector2 pos)
    {
        agent.SetDestination(pos);
    }
}
