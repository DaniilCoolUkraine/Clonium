namespace Clonium.Core.General
{
    public static class NumericExtension
    {
        public static float GCD(this float a, float b)
        {
            while (b != 0)
            {
                float temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }
    }
}