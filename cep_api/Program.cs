using System;


namespace cep_api
{
    class Program
    {

        static async Task Main(string[] args)
        {

            try
            {
                //inicia API.cs
                Api requisita;

                requisita = new Api();

                //pega o cep digitado pelo usuario
                Console.WriteLine("Buscar endereço atraves do cep");
                Console.Write("Digite seu cep: ");

                requisita.cep = Console.ReadLine();

                //inicia a requisção da api
                string resposta = await requisita.requisitaAsync();

                //Percorre a resposta da api e insere no banco 
                 requisita.Percorrer(resposta);

                //mostra para o usuario seu cep

                Console.WriteLine("\r\n"+ "Dados do seu endereço: " + "\r\n" + requisita);


            }


            catch (Exception ex)
            {
                Console.WriteLine("Este cep está invalido!");


            }
            finally { }
        }





    }
}


