using System;

namespace Lateralus {

    public struct Radians : IComparable<Radians> {

        private const double FullCircle = 2 * Math.PI;

        public readonly double Value;

        public Radians(double value) {
            value = value % FullCircle;
            if (value < 0.0) {
                value = FullCircle + value;
            }
            Value = value;
        }

        public static Radians operator +(Radians r1, Radians r2) {
            return new Radians(r1.Value + r2.Value);
        }

        public static Radians operator +(Radians r1, double r2) {
            return new Radians(r1.Value + r2);
        }

        public static Radians operator -(Radians r1, Radians r2) {
            return new Radians(r1.Value - r2.Value);
        }

        public static Radians operator -(Radians r1, double r2) {
            return new Radians(r1.Value - r2);
        }

        public static Radians operator *(Radians r1, Radians r2) {
            return new Radians(r1.Value * r2.Value);
        }

        public static Radians operator *(Radians r1, double r2) {
            return new Radians(r1.Value * r2);
        }

        public static Radians operator /(Radians r1, Radians r2) {
            return new Radians(r1.Value / r2.Value);
        }

        public static Radians operator /(Radians r1, double r2) {
            return new Radians(r1.Value / r2);
        }

        public static bool operator <(Radians r1, Radians r2) {
            return r1.CompareTo(r2) < 0;
        }

        public static bool operator >(Radians r1, Radians r2) {
            return r1.CompareTo(r2) > 0;
        }

        public static bool operator >=(Radians r1, Radians r2) {
            return r1.CompareTo(r2) >= 0;
        }

        public static bool operator <=(Radians r1, Radians r2) {
            return r1.CompareTo(r2) <= 0;
        }

        public int CompareTo(Radians other) {
            return (int) Math.Ceiling(Value - other.Value);
        }

        public Angle AsAngle {
            get {
                const double rad2Deg = 57.29578;
                return new Angle(Value * rad2Deg);
            }
        }

        public override string ToString() {
            return Value + " rad";
        }
    }

    public static class RadianExtensions {

        public static Radians AsRadians(this int value) {
            return new Radians(value);
        }

        public static Radians AsRadians(this double value) {
            return new Radians(value);
        }
    }
}
