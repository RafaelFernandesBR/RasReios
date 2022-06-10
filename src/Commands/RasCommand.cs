using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RasReiios.rastrear;

namespace RasReiios.Commands
{
    public class RasCommand : IBotCommand
    {
        private readonly IServiceProvider _serviceProvider;

        public string Command => "ras";

        public string Description => "Rastrear uma encomenda";

        public bool InternalCommand => false;

        public RasCommand(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Execute(IChatService chatService, long chatId, int userId, int messageId, string? commandText)
        {
            Rastreando rastrear = new Rastreando();
            var rastrearCr = await rastrear.GetInfoRs(commandText);

            foreach (var objeto in rastrearCr.objetos)
            {
                foreach (var evento in objeto.eventos)
                {
                    if (evento.unidadeDestino == null)
                    {
                        string eventosRS = $"{evento.descricao} Em {evento.unidade.tipo}, {evento.unidade.endereco.cidade} {evento.unidade.endereco.uf} {evento.dtHrCriado}\n";

                        await chatService.SendMessage(chatId, eventosRS, messageId);
                    }
                    else
                    {
                        string eventosRS = $"{evento.descricao} Indo para {evento.unidadeDestino.tipo}, {evento.unidadeDestino.endereco.cidade} {evento.unidadeDestino.endereco.uf} {evento.dtHrCriado}\n";

                        await chatService.SendMessage(chatId, eventosRS, messageId);
                    }

                }
            }

        }
    }
}
