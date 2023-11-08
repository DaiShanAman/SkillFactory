﻿namespace Module_19_Social_Network.BLL.Models
{
    public class Message
    {
        public int Id { get; }
        public string Content { get; }
        public string SenderEmail { get; }
        public string RecipientEmail { get; }

        public Message(int id, string content, string senderEmail, string recipientEmail)
        {
            this.Id = id;
            this.Content = content;
            this.SenderEmail = senderEmail;
            this.RecipientEmail = recipientEmail;
        }

    }
}
