using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ottamind.Gossiper
{
    [Serializable]
    public struct GossipScore
    {
        public GossipType GossipType;
        public int Score;
    }

    [CreateAssetMenu(fileName = "GossipTypeList", menuName = "Scriptable Objects/GossipTypeList")]
    public class GossipTypeList : ScriptableObject
    {
        public List<GossipScore> GossipScoreList;

        public int GetScore(GossipType type)
        {
           return GossipScoreList.Find(x => x.GossipType == type).Score ;
        }
    }
}
