using HerexamenGame.Content.Animation;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HerexamenGame.AnimationTypes
{
    public class WalkingZombieAnimation
    {

        public Animation Animation;
        public WalkingZombieAnimation()
        {
            Animation = new Animation();
            Animation.AddFrame(new AnimationFrame(new Rectangle(12, 254, 53, 88)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(88, 254, 53, 88)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(175, 254, 53, 88)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(258, 254, 53, 88)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(338, 254, 53, 88)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(427, 254, 53, 88)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(518, 254, 53, 88)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(594, 254, 53, 88)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(670, 254, 53, 88)));

        }
        
    }
}
