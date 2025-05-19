using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCADSharp.Spatial
{
    /// <summary>
    /// A Three-Dimensional vector
    /// 
    /// Can be used to represent a direction, or a point in space
    /// </summary>
    public class Vector2
    {
        #region Attributes
        /// <summary>
        /// X component of this vector
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Y component of this vector
        /// </summary>
        public double Y { get; set; }
        #endregion
        
        /// <summary>
        /// Creates a new Vector with the specified X/Y values
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector2(double x = 0, double y = 0)
        {
            this.X = x;
            this.Y = y;
        }
        
        /// <summary>
        /// Negates the values of this vector, returning an inverse of it
        /// </summary>
        /// <returns>A negated vector</returns>
        public Vector2 Negate()
        {
            return new Vector2(-this.X, -this.Y);
        }

        /// <summary>
        /// Creates a copy of this vector that's a new instance
        /// with the same values
        /// </summary>
        /// <returns>A clone of this vector</returns>
        public Vector2 Clone()
        {
            return new Vector2(this.X, this.Y);
        }

        /// <summary>
        /// Returns the average position of the provided positions
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        public static Vector2 Average(params Vector2[] positions)
        {
            if(positions == null || positions.Length == 0)
            {
                return null;
            }
            else if (positions.Length == 1)
            {
                return positions[0];
            }

            var sum = new Vector2();

            foreach (var pos in positions)
            {
                sum += pos;
            }

            return new Vector2(sum.X / positions.Length, sum.Y / positions.Length);
        }

        /// <summary>
        /// Returns the unit vector for this vector
        /// </summary>
        /// <returns></returns>
        public Vector2 Normalize()
        {
            if(this.X == 0 && this.Y == 0)
            {
                return this;
            }

            double sum = Math.Abs(this.X) + Math.Abs(this.Y);
            return new Vector2(this.X / sum, this.Y / sum);
        }

        /// <summary>
        /// Gets the Dot product of two vectors
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public double Dot(Vector2 other)
        {
            return this.X * other.X + this.Y * other.Y;
        }

        #region Operators/Overrides
        /// <summary>
        /// Compares this vector to another object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        /// <summary>
        /// Gets a hashcode that's based on the the string for this vector
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// Compares two vectors
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return left?.X == right?.X &&
                left?.Y == right?.Y;
        }

        /// <summary>
        /// Does a negated comparison of two vectors
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !(left == right);
        }
        
        /// <summary>
        /// Adds two vectors
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X + right.X, left.Y + right.Y);
        }

        /// <summary>
        /// Subtracts two vectors
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X - right.X, left.Y - right.Y);
        }

        /// <summary>
        /// Multiplies two vectors together
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator *(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X * right.X, left.Y * right.Y);
        }

        /// <summary>
        /// Multiplies (scales) a vector by a double
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator *(Vector2 left, double right)
        {
            return new Vector2(left.X * right, left.Y * right);
        }

        /// <summary>
        /// Muptiplies (scales) a vector by a double
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator *(double left, Vector2 right)
        {
            return new Vector2(left * right.X, left * right.Y);
        }

        /// <summary>
        /// Divides a vector by a double
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator /(Vector2 left, double right)
        {
            return new Vector2(left.X / right, left.Y / right);
        }

        /// <summary>
        /// Divides a vector by a double
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator /(double left, Vector2 right)
        {
            return new Vector2(left / right.X, left / right.Y);
        }
        #endregion

        internal Matrix ToMatrix()
        {
            double[] coords = { this.X, this.Y, 0 };
            return new Matrix(coords, 4, 1);
        }

        /// <summary>
        /// Converts this object to an OpenSCAD script
        /// </summary>
        /// <returns>Script for this object</returns>
        public override string ToString()
        {
            return String.Format("[{0}, {1}, {2}]", X.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture), Y.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture));
        }
    }
}
