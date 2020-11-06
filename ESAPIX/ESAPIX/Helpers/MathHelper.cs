﻿namespace ESAPIX.Helpers
{
    public static class MathHelper
    {
        public static double Interpolate(double x1, double x3, double y1, double y3, double x2)
        {
            return (x2 - x1) * (y3 - y1) / (x3 - x1) + y1;
        }
    }
}