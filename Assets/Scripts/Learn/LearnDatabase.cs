using System;
using UnityEngine;

namespace Learn
{
    [CreateAssetMenu(fileName = "LearnDatabase", menuName = "Learn Database")]
    public class LearnDatabase:ScriptableObject
    {
        public LearnItem[] LearnItems;
    }
    [Serializable]
    public class LearnItem
    {
        public string title;
        public GameObject prefab;
    }
}