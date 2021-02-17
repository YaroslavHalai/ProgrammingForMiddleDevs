using System;
using System.Collections.Generic;

namespace UsingMyFavoritePlatform.HomeWork
{
    public static class MaxSingleBlockToAllocate
    {
        public static void MostLikelyStackOverflowException()
        {
            // Don't know for sure why/where the exception was thrown.
            // Rider IDE crashed with Google Chrome, Fork and Microsoft Teams... xD
            int iteration = 0;
            int megabyte = 1024 * 1024;
            var arrays = new List<byte[]>();
            try
            {
                while (true)
                {
                    ++iteration;
                    arrays.Add(new byte[megabyte]);
                }
            }
            catch (OutOfMemoryException e)
            {
                Console.WriteLine(iteration + " MBs");
            }
        }

        public static void OverflowException()
        {
            int megabyte = 1024 * 1024;
            int arrayLength = megabyte;
            try
            {
                while (true)
                {
                    byte[] a = new byte[arrayLength];
                    arrayLength += megabyte; // Here was overflow exception
                }
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine(arrayLength + " bytes");
            }
        }

        // Answer: approximately 301989888 bytes
        public static void DisplayApproximateMaxSingleBlockToAllocate()
        {
            int megabyte = 1024 * 1024;
            int arrayLength = megabyte;
            var list = new List<byte[]>();
            try
            {
                while (true)
                {
                    list.Add(new byte[arrayLength]);
                    arrayLength += megabyte;
                }
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine(arrayLength + " bytes");
            }
        }
    }
}