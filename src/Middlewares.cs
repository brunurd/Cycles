using System;

namespace Cycles
{
    public static class Middlewares
    {
        /// <summary>
        /// Middleware's events call.
        /// </summary>
        private static event Action<DebugInfo> middlewares;

        /// <summary>
        /// Subscribe to the middleware's events.
        /// </summary>
        /// <param name="action">The debug info event.</param>
        public static void AddListener(Action<DebugInfo> action)
        {
            middlewares += action;
        }

        /// <summary>
        /// Unsubscribe to the middleware's events.
        /// </summary>
        /// <param name="action">The debug info event.</param>
        public static void RemoveListener(Action<DebugInfo> action)
        {
            middlewares -= action;
        }

        /// <summary>
        /// Remove all subscribed middlewares.
        /// </summary>
        public static void RemoveAllListener()
        {
            middlewares = null;
        }

        /// <summary>
        /// Call middleware's events.
        /// </summary>
        /// <param name="info"></param>
        internal static void MiddlewareCall(DebugInfo info)
        {
            middlewares?.Invoke(info);
        }
    }
}