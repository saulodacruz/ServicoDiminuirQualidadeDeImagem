using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace ServicoDiminuirQualidadeDeImagem
{
    public class Service
    {
        readonly string _sourceFile;
        readonly string _destinyTreatedFile;
        readonly int _percentageQuality;

        public Service(string sourceFile, string destinyTreatedFile, int percentageQuality)
        {
            _sourceFile = sourceFile;
            _destinyTreatedFile = destinyTreatedFile;
            _percentageQuality = percentageQuality;
        }

        public void Run()
        {
            var img = Image.FromFile(_sourceFile);
            CompressImage(img, _percentageQuality, _destinyTreatedFile);
        }

        private void CompressImage(Image imagem, long qualidade, string file)
        {
            var param = new EncoderParameters(1);
            param.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qualidade);
            var codec = GetCodec(imagem.RawFormat);
            imagem.Save(file, codec, param);
        }

        private ImageCodecInfo GetCodec(ImageFormat formato)
        {
            var codec = ImageCodecInfo.GetImageDecoders().FirstOrDefault(c => c.FormatID == formato.Guid);
            if (codec == null) throw new NotSupportedException();
            return codec;
        }
    }
}
