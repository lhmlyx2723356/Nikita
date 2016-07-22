namespace Nikita.DataAccess.Expression2Sql
{
    public static class Expression2SqlEx
    {
        public static bool In<T>(this object obj, params T[] ary)
        {
            return true;
        }

        public static bool Like(this object obj, string value)
        {
            return true;
        }

        /// <summary>
        /// like '% _ _ _'
        /// </summary>
        public static bool LikeLeft(this object obj, string value)
        {
            return true;
        }

        /// <summary>
        /// like '_ _ _ %'
        /// </summary>
        public static bool LikeRight(this object obj, string value)
        {
            return true;
        }
    }
}