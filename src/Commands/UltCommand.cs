using System;
using System.Threading.Tasks;
using RasReiios.rastrear;

namespace RasReiios.Commands
{
    public class UltCommand : IBotCommand
    {
        private readonly IServiceProvider _serviceProvider;

        public string Command => "ult";

        public string Description => "Comando para obter o último status da encomenda";

        public bool InternalCommand => false;

        public UltCommand(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Execute(IChatService chatService, long chatId, int userId, int messageId, string? commandText)
        {
            Rastreando rastrear = new Rastreando();
            var rastrearCr = await rastrear.GetInfoRs(commandText);
            string eventosRS = $"{rastrearCr.objetos[0].eventos[0].descricao} Em {rastrearCr.objetos[0].eventos[0].unidade.tipo}, {rastrearCr.objetos[0].eventos[0].unidade.endereco.cidade} {rastrearCr.objetos[0].eventos[0].unidade.endereco.uf} {rastrearCr.objetos[0].eventos[0].dtHrCriado}";

            await chatService.SendMessage(chatId, eventosRS, messageId);
        }

    }
}
