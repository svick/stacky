﻿using System;
using System.Diagnostics;

namespace StackOverflow
{
    public static class Require
    {
        #region Methods to verify conditions (Require)

        /// <summary>
        ///     If <paramref name="truth"/> is false, throw an empty <see cref="InvalidOperationException"/>.
        /// </summary>
        /// <param name="truth">The 'truth' to evaluate.</param>
        [DebuggerStepThrough]
        public static void IsTrue(bool truth)
        {
            if (!truth)
            {
                throw new InvalidOperationException(string.Empty);
            }
        }

        /// <summary>
        ///     If <paramref name="truth"/> is false, throw an 
        ///     <see cref="InvalidOperationException"/> with the provided <paramref name="message"/>.
        /// </summary>
        /// <param name="truth">The 'truth' to evaluate.</param>
        /// <param name="message">
        ///     The <see cref="Exception.Message"/> if 
        ///     <paramref name="truth"/> is false.
        /// </param>
        [DebuggerStepThrough]
        public static void IsTrue(bool truth, string message)
        {
            NotNullOrEmpty(message, "message");
            if (!truth)
            {
                throw new InvalidOperationException(message);
            }
        }

        /// <summary>
        ///     If <paramref name="truth"/> is false, throws 
        ///     <paramref name="exception"/>.    
        /// </summary>
        /// <param name="truth">The 'truth' to evaluate.</param>
        /// <param name="exception">
        ///     The <see cref="Exception"/> to throw if <paramref name="truth"/> is false.
        /// </param>
        [DebuggerStepThrough]
        public static void IsTrue(bool truth, Exception exception)
        {
            NotNull(exception, "exception");
            if (!truth)
            {
                throw exception;
            }
        }

        /// <summary>
        ///     Throws an <see cref="ArgumentNullException"/> if the
        ///     provided string is null.
        ///     Throws an <see cref="ArgumentOutOfRangeException"/> if the
        ///     provided string is empty.
        /// </summary>
        /// <param name="stringParameter">The object to test for null and empty.</param>
        /// <param name="parameterName">The string for the ArgumentException parameter, if thrown.</param>
        [DebuggerStepThrough]
        public static void NotNullOrEmpty(string stringParameter, string parameterName)
        {
            if (stringParameter == null)
            {
                throw new ArgumentNullException(parameterName);
            }
            else if (stringParameter.Length == 0)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        /// <summary>
        ///     Throws an <see cref="ArgumentNullException"/> if the
        ///     provided object is null.
        /// </summary>
        /// <param name="obj">The object to test for null.</param>
        /// <param name="parameterName">The string for the ArgumentNullException parameter, if thrown.</param>
        [DebuggerStepThrough]
        public static void NotNull(object obj, string parameterName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        /// <summary>
        ///     Throws an <see cref="ArgumentException"/> if the provided truth is false.
        /// </summary>
        /// <param name="truth">The value assumed to be true.</param>
        /// <param name="parameterName">The string for <see cref="ArgumentException"/>, if thrown.</param>
        [DebuggerStepThrough]
        public static void Argument(bool truth, string parameterName)
        {
            NotNullOrEmpty(parameterName, "parameterName");

            if (!truth)
            {
                throw new ArgumentException(parameterName);
            }
        }

        /// <summary>
        ///     Throws an <see cref="ArgumentException"/> if the provided truth is false.
        /// </summary>
        /// <param name="truth">The value assumed to be true.</param>
        /// <param name="paramName">The paramName for the <see cref="ArgumentException"/>, if thrown.</param>
        /// <param name="message">The message for <see cref="ArgumentException"/>, if thrown.</param>
        [DebuggerStepThrough]
        public static void Argument(bool truth, string paramName, string message)
        {
            NotNullOrEmpty(paramName, "paramName");
            NotNullOrEmpty(message, "message");

            if (!truth)
            {
                throw new ArgumentException(message, paramName);
            }
        }

        /// <summary>
        ///     Throws an <see cref="ArgumentOutOfRangeException"/> if the provided truth is false.
        /// </summary>
        /// <param name="truth">The value assumed to be true.</param>
        /// <param name="parameterName">The string for <see cref="ArgumentOutOfRangeException"/>, if thrown.</param>
        [DebuggerStepThrough]
        public static void ArgumentRange(bool truth, string parameterName)
        {
            NotNullOrEmpty(parameterName, "parameterName");

            if (!truth)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        /// <summary>
        ///     Throws an <see cref="ArgumentOutOfRangeException"/> if the provided truth is false.
        /// </summary>
        /// <param name="truth">The value assumed to be true.</param>
        /// <param name="paramName">The paramName for the <see cref="ArgumentOutOfRangeException"/>, if thrown.</param>
        /// <param name="message">The message for <see cref="ArgumentOutOfRangeException"/>, if thrown.</param>
        [DebuggerStepThrough]
        public static void ArgumentRange(bool truth, string paramName, string message)
        {
            NotNullOrEmpty(paramName, "paramName");
            NotNullOrEmpty(message, "message");

            if (!truth)
            {
                throw new ArgumentOutOfRangeException(message, paramName);
            }
        }

        #endregion
    }
}