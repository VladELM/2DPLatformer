using System;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public void ToggleAnimationSide(float targetValueX)
    {
        int multiplier = GetMultiplier(targetValueX);

        Vector3 scale = new Vector3(Math.Abs(transform.localScale.x) * multiplier,
                            transform.localScale.y, transform.localScale.z);
        transform.localScale = scale;
    }

    private int GetMultiplier(float targetValueX)
    {
        int multiplier = 1;

        if (transform.position.x > targetValueX)
            multiplier = -1;
        else if (transform.position.x < targetValueX)
            multiplier = 1;

        return multiplier;
    }
}
