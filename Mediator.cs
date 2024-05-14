namespace Machine_Learning_Studio
{
    public class Mediator
    {
        public static event EventHandler<string>? MessageReceived;

        public static void SendMessage(string message)
        {
            MessageReceived?.Invoke(null, message);
        }
    }
}
