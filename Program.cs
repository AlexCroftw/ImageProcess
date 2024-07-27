using ImageProcess;
using ImageProcess.Filters;
using ImageProcess.FIlters;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;
using Image = SixLabors.ImageSharp.Image;

// Clean Code Create Class for filters
// Website ce te lasa sa load a image using browse, apply diferent filters, show result in web page , save image as a file

// Open the file automatically detecting the file type to decode it.
// Our image is now in an uncompressed, file format agnostic, structure in-memory as
// a series of pixels.
// You can also specify the pixel format using a type parameter (e.g. Image<Rgba32> image = Image.Load<Rgba32>("foo.jpg"))
using (var image = Image.Load<Rgba32>("foo.jpg"))
{
    // Resize the image in place and return it for chaining.
    // 'x' signifies the current image processing context.

    // The library automatically picks an encoder based on the file extension then
    // encodes and write the data to disk.
    // You can optionally set the encoder to choose.
    byte[] pixelArray = new byte[image.Width * image.Height * Unsafe.SizeOf<Rgba32>()];
    image.CopyPixelDataTo(pixelArray);

    MyPixel[,] pixels = new MyPixel[image.Height, image.Width];
    for (int i = 0; i < image.Height; i++)
    {
        for (int j = 0; j < image.Width; j++)
        {
            MyPixel pixel = new MyPixel
            {
                R = pixelArray[i * 4 * image.Width + j * 4],
                G = pixelArray[i * 4 * image.Width + j * 4 + 1],
                B = pixelArray[i * 4 * image.Width + j * 4 + 2],
                A = pixelArray[i * 4 * image.Width + j * 4 + 3]
            };
            pixels[i, j] = pixel;
        }
    }

 

    for (int i = 0; i < 6; i++) 
    {
        pixels = ApplyFilter(pixels, DefinedFilters.filterBlur.Matrix);
    }     
    
    
    byte[] buffer = new byte[image.Width * image.Height * Unsafe.SizeOf<Rgba32>()];
   
    for (int i = 0; i < image.Height; i++)
    {
        for (int j = 0; j < image.Width; j++)
        {
            buffer[i * 4 * image.Width + j * 4] = pixels[i,j].R;
            buffer[i * 4 * image.Width + j * 4 + 1] = pixels[i, j].G;
            buffer[i * 4 * image.Width + j * 4 + 2] = pixels[i,j].B;
            buffer[i * 4 * image.Width + j * 4 + 3] = pixels[i,j].A;
        }
    }

    using (var image2 = Image.LoadPixelData<Rgba32>(buffer, image.Width, image.Height))
    {
        image2.Save("bar.jpg");
         
    }
    MyPixel[,] ApplyFilter(MyPixel[,] image, float[,] filter)
    {
        MyPixel[,] result = image.Clone() as MyPixel[,];
        for (int i = 1; i < image.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < image.GetLength(1) - 1; j++)
            {

                var valoare = (int)(image[i - 1, j - 1].R * filter[0, 0] +
                image[i - 1, j].R * filter[0, 1] +
                image[i - 1, j + 1].R * filter[0, 2] +
                image[i, j - 1].R * filter[1, 0] +
                image[i, j].R * filter[1, 1] +
                image[i, j + 1].R * filter[1, 2] +
                image[i + 1, j - 1].R * filter[2, 0] +
                image[i + 1, j].R * filter[2, 1] +
                image[i + 1, j + 1].R * filter[2, 2]);

                if (valoare > 255)
                {
                    valoare = 255;
                }
                if (valoare <= 0)
                {
                    valoare = 0;
                }
                result[i, j].R = (byte)valoare;

                var valoare2 = (int)(image[i - 1, j - 1].G * filter[0, 0] +
                image[i - 1, j].G * filter[0, 1] +
                image[i - 1, j + 1].G * filter[0, 2] +
                image[i, j - 1].G * filter[1, 0] +
                image[i, j].G * filter[1, 1] +
                image[i, j + 1].G * filter[1, 2] +
                image[i + 1, j - 1].G * filter[2, 0] +
                image[i + 1, j].G * filter[2, 1] +
                image[i + 1, j + 1].G * filter[2, 2]);

                if (valoare2 > 255)
                {
                    valoare2 = 255;
                }
                if (valoare2 <= 0)
                {
                    valoare2 = 0;
                }
                result[i, j].G = (byte)valoare2;

                var valoare3 = (int)(image[i - 1, j - 1].B * filter[0, 0] +
                image[i - 1, j].B * filter[0, 1] +
                image[i - 1, j + 1].B * filter[0, 2] +
                image[i, j - 1].B * filter[1, 0] +
                image[i, j].B * filter[1, 1] +
                image[i, j + 1].B * filter[1, 2] +
                image[i + 1, j - 1].B * filter[2, 0] +
                image[i + 1, j].B * filter[2, 1] +
                image[i + 1, j + 1].B * filter[2, 2]);

                if (valoare3 > 255)
                {
                    valoare3 = 255;
                }
                if (valoare3 <= 0)
                {
                    valoare3 = 0;
                }
                result[i, j].B = (byte)valoare3;
            };
        }
        return result;
    }
}
