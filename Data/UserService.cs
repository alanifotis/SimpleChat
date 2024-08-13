namespace SimpleChat.Data;
using SimpleChat.Models;

public class UserService {
    public Task<List<ChatMessage>> GetAllUserMessages()
    {
        return await List<ChatMessage>().Empty();
    }
}