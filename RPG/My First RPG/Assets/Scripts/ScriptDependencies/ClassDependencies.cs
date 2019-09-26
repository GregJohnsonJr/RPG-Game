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
        /// <summary>
        /// Returns 0 if the number returned is the first one, and 1 if it is the second one
        /// </summary>
        /// <param name="percentOfFirstNum"></param>
        /// <param name="seededRand"></param>
        /// <returns></returns>
        public int FindRandonNumberBetweenTwo(float percentOfFirstNum, System.Random seededRand)
        {
            int rand = seededRand.Next(1, 100);
            if (rand <= percentOfFirstNum)
            {
                return 0; // -> First number
            }
            else
                return 1;// -> Second number
        }
        /// <summary>
        /// With 0 being the first number and amountOfNumbers being the last number
        /// </summary>
        /// <param name="amountOfNumbers"></param>
        /// <param name="seededRand"></param>
        /// <returns></returns>
        public int ChooseRandomNumber(int amountOfNumbers, System.Random seededRand)
        {
            return seededRand.Next(0, amountOfNumbers);
        }
    }
}
namespace ScriptingHelper
{
    using System;
    using System.Linq;

    class Helper
    {
        struct GameObjectInfo
        {
            public float distance;
            public GameObject obj;
        }
        public GameObject GetClosestGameObject(GameObject player, GameObject[] others)
        {
            //float[] distance = new float[others.Length];
            GameObjectInfo[] info = new GameObjectInfo[others.Length];
            for (int i = 0; i < others.Length; i++)
            {
                GameObjectInfo temp;
                temp.distance = Vector3.Distance(player.transform.position, others[i].transform.position);
                temp.obj = others[i];
                info[i] = temp;
            }
            info = info.OrderBy(a => a.distance).ToArray();
            return info[0].obj;
        }
    }

}
