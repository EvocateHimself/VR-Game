namespace VRTK.Examples.Archery
{
    using UnityEngine;

    public class BowAnimation : MonoBehaviour
    {
        public Animation animationTimeline;

        public void SetFrame(float frame)
        {
            animationTimeline["BowPullAnim"].speed = 0;
            animationTimeline["BowPullAnim"].time = frame;
            animationTimeline.Play("BowPullAnim");
        }
    }
}