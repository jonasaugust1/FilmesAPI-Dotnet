using MailKit.Net.Smtp;
using MimeKit;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class EmailService
    {
        private IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public void EnviarEmail(IEnumerable<string> destinatario, string assunto, int usuarioId, string code)
        {
            Mensagem mensagem = new Mensagem(destinatario, assunto, usuarioId, code);
            MimeMessage mensagemDeEmail = CriaCorpoDoEmail(mensagem);
            EnviarEmail(mensagemDeEmail);
        }

        private void EnviarEmail(MimeMessage mensagemDeEmail)
        {
            using(SmtpClient client = new SmtpClient())
            {
                try
                {
                    client.CheckCertificateRevocation = false;
                    client.Connect(_config.GetValue<string>("EmailSettings:SmtpServer"),
                        _config.GetValue<int>("EmailSettings:Port"), true);
                 
                    client.AuthenticationMechanisms.Remove("XOUATH2");

                    client.Authenticate(_config.GetValue<string>("EmailSettings:From"),
                        _config.GetValue<string>("EmailSettings:Password"));

                    client.Send(mensagemDeEmail);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage CriaCorpoDoEmail(Mensagem mensagem)
        {
            MimeMessage mensagemDeEmail = new MimeMessage();
            mensagemDeEmail.From.Add(new MailboxAddress("UTF-8", _config.GetValue<string>("EmailSettings:From")));
            mensagemDeEmail.To.AddRange(mensagem.Destinatario);
            mensagemDeEmail.Subject = mensagem.Assunto;
            mensagemDeEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };

            return mensagemDeEmail;
        }
    }
}
