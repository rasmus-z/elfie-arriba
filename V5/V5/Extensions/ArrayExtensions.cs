﻿using System;
using System.Collections.Generic;
using System.Text;

namespace V5.Extensions
{
    public static class ArrayExtensions
    {
        public static long[] ToPrimitiveArray(this DateTime[] values)
        {
            long[] result = new long[values.Length];

            for (int i = 0; i < values.Length; ++i)
            {
                result[i] = values[i].ToUniversalTime().Ticks;
            }

            return result;
        }

        public static long[] ToPrimitiveArray(this TimeSpan[] values)
        {
            long[] result = new long[values.Length];

            for (int i = 0; i < values.Length; ++i)
            {
                result[i] = values[i].Ticks;
            }

            return result;
        }

        public static DateTime[] ToDateTimeArray(this long[] utcTicksArray)
        {
            DateTime[] result = new DateTime[utcTicksArray.Length];

            for (int i = 0; i < utcTicksArray.Length; ++i)
            {
                result[i] = new DateTime(utcTicksArray[i], DateTimeKind.Utc);
            }

            return result;
        }

        public static TimeSpan[] ToTimeSpanArray(this long[] ticksArray)
        {
            TimeSpan[] result = new TimeSpan[ticksArray.Length];

            for (int i = 0; i < ticksArray.Length; ++i)
            {
                result[i] = new TimeSpan(ticksArray[i]);
            }

            return result;
        }

        public static T[] Sample<T>(this T[] values, int countToSample, Random r)
        {
            int samplesLength = Math.Min(values.Length, countToSample);
            T[] sample = new T[samplesLength];

            int samplesAdded = 0;
            for (int i = 0; i < values.Length && samplesAdded < samplesLength; ++i)
            {
                double excludeChance = r.NextDouble();

                int itemsLeft = values.Length - i;
                int samplesNeeded = samplesLength - samplesAdded;

                // === if(excludeChance < samplesNeeded / itemsLeft)
                if (excludeChance * itemsLeft < samplesLength)
                {
                    sample[samplesAdded] = values[i];
                    samplesAdded++;
                }
            }

            return sample;
        }
    }
}