using System;

namespace BotFactory.Common.Tools
{
    public class Coordinates
    {
        //Porperties
        public double X { get; set; }
        public double Y { get; set; }


        //Constructors and methods

        public Coordinates(int v1, int v2)
        {
            X = v1;
            Y = v2;
        }

        public override bool Equals(Object obj)
        {  if (obj == null) {
                return false;
            }
            Coordinates coord = obj as Coordinates;
            if ((System.Object)coord == null) {
                return false;
            }
            return (X == coord.X && Y == coord.Y);
        }


    }
}
