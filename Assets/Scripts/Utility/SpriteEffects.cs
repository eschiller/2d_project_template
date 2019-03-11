using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUtils
{
    public class SpriteEffects
    {

        public static IEnumerator BlinkSprite(SpriteRenderer sr, float duration = 1.0f, float blinkSpeed = .05f)
        {
            Debug.Log(sr);

            Color original_color = sr.color;
            Color clear_color = new Color();
            clear_color = original_color;
            clear_color.a = 0.0f;

            int reps = (int)(duration / blinkSpeed);
            for (int i = 0; i < reps; i++)
            {

                Debug.Log("Rep " + i);
                //first see if it's the last rep. if it is, make the sprite visible
                if (i == (reps - 1))
                {
                    Debug.Log("changing color to " + original_color);
                    sr.color = original_color;
                }
                else if (sr.color == original_color)
                {
                    Debug.Log("changing color to " + clear_color);

                    sr.color = clear_color;
                }
                else
                {
                    Debug.Log("changing color to " + original_color);

                    sr.color = original_color;
                }
                yield return new WaitForSeconds(blinkSpeed);
            }
        }
    }
}
