using System;

namespace ToyRobotLib.Extensions
{
    /// <summary>
    /// Enumerated type extensions
    /// </summary>
    public static class EnumExtensions
    {
        #region Public Static Methods

        /// <summary>
        /// Get the next enum value, wraps to first value if src is last value
        /// </summary>
        public static T Next<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));
            }

            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(Arr, src) + 1;

            return (Arr.Length == j) ? Arr[0] : Arr[j];
        }

        /// <summary>
        /// Get the previous enum value, wraps to last value if src is first value
        /// </summary>
        public static T Previous<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));
            }

            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(Arr, src) - 1;

            return (j < 0) ? Arr[Arr.Length - 1] : Arr[j];
        }

        /// <summary>
        /// Get string name of enum
        /// </summary>
        public static string NameOf<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));
            }

            return Enum.GetName(typeof(T), src);
        }

        #endregion
    }
}
