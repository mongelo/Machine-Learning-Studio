namespace Machine_Learning_Studio.Helpers
{
    public static class FileHelper
    {
        public static string GetProjectFolder()
        {
            return TrimPathAtBin(AppDomain.CurrentDomain.BaseDirectory);
        }

        private static string TrimPathAtBin(string path)
        {
            int indexOfBin = path.IndexOf("bin", StringComparison.OrdinalIgnoreCase);

            if (indexOfBin != -1)
            {
                return path.Substring(0, indexOfBin);
            }
            else
            {
                return path;
            }
        }
    }
}
