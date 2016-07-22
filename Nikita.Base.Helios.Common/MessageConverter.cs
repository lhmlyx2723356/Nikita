using System;
using System.Linq;
using System.Text; 
using Helios.Net;

namespace Nikita.Base.HeliosCommon
{
    public class MessageConverter
    {
        public static Message ToMessage(NetworkData data)
        {
            try
            {
                var commandData = data.Buffer.Take(4).ToArray();
                var contentData = data.Buffer.Skip(4).Take(data.Buffer.Length - 4).ToArray();

                var command = BitConverter.ToInt32(commandData,0);
                var content = Encoding.UTF8.GetString(contentData);

                return new Message()
                {
                    Command = (Command)command,
                    Content = content
                };
            }
            catch (Exception exc)
            {
                Console.WriteLine("Cant convert NetworkData to Message : {0}", exc.Message);
            }

            return null;

        }

        public static byte[] ToBytes(Message message)
        {
            try
            {
                var commandBytes = BitConverter.GetBytes((int)message.Command);
                var messageBytes = Encoding.UTF8.GetBytes(message.Content);
                var bytes = new byte[commandBytes.Length + messageBytes.Length];
                commandBytes.CopyTo(bytes, 0);
                messageBytes.CopyTo(bytes, commandBytes.Length);

                return bytes;
            }
            catch (Exception exc)
            {
                Console.WriteLine("Cant convert message to bytes : {0}", exc.Message);
            }

            return null;
        }

    }
}
