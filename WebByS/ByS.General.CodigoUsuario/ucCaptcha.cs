using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using ByS.General.Entities;

namespace ByS.General.CodigoUsuario
{
    public class ucCaptcha
    {
        private static char generarCaracterAzar()
        {
            Random oAzar = new Random();
            int n = oAzar.Next(26) + 65;
            char c = (char)n;
            System.Threading.Thread.Sleep(15);
            return c;
        }

        public static beCaptcha CrearCaptcha()
        {
            beCaptcha obeCaptcha = new beCaptcha();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                sb.Append(generarCaracterAzar());
            }
            obeCaptcha.Codigo = sb.ToString();
            Rectangle rec = new Rectangle(0, 0, 200, 80);
            Bitmap bmp = new Bitmap(200, 80);
            Graphics grafico = Graphics.FromImage(bmp);
            LinearGradientBrush degradadado=new LinearGradientBrush(rec,Color.Aqua,Color.Blue,LinearGradientMode.BackwardDiagonal);
            grafico.FillRectangle(degradadado, rec);
            grafico.DrawString(sb.ToString(), new Font("Arial", 40), Brushes.White, 10, 10);
            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, ImageFormat.Png);
                obeCaptcha.Imagen = ms.ToArray();
            }
           return obeCaptcha;
        }
    }
}
