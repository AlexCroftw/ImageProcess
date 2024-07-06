using ImageProcess.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcess.FIlters
{
    public static class DefinedFilters
    {

        public static Filter filterBlur = new Filter
        {
            Matrix = new float[,]
            {
               { 0.06F, 0.1F, 0.06F },
               { 0.1F, 0.36F,0.1F },
               { 0.06F, 0.1F, 0.06F }
            }
        };


        public static Filter filterCopy = new Filter
        {
            Matrix = new float[,]
            {
                { 0, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 0 } 
            }
        };


        public static Filter filterSharpen = new Filter
        {
            Matrix = new float[,]
            {
                { 0, -1, 0 },
                { -1, 5, -1 },
                { 0, -1, 0 } 
            }
        };


        public static Filter filterEmboss = new Filter
        {
            Matrix = new float[,]
            {
                 { -2, -1, 0 },
                 { -1, 1, 1 },
                 { 0,  1, 2 }
            }
        };

        public static Filter filterVerticalLineDetection = new Filter
        {
            Matrix = new float[,]
           {
                 { -1, 0, 1 },
                 { -1, 0, 1 },
                 { -1, 0, 1 }
           }
        };

        public static Filter filterEdgeDetection  = new Filter
        {
            Matrix = new float[,]
           {
                 { -1, -1, -1},
                 { -1, 8, -1 },
                 { -1, -1, -1 }
           }
        };

        public static Filter filterGaussienBlur = new Filter
        {
            Matrix = new float[,]
            {
                  { 0.0625F, 0.125F, 0.0625F },
                  { 0.125F, 0.25F, 0.125F },
                  { 0.0625F, 0.125F, 0.0625F }
            }
        };
       
    }
}
