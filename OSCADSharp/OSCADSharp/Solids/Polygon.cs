using OSCADSharp.Spatial;
using OSCADSharp.Utility;
using System;
using System.Globalization;
using System.Linq;

namespace OSCADSharp.Solids
{
    public class Polygon : OSCADObject
    {
        public Vector2[] Points { get; }

        public Polygon(Vector2[] points)
        {
            Points = points;
        }

        public override Bounds Bounds()
        {
            var lowestX = Points.Min(it => it.X);
            var lowestY = Points.Min(it => it.Y);
            var highestX = Points.Max(it => it.X);
            var highestY = Points.Max(it => it.Y);
            return new Bounds(new Vector3(lowestX, lowestY, 0), new Vector3(highestX, highestY, 0));
        }

        public override OSCADObject Clone()
        {
            return new Polygon(Points);
        }

        public override Vector3 Position()
        {
            return new Vector3();
        }

        public override string ToString()
        {
            StatementBuilder sb = new StatementBuilder();
            var points = string.Join(",", Points.Select(it =>
            {
                return $"[{it.X.ToString(CultureInfo.InvariantCulture)},{it.Y.ToString(CultureInfo.InvariantCulture)}]";
            }));
            sb.Append($"polygon([{points}]);");
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
    }
}
