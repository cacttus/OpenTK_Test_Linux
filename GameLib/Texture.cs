using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing.Imaging;
namespace Oc
{
    public enum TextureLoadResult
    {
        Success,
        TooLarge,
        InvalidPath,
        InvalidExtension
    }

    public class Texture : IglResource
    {
        //public int _intTextureId;
        public float Width;
        public float Height;

        public System.Drawing.Imaging.PixelFormat WindowsPixelFormat
        {
            get
            {
                return System.Drawing.Imaging.PixelFormat.Format32bppArgb;
            }
            private set
            {
            }
        }
        public OpenTK.Graphics.OpenGL.PixelFormat GlPixelFormat
        {
            get
            {
                return OpenTK.Graphics.OpenGL.PixelFormat.Bgra;
            }
            private set
            {
            }
        }
        public Texture()
        {
        }
        private int GetNumMipmaps(int w, int h)
        {
            int numMipMaps = 0;
            int x = System.Math.Max(w, h);
            for (; x > 0; x = x >> 1)
                numMipMaps++;
            return numMipMaps;
        }
        public TextureLoadResult Load(string path)
        {
            Bitmap bmp = new Bitmap(path);

            Width = bmp.Width;
            Height = bmp.Height;

            int ts = Gpu.GetMaxTextureSize();
            if (Width >= ts)
                return TextureLoadResult.TooLarge;
            if (Height >= ts)
                return TextureLoadResult.TooLarge;

            _glId = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, GetGlId());
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.LinearMipmapLinear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            BitmapData bmp_data = bmp.LockBits(
                new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadOnly,
                WindowsPixelFormat);//Note:if you change this make sure to change save image.

            int numMipmaps = GetNumMipmaps((int)Width, (int)Height);

            GL.TexStorage2D(TextureTarget2d.Texture2D, numMipmaps, SizedInternalFormat.Rgba8, (int)Width, (int)Height);

            GL.TexSubImage2D(TextureTarget.Texture2D,
                0, //mipmap level
                0, 0, //x.y
                bmp_data.Width,
                bmp_data.Height,
                GlPixelFormat,
                PixelType.UnsignedByte,
                bmp_data.Scan0);

            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            bmp.UnlockBits(bmp_data);


            return TextureLoadResult.Success;
        }
        public void Bind()
        {
            if (GetGlId() == 0)
                throw new System.Exception("Texture ID was 0 when binding texture.");

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, GetGlId());
        }
        public void Unbind()
        {
            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }
        public override void Free()
        {
            //If delete is called on a non-texture it is ignored by the GL
            if (GL.IsTexture(GetGlId()))
                GL.DeleteTexture(GetGlId());
        }

    }
}
