namespace DemoApplication.Contracts.BookImage
{
    public enum FileExtensions
    {
        JPG = 1,
        PNG = 2,
        JPEG = 4
    }

    public static class FileExtensionExtensions
    {
        public static string GetExtension(this FileExtensions fileExtensions)
        {
            switch (fileExtensions)
            {
                case FileExtensions.JPG:
                    return $".{nameof(FileExtensions.JPG).ToLowerInvariant()}"; 
                case FileExtensions.PNG:
                    return $".png";
                case FileExtensions.JPEG:
                    return $".jpg";
                default:
                    throw new Exception("This extension not found");
            }
        }
    }
}
