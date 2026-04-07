using UnityEngine;
using System.Collections;

[System.Serializable]
public class TargetStep
{
    public TargetDrop target;
    public float delayBeforeDrop; // time before this target drops
}

public class TargetSequence : MonoBehaviour
{
    public TargetStep[] sequence;
    public bool loop = false;

    void Start()
    {
        StartCoroutine(RunSequence());
    }

    IEnumerator RunSequence()
    {
        do
        {
            foreach (TargetStep step in sequence)
            {
                yield return new WaitForSeconds(step.delayBeforeDrop);

                step.target.DropTarget();
            }

        } while (loop);
    }
}