using System;

namespace Quix
{
    /// <summary>
    /// Extension class for string and text objects.
    /// </summary>
    public static class String
    {
        /// <summary>
        /// Returns the number of sentences in the given string object.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <returns>The number of sentences in the given object.</returns>
        public static int Lines(this System.String str)
        {
            return str.Split(new char[] { '\n' },
                             StringSplitOptions.RemoveEmptyEntries)
                      .Length;
        }

        /// <summary>
        /// Returns the number of sentences in the given string builder object.
        /// </summary>
        /// <param name="str">A System.Text.StringBuilder object.</param>
        /// <returns>The number of sentences in the given object.</returns>
        public static int Lines(this System.Text.StringBuilder str)
        {
            return str.ToString()
                      .Split(new char[] { '\n' },
                             StringSplitOptions.RemoveEmptyEntries)
                      .Length;
        }

        /// <summary>
        /// Returns the number of words in the given string object.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <returns>The number of words in the given object.</returns>
        public static int Words(this System.String str)
        {
            return str.Split(new char[] { ' ',
                                          '.',
                                          '?',
                                          '!',
                                          ';' },
                             StringSplitOptions.RemoveEmptyEntries)
                      .Length;
        }

        /// <summary>
        /// Returns the number of words in the given string builder object.
        /// </summary>
        /// <param name="str">A System.Text.StringBuilder object.</param>
        /// <returns>The number of words in the given object.</returns>
        public static int Words(this System.Text.StringBuilder str)
        {
            return str.ToString()
                      .Split(new char[] { ' ',
                                          '.',
                                          '?',
                                          '!',
                                          ';' },
                             StringSplitOptions.RemoveEmptyEntries)
                      .Length;
        }
    }
}
