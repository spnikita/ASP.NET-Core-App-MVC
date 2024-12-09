namespace ASP.NET_Core_App_MVC.Models
{
    /// <summary>
    /// Отзыв
    /// </summary>
    public class Feedback
    {
        /// <summary>
        /// Автор отзыва
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Отзыв
        /// </summary>
        public string Text { get; set; }
    }
}
