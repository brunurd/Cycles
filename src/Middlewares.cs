namespace Cycles
{
    public static class Middlewares
    {
        /// <summary>
        /// Middleware's events call.
        /// </summary>
        private static event CycleAction middlewares;

        /// <summary>
        /// The delegate action type.
        /// </summary>
        /// <param name="info">The debug info structure.</param>
        public delegate void CycleAction(DebugInfo info);

        /// <summary>
        /// Subscribe to the middleware's events.
        /// </summary>
        /// <param name="action">The debug info event.</param>
        public static void AddListener(CycleAction action)
        {
            middlewares += action;
        }

        /// <summary>
        /// Unsubscribe to the middleware's events.
        /// </summary>
        /// <param name="action">The debug info event.</param>
        public static void RemoveListener(CycleAction action)
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