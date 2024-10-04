using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MessageReaction.Model
{
    public class MessageItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString().Replace("-", "");
        public string Role { get; set; } = "";
        public string Content { get; set; } = "";
    }

    public class ChatHistory
    {
        public List<MessageItem> Messages { get; set; } = new List<MessageItem>();
    }

    public static class ChatHistoryExtensions
    {
        public static void AddMessages(this ChatHistory chatHistory, string jsonPrompt)
        {
            ChatHistory history = JsonConvert.DeserializeObject<ChatHistory>(jsonPrompt)!;
            foreach (var chatMessage in history.Messages)
            {
                chatHistory.Messages.Add(new MessageItem() { Role = chatMessage.Role.ToString(), Content = chatMessage.Content });
            }
        }
    }
}

