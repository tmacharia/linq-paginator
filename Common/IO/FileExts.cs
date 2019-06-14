namespace Common.IO
{
    public static class FileExts
    {
        public static string ToSafeFileName(string filename)
        {
            return filename
            .Replace("\\", "")
            .Replace("/", "")
            .Replace("\"", "")
            .Replace("*", "")
            .Replace(":", "")
            .Replace("?", "")
            .Replace("<", "")
            .Replace(">", "")
            .Replace("|", "");
        }
    }
}