using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUtils
{
    public class CameraEffects
    {

        public static IEnumerator ShakeCamera(GameObject cam, float duration = .2f,
                                              float shakeUpdateInterval = .02f, int shakeRadius = 5)
        {
            float runningTime = 0.0f;
            float runningShakeTime = 0.0f;
            float cameraCurrentZ = cam.transform.position.z;

            System.Random rnd;
            rnd = new System.Random();

            int xDeviation = rnd.Next((shakeRadius * -1), shakeRadius);
            int yDeviation = rnd.Next((shakeRadius * -1), shakeRadius);

            while (runningTime < duration) {
                runningTime += Time.deltaTime;
                runningShakeTime += Time.deltaTime;

                if (runningShakeTime > shakeUpdateInterval) {
                    runningShakeTime = 0.0f;
                    xDeviation = rnd.Next((shakeRadius * -1), shakeRadius);
                    yDeviation = rnd.Next((shakeRadius * -1), shakeRadius);
                }

                Vector3 shakenPosition = new Vector3((cam.transform.position.x + xDeviation), (cam.transform.position.y + yDeviation), cameraCurrentZ);

                cam.transform.position = shakenPosition;

                yield return null;
            }
        }
    }
}
