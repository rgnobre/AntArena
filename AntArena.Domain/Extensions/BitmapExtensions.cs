using System.Drawing;

namespace AntArena.Domain.Extensions;
public static class BitmapExtensions
{
    public static Bitmap ReplaceColor(this Bitmap original, string colorHex)
    {
        Color newColor = ColorTranslator.FromHtml(colorHex);
        Color white = ColorTranslator.FromHtml("#FFFFFF");

        Bitmap bmp = new Bitmap(original);
        for (int x = 0; x < bmp.Width; x++)
        {
            for (int y = 0; y < bmp.Height; y++)
            {
                Color gotColor = bmp.GetPixel(x, y);
                if (gotColor == white)
                    bmp.SetPixel(x, y, newColor);
            }
        }

        return bmp;
    }
}
