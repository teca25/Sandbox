using System;
using System.Collections.Generic;
using System.Text;

namespace sandbox
{
    class Hero
    {
        public int id;
        public int attackpoints;
        public int defencepoints;
        public int healthpoints;

        public Hero (int id,int attackpoints,int defencepoints,int healthpoints)
        {
            this.id = id;
            this.attackpoints = attackpoints;
            this.defencepoints = defencepoints;
            this.healthpoints = healthpoints;
        } 
        
    }
}
