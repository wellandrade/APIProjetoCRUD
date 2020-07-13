using System.Collections.Generic;

namespace CRUD.Negocio.Modelos
{
    public class Retorno 
    {
        public bool _sucesso { get; private set; }
        public string _mensagemSucesso { get; private set; }

        public List<string> _notificacoesFalha { get; private set;}

        public Retorno(bool sucesso)
        {
            _sucesso = sucesso;
            _mensagemSucesso = "";

            if (_notificacoesFalha == null)
            {
                _notificacoesFalha = new List<string>();
            }
        }

        public void AdicionarMensagemFalha(string notificacao)
        {
            _notificacoesFalha.Add(notificacao);
        }

        public void AdicionarMensagemSucesso(string mensagem)
        {
            _mensagemSucesso = mensagem;
        }
    }
}
