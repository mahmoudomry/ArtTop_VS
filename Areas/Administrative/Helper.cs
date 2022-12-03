namespace ArtTop.Areas.Administrative
{
    public class Helper
    {

        public string saveimage(IFormFile file, string def)
        {
            if (file != null)
            {
                string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                using (var filestream = new FileStream(Path.Combine(@"wwwroot/", "assets", "images", filename), FileMode.Create))
                {
                    file.CopyTo(filestream);

                }
                return filename;
            }
            return def;
        }
    }
}
