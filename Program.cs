namespace BlackWhiteSquaresGame
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var game = new GameModel(5);
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(game) {ClientSize = new Size(300, 300)});
        }
    }
}