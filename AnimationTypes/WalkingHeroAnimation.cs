using HerexamenGame.Content.Animation;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HerexamenGame.AnimationTypes
{
    public class WalkingHeroAnimation
    {

        public Animation Animation;
        public WalkingHeroAnimation()
        {
            Animation = new Animation();
            Animation.AddFrame(new AnimationFrame(new Rectangle(18, 483, 79, 96)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(128, 483, 79, 96)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(239, 483, 79, 96)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(350, 483, 79, 96)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(456, 483, 79, 96)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(562, 483, 79, 96)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(669, 483, 79, 96)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(777, 483, 79, 96)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(886, 483, 79, 96)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(998, 483, 79, 96)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(1100, 483, 79, 96)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(1213, 483, 79, 96)));

        }
    }
}
