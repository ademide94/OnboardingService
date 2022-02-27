using System;

namespace OnboardingUtilites
{
    public static class UtilitiesCode
    {
        public static int GenerateOtp()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
    }
}
