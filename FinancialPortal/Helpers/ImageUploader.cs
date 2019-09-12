namespace FinancialPortal.Helpers
{
    using FinancialPortal.Models;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Web;
    public class ImageUploader
    {
        private HttpServerUtilityWrapper Server = new HttpServerUtilityWrapper(HttpContext.Current.Server);

        public static bool IsWebFriendlyImage(HttpPostedFileBase file)
        {
            if (file == null)
                return false;

            if (file.ContentLength > 2 * 1024 * 1024 || file.ContentLength < 1024)
                return false;

            try
            {
                using (var img = Image.FromStream(file.InputStream))
                {
                    return ImageFormat.Jpeg.Equals(img.RawFormat)
                        || ImageFormat.Png.Equals(img.RawFormat)
                        || ImageFormat.Icon.Equals(img.RawFormat)
                        || ImageFormat.Tiff.Equals(img.RawFormat)
                        || ImageFormat.Bmp.Equals(img.RawFormat)
                        || ImageFormat.Gif.Equals(img.RawFormat);
                }
            }
            catch
            {
                return false;
            }
        }

        //Watch video near end to see how he added extension values to config file

        public static bool IsValidAttachment(HttpPostedFileBase file)
        {
            try
            {
                if (file == null)
                    return false;

                if (file.ContentLength > 5 * 1024 * 1024)
                    return false;

                var extensionValid = false;

                var validExtensions = new List<string>();
                validExtensions.Add(".pdf");
                validExtensions.Add(".doc");
                validExtensions.Add(".docx");
                validExtensions.Add(".xls");
                validExtensions.Add(".xlsx");
                validExtensions.Add(".txt");
                validExtensions.Add(".html");
                validExtensions.Add(".xml");
                validExtensions.Add(".json");

                foreach (var fileExtension in validExtensions)
                {
                    if (Path.GetExtension(file.FileName) == fileExtension)
                    {
                        extensionValid = true;
                        break;
                    }
                }

                return IsWebFriendlyImage(file) || extensionValid;
            }
            catch
            {
                return false;
            }
        }

        public string StoreAvatar(HttpPostedFileBase file)
        {
            //check to see if image meets our specifications,
            //then will save that image and return the path.
            //if image doesnt meet specifications, return default image path.
            if (IsWebFriendlyImage(file))
            {
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var ext = Path.GetExtension(file.FileName);
                var unique = Guid.NewGuid();
                var format = $"{SlugHelper.CreateSlug($"{fileName}{unique}")}{ext}";
                file.SaveAs(Path.Combine(Server.MapPath("~/Avatars/"), format));
                return $"/Avatars/{format}";
            }
            else
                return "/Avatars/defaultAvatar.jpg";
            
        }
    }
}