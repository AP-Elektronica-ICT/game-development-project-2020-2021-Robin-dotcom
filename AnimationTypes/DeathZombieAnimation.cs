using HerexamenGame.Content.Animation;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HerexamenGame.AnimationTypes
{
    public class DeathZombieAnimation
    {
        public Animation Animation;
        public DeathZombieAnimation()
        {
            Animation = new Animation();
            Animation.AddFrame(new AnimationFrame(new Rectangle(14, 360, 55, 84)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(99, 357, 56, 87)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(187, 369, 60, 75)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(279, 371, 63, 73)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(374, 368, 61, 76)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(471, 380, 73, 63)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(579, 390, 83, 54)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(710, 389, 84, 55)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(829, 389, 83, 55)));

        }
        public bool AnimationEnded()
        {
            if (Animation.CurrentFrame.SourceRectangle.X == 829)
            {
                return true;
            }
            return false;
        }
    }
}
