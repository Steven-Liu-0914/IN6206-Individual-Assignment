namespace WebAuthExamples.Handler
{
    public class MfaService
    {
        private static readonly Random _random = new Random();

        // Generate a random 6-digit OTP
        public string GenerateOtp()
        {
            return _random.Next(100000, 999999).ToString();
        }

        // Simulate OTP validation by comparing it with the stored OTP
        public bool ValidateOtp(string enteredOtp, string storedOtp)
        {
            return enteredOtp == storedOtp;
        }
    }

}
