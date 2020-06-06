using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExerciseAssiatant.Utilities
{
    public static class Antropometric
    {
        public static double BMI(double height, double weight)
        {
            return weight / Math.Pow(height, 2);
        }

        public static double idealWeight(double height)
        {
            return 22 * Math.Pow(height/100, 2);
        }

        public static float calories4Kilogram = 7717.5f;

        public enum Sex : byte
        {
            Male,
            Femal
        }

        public static double BMR(double height_kg, double weight_cm, byte age, Sex sex) // basal metabolic rate
        {
            if (sex is Sex.Male)
            {
                return 10 * weight_cm + 5.25 * height_kg - 5 * age + 5;
            } else
            {
                return 10 * weight_cm + 5.25 * height_kg - 5 * age - 161;
            }
        }

        
    }
}