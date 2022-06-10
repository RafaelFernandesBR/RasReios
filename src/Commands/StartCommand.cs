using System;
using System.Threading.Tasks;

namespace RasReiios.Commands
{
    public class StartCommand : IBotCommand
    {
        private readonly IServiceProvider _serviceProvider;

        public string Command => "start";

        public string Description => "Comando inicial";

        public bool InternalCommand => false;

        public StartCommand(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Execute(IChatService chatService, long chatId, int userId, int messageId, string? commandText)
        {
            await chatService.SendMessage(chatId, "Bem vindo ao bot RasReio", messageId);
        }
    }
}
