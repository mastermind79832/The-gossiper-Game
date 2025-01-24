using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ottamind.Gossiper
{
    public class ProgressBarScript : MonoBehaviour
    {

        private static float delta = 0;

        private RectTransform rt;

        public static void StartProgress()
        {
        }

        public void progressionBarUpdate(float pos)
        {
            float newpos = transform.position.y + delta;
            transform.position = new Vector2(transform.position.x, newpos);// + delta, 0);
        }
    }
}
