using UnityEngine;

namespace Ottamind.Gossiper
{ 
	[CreateAssetMenu(fileName ="Colors", menuName ="DataSO/Colors")]
    public class BackgroundColorHandlerSO : ScriptableObject
    {
        public Color[] Colors;
    }
}
