using System;

namespace Lateralus {

    /// <summary>
    /// Represents an angle in degrees.
    /// The implementation is monoidal meaning it represents valid angles as numbers between 0° and 360°
    /// </summary>
    public struct Angle : IComparable<Angle> {

        private const double FullRotation = 360;

        public readonly double Value;

        public Angle(double value) {
            value = value % FullRotation;
            if (value < 0.0) {
                value = FullRotation + value;
            }
            Value = value;
        }

        public static Angle operator +(Angle a1, Angle a2) {
            return new Angle(a1.Value + a2.Value);
        }

        public static Angle operator +(Angle a1, double a2) {
            return new Angle(a1.Value + a2);
        }

        public static Angle operator -(Angle a1, Angle a2) {
            return new Angle(a1.Value - a2.Value);
        }

        public static Angle operator -(Angle a1, double a2) {
            return new Angle(a1.Value - a2);
        }

        public static Angle operator *(Angle a1, Angle a2) {
            return new Angle(a1.Value * a2.Value);
        }

        public static Angle operator *(Angle a1, double a2) {
            return new Angle(a1.Value * a2);
        }

        public static Angle operator /(Angle a1, Angle a2) {
            return new Angle(a1.Value / a2.Value);
        }

        public static Angle operator /(Angle a1, double a2) {
            return new Angle(a1.Value / a2);
        }

        public static bool operator <(Angle a1, Angle a2) {
            return a1.CompareTo(a2) < 0;
        }

        public static bool operator >(Angle a1, Angle a2) {
            return a1.CompareTo(a2) > 0;
        }

        public static bool operator >=(Angle a1, Angle a2) {
            return a1.CompareTo(a2) >= 0;
        }

        public static bool operator <=(Angle a1, Angle a2) {
            return a1.CompareTo(a2) <= 0;
        }

        public Radians AsRadians {
            get {
                const double deg2Rad = 0.01745329;
                return new Radians(Value * deg2Rad);
            }
        }

        public int CompareTo(Angle other) {
            return (int) Math.Ceiling(Value - other.Value);
        }

        public override string ToString() {
            return Value + "°";
        }
    }

    public static class AngleExtensions {

        public static Angle AsAngle(this int value) {
            return new Angle(value);
        }

        public static Angle AsAngle(this double value) {
            return new Angle(value);
        }
    }
}
