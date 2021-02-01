using System;
using System.Collections.Generic;

namespace TrigonometryLib.Primitives
{
    public class Line2D : Primitive2D, ICompoundPrimitive2D
    {
        public bool IsVertical { get; private set; }
        public Vector2D Start { get; private set; }
        public Vector2D End { get; private set; }


        public Line2D(Vector2D v1, Vector2D v2)
        {
            Start = v1;
            End = v2;

            IsVertical = Math.Abs(End.x - Start.x) < 0.00001f;
        }

        public Vector2D Center { get { return (Start + End) / 2.0f; } }
        public Vector2D Direction { get { return (End - Start).Normal(); } }

        public void Reverse()
        {
            Vector2D tmp = Start;
            Start = End;
            End = tmp;
        }

        public bool IntersectInfinite(Line2D other, out Vector2D intersectionPoint)
        {
            intersectionPoint = null;
            double denom = ((End.x - Start.x) * (other.End.y - other.Start.y)) - ((End.y - Start.y) * (other.End.x - other.Start.x));

            //  AB & CD are parallel
            if (denom == 0)
                return false;

            double numer = ((Start.y - other.Start.y) * (other.End.x - other.Start.x)) - ((Start.x - other.Start.x) * (other.End.y - other.Start.y));

            double r = numer / denom;

            double numer2 = ((Start.y - other.Start.y) * (End.x - Start.x)) - ((Start.x - other.Start.x) * (End.y - Start.y));

            double s = numer2 / denom;

            //if ((r < 0 || r > 1) || (s < 0 || s > 1))
            //    return false;

            // Find intersection point

            intersectionPoint = new Vector2D(
                Start.x + (r * (End.x - Start.x)),
                Start.y + (r * (End.y - Start.y))
                );
            return true;
        }

		public bool SafeIntersect(Line2D other, out Vector2D intersectionPoint)
		{
			if (Start.IsPositionEqual (other.Start) || Start.IsPositionEqual (other.End) ||
				  End.IsPositionEqual (other.Start) ||   End.IsPositionEqual (other.End))
			{
				// Line starts from position of other line, so it will never intersect...
				intersectionPoint = null;
				return false;
			}
			return Intersect (other, out intersectionPoint);
		}

		public bool SafeIntersect(Line2D other)
		{
			Vector2D v;
			return SafeIntersect (other, out v);
		}

		public bool Intersect(Line2D other)
		{
			Vector2D intersectionPoint;
			return Intersect (other, out intersectionPoint);
		}

        public bool Intersect(Line2D other, out Vector2D intersectionPoint)
        {
            intersectionPoint = null;
            double denom = ((End.x - Start.x) * (other.End.y - other.Start.y)) - ((End.y - Start.y) * (other.End.x - other.Start.x));

            //  AB & CD are parallel
            if (denom == 0)
                return false;

            double numer = ((Start.y - other.Start.y) * (other.End.x - other.Start.x)) - ((Start.x - other.Start.x) * (other.End.y - other.Start.y));

            double r = numer / denom;

            double numer2 = ((Start.y - other.Start.y) * (End.x - Start.x)) - ((Start.x - other.Start.x) * (End.y - Start.y));

            double s = numer2 / denom;

            if ((r < 0 || r > 1) || (s < 0 || s > 1))
                return false;

            // Find intersection point

            intersectionPoint = new Vector2D(
                Start.x + (r * (End.x - Start.x)),
                Start.y + (r * (End.y - Start.y))
                );
            return true;
        }

		public bool Crosses(Line2D theLineXY)
		{
			double aX1 = theLineXY.Start.x;
			double aX2 = theLineXY.Start.y;
			double aY1 = theLineXY.End.x;
			double aY2 = theLineXY.End.y;

			double aP1 = Start.x;
			double aP2 = Start.y;
			double aQ1 = End.x;
			double aQ2 = End.y;


			double aDenominator = (aY2 - aX2) * (aQ1 - aP1) - (aY1 - aX1) * (aQ2 - aP2);
			if( aDenominator == 0 )
			{
				// d. lines are (partly) identical or parallel
				return false;
			}
			double aKappa = ((aY1 - aX1) * (aP2 - aX2) - (aY2 - aX2) * (aP1 - aX1)) / aDenominator;
			double aLambda = ((aQ1 - aP1) * (aP2 - aX2) - (aQ2 - aP2) * (aP1 - aX1)) / aDenominator;
			// return true if they really cross
			return (aKappa > 0 && aKappa < 1 && aLambda > 0 && aLambda < 1);
		}


        public Vector2D ClosestPoint(Vector2D p)
        {
            Vector2D ap = p - Start;       //Vector from A to P
            Vector2D ab = End - Start;     //Vector from A to B

            double magnitudeAB = ab.LengthSquared();     //Magnitude of AB vector (it's length squared)
            double abAPproduct = Vector2D.Dot(ap, ab);   //The DOT product of a_to_p and a_to_b
            double distance = abAPproduct / magnitudeAB; //The normalized "distance" from a to your closest point

            if (distance < 0)     //Check if P projection is over vectorAB
            {
                return new Vector2D(Start);

            }
            else if (distance > 1)
            {
                return new Vector2D(End);
            }
            else
            {
                return Start + ab * distance;
            }
        }

        public double Angle()
        {
            Vector2D p1 = Start;
            Vector2D p2 = End;
            Vector2D vec = p2 - p1;

            double angle = Vector2D.Angle(new Vector2D(1, 0), vec);

            if (angle < 0)
            {
                angle += (double)Math.PI * 2;
            }

            return angle;
        }

        public double Angle(Line2D other)
        {
            double theta1 = (double)Math.Atan2(      Start.y -       End.y,       Start.x -       End.x);
            double theta2 = (double)Math.Atan2(other.Start.y - other.End.y, other.Start.x - other.End.x);

            return theta1 - theta2;
        }

		// Returns if line is the same. Checks both directions
		public bool IsPositionEqual(Line2D other)
		{
			return ((Start.IsPositionEqual(other.Start)) && (End.IsPositionEqual(other.End)) ||
				(Start.IsPositionEqual(other.End)) && (End.IsPositionEqual(other.Start)));
		}

        public List<Primitive2D> GetPrimitives()
        {
            return new List<Primitive2D>(new Primitive2D[] { Start, End });
        }
    }
}
