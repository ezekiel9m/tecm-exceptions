using System.Text.RegularExpressions;
using FluentValidator;

namespace TecmExceptions
{
    public class TecmValidators : Notifiable
    {
        protected static string NotNullMessage = "element is required.";
        protected static string NotEmptyMessage = "element cannot be empty";
        protected static string ConfirmMessage = "email doesn't match";
        protected static string ConfirmPassword = "password doesn't match";
        protected static string InvalidMessage = "element invalid";

        public void ValidarCreate(string name, string surname, string email, string emailConfirm, string password, string passwordConfirm)
        {
            if (string.IsNullOrEmpty(name))
                AddNotification("name", NotNullMessage);

            if (string.IsNullOrEmpty(surname))
                AddNotification("surname", NotNullMessage);

            if (email.Length > 5 || string.IsNullOrEmpty(email))
                AddNotification("email", NotNullMessage);

            if (emailConfirm.Length > 5 || string.IsNullOrEmpty(emailConfirm))
                AddNotification("emailConfirm", NotNullMessage);

            if (email != emailConfirm)
                AddNotification("emailConfirm", ConfirmMessage);

            if (string.IsNullOrEmpty(password))
                AddNotification("password", NotNullMessage);

            if (string.IsNullOrEmpty(passwordConfirm))
                AddNotification("passwordConfirm", NotNullMessage);

            if (email != emailConfirm)
                AddNotification("emailConfirm", ConfirmMessage);
        }
        public void ValidatorMessage(string message, int length)
        {
            if (string.IsNullOrEmpty(message))
                AddNotification("message", NotNullMessage);

            if (message.Length > length)
                AddNotification("message", $"maximum length reached, max length is: {length}.");
        }
        public bool ValidatorCPF_CNPJ(string value)
        {
            value = Regex.Replace(value, @"[^\d]", "");


            if (string.IsNullOrEmpty(value))
                AddNotification("cpf or cnpj", NotNullMessage);

            if(value.Length != 11 || value.Length != 14)
                AddNotification("cpf or cnpj", InvalidMessage);
            else
                return value.Length == 11 ? IsCpf(value) : value.Length == 14 ? IsCnpj(value) : false;

            return false;
        }
        private bool IsCpf(string cpf)
        {
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf, digito;
            int soma, resto;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            resto = resto < 2 ? 0 : 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            resto = resto < 2 ? 0 : 11 - resto;

            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
        private bool IsCnpj(string cnpj)
        {

            cnpj = Regex.Replace(cnpj, @"[^\d]", "");

            if (cnpj.Length != 14)
                return false;

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma, resto;

            string digito, tempCnpj;

            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);

            resto = resto < 2 ? 0 : 11 - resto;

            digito = resto.ToString();


            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            resto = resto < 2 ? 0 : 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }
    }
}
