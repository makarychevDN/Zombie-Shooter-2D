using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class FollowTargetAIInput : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Character character;

    public void SetTarget(Transform target) => this.target = target;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (target == null)
            return;

        character.Move(target.transform.position.x > transform.position.x ? 1 : -1);
    }
}
