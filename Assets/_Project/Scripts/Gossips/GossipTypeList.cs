using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ottamind.Gossiper
{
    [Serializable]
    public struct GossipScore
    {
        public GossipType GossipType;
        public float Score;
    }

    [CreateAssetMenu(fileName = "GossipTypeList", menuName = "Scriptable Objects/GossipTypeList")]
    public class GossipTypeList : ScriptableObject
    {
        public List<GossipScore> GossipScoreList;
    }
}
