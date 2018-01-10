﻿namespace Hyperbridge.Data
{
    public interface ILoader<T>
    {
        /// <summary>
        /// Loads a model from storage
        /// </summary>
        /// <param name="uri">The uri to the resource</param>
        /// <returns>The loaded model</returns>
        T Load(string uri);
    }
}