﻿using System;

namespace PancakeModel
{
    public static class Extensions
    {
        public static void Dump(this object value)
        {
            System.Diagnostics.Debug.WriteLine(value.ToString());
        }
        public static decimal IntegralPart(this decimal value)
        {
            return Math.Truncate(value);
        }

        public static decimal FractionalPart(this decimal value)
        {
            return value - value.IntegralPart();
        }

        public static string ToNumericalString(this decimal value)
        {
            var ip = value.IntegralPart();
            var fp = value.FractionalPart();

            if (ip == 0 && fp == 0)
            {
                return "0";
            }

            if (ip == 0 && fp != 0)
            {
                return FracMethod.Dec2Frac(fp);
            }

            if (ip != 0 && fp == 0)
            {
                return ip.ToString();
            }

            if (ip != 0 && fp != 0)
            {
                return string.Format("{0} and {1}", ip, FracMethod.Dec2Frac(fp));
            }

            return null;
        }

        public static decimal Round(this decimal value, int numPlaces = 5)
        {
            return Math.Round(value, numPlaces);
        }
    }
}