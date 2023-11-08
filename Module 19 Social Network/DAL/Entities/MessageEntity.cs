namespace Module_19_Social_Network.DAL.Entities
{
    public class MessageEntity
    {
        public int id { get; set; }
        public string content { get; set; }
        public int sender_id { get; set; }
        public int getter_id { get; set; }
    }
}
