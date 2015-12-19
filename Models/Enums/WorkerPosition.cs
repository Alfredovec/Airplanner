namespace Models.Enums
{
    /// <summary>
    /// Representing possible worker positions.
    /// </summary>
    public enum WorkerPosition
    {
        FirstPilot,
        SecondPilot,
        Navigator,
        Radioman,
        Steward
    }
    
    public static class EnumExtensions
    {
        /// <summary>
        /// Converts wokrer position to string with readable words.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static string ToFriendlyString(this WorkerPosition position)
        {
            switch (position)
            {
                case WorkerPosition.FirstPilot:
                    return "First pilot";
                case WorkerPosition.SecondPilot:
                    return "Second pilot";
                default:
                    return position.ToString();
            }
        }
    }
}
