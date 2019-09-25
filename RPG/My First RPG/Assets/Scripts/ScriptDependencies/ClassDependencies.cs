using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassDependencies : MonoBehaviour {
}
public static class Scalar
{
    //Scalars for telegrams
    public static float rangeScalar = 5.0f; // <- this divided by the distance it is currently at
    // So currentDist/range*rangeScalar is the distance for using attacks in the range of the projector
    public static float distanceScalar = 3.1f;
    public static float damageMultiple = 2f;
    public static float summonRange = 9;
}
namespace AIAdditions
{
    public class AIExtensions
    {
        public Vector3 FindRandomPosition(Vector3 pos, float range)
        {
            Vector3 temp = Random.insideUnitSphere * range;
            return (temp + pos);
        }
    }
}