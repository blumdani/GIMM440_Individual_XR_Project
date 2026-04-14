using UnityEngine;
using System.Collections;

[System.Serializable]
public class TargetStep
{
    public TargetDrop target;
    public float delayBeforeDrop;

    public bool enableMovement;
    public Vector3 moveDirection;
    public float moveDistance;
    public float moveSpeed;
}

public class TargetSequence : MonoBehaviour
{
    public TargetStep[] sequence;

    private Coroutine sequenceRoutine;

    public void StartSequence()
    {
        sequenceRoutine = StartCoroutine(RunSequence());
    }

    public void StopSequence()
    {
        if (sequenceRoutine != null)
            StopCoroutine(sequenceRoutine);
    }

    IEnumerator RunSequence()
    {
        foreach (TargetStep step in sequence)
        {
            yield return new WaitForSeconds(step.delayBeforeDrop);

            TargetMover mover = step.target.GetComponent<TargetMover>();

            if (step.enableMovement && mover != null)
            {
                mover.Configure(step.moveDirection, step.moveDistance, step.moveSpeed);
            }
            else if (mover != null)
            {
                mover.StopMoving();
            }

            step.target.DropTarget();
        }
    }
}