﻿using CustomJSONData.CustomBeatmap;
using System.Collections;
using UnityEngine;
using static NoodleExtensions.Animation.AnimationController;

namespace NoodleExtensions.Animation
{
    internal class AssignPathAnimation
    {
        internal static void Callback(CustomEventData customEventData)
        {
            if (customEventData.type == "AssignPathAnimation")
            {
                EventHelper.StartEventCoroutine(customEventData, EventType.AssignPathAnimation);
            }
        }

        internal static IEnumerator AssignPathAnimationCoroutine(Property property, float duration, float startTime, Functions easing)
        {
            PointDataInterpolation pointDataInterpolation = property._property as PointDataInterpolation;
            while (true)
            {
                float elapsedTime = instance.customEventCallbackController._audioTimeSource.songTime - startTime;
                pointDataInterpolation._time = Easings.Interpolate(Mathf.Min(elapsedTime / duration, 1f), easing);

                if (elapsedTime < duration) yield return null;
                else break;
            }

            pointDataInterpolation.Finish();
        }
    }
}
