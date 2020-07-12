using System;
using UnityEngine;

namespace Lateralus {

    public struct ComplexNumber {

        public readonly double Direct; // Real part
        public readonly Lateral Lateral; // Imaginary part

        public ComplexNumber(double direct, Lateral lateral) {
            Direct = direct;
            Lateral = lateral;
        }

        public ComplexNumber(double direct, double lateral) : this(direct, new Lateral(lateral)) {}

        public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2) {
            return new ComplexNumber(c1.Direct + c2.Direct, c1.Lateral + c2.Lateral);
        }

        public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2) {
            return new ComplexNumber(c1.Direct - c2.Direct, c1.Lateral - c2.Lateral);
        }

        /// <summary>
        /// Multiplying two complex numbers means rotating the first number
        /// by the second number (we actually sum the rotation of the first and second
        /// number)
        /// 
        /// Secondly we multiply the length of both vectors to give the new complex
        /// number its appropriate size
        /// </summary>
        public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2) {
            // i¹ = i = √-1
            // i² = -1
            // i³ = -i
            // i⁴ = 1

            var direct = c1.Direct * c2.Direct;
            var lateral1 = c1.Direct * c2.Lateral;
            var lateral2 = c1.Lateral * c2.Direct;
            var squaredLateral = c1.Lateral * c2.Lateral;

            return new ComplexNumber(direct + squaredLateral, lateral1 + lateral2);
        }

        public override string ToString() {
            if (Lateral.Value >= 0.0) {
                return Direct + " + " + Lateral.Value + "i";
            } else {
                return Direct + " - " + Math.Abs(Lateral.Value) + "i";    
            }
        }
    }

    public struct Lateral {

        public readonly double Value;

        public Lateral(double value) {
            Value = value;
        }

        public static Lateral operator +(Lateral l1, Lateral l2) {
            return new Lateral(l1.Value + l2.Value);
        }

        public static Lateral operator -(Lateral l1, Lateral l2) {
            return new Lateral(l1.Value - l2.Value);
        }

        /// <summary>
        /// Multiplying two lateral components implies
        /// squaring them. Since i² = -1 we negate the result
        /// of the multiplication and arrive at the correct number
        /// </summary>
        public static double operator *(Lateral l1, Lateral l2) {
            return -(l1.Value * l2.Value);
        }

        public static Lateral operator *(double direct, Lateral lateral) {
            return lateral * direct;
        }

        public static Lateral operator *(Lateral lateral, double direct) {
            return new Lateral(lateral.Value * direct);
        }

        public override string ToString() {
            return Value + "i";
        }
    }

    public static class ComplexMath {

        public static ComplexNumber AsComplexNumber(this Vector2 v) {
            return new ComplexNumber(direct: v.x, lateral: v.y);
        }

        public static Vector2 AsVector(this ComplexNumber c) {
            return new Vector2(x: (float)c.Direct, y: (float)c.Lateral.Value);
        }

        public static ComplexNumber Normalize(this ComplexNumber c) {
            return c.AsVector().normalized.AsComplexNumber();
        }

//        public static ComplexNumber ToComplexNumber(this Angle angle) {
//            return angle.AsRadians.ToComplexNumber();
//        }
//
//        public static ComplexNumber ToComplexNumber(this Radians angle) {
//            // Create a unit vector that represents clockwise rotation from
//            // the forward vector (1, 0)
//
//        }
//
//        public static Radians Radians(this ComplexNumber number) {
//            return Math.Atan2(number.Lateral.Value, number.Direct).AsRadians();
//        }
//
//        public static Angle Angle(this ComplexNumber number) {
//            return number.Radians().AsAngle;
//        }
    }
}