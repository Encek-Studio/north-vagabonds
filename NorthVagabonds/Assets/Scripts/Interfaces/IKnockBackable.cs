using UnityEngine;

public interface IKnockBackable
{
    void KnockBack(Vector2 angle, float strength, int direction);
}