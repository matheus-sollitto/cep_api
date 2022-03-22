using Newtonsoft.Json.Linq;
using System;
using System.Net.Http.Headers;


namespace cep_api
{
    internal class Api
    {
        private Conexao conect;
        public string cep;
        public string logradouro;
        public string complemento;
        public string bairro;
        public string localidade;
        public string uf;
        public string ibge;
        public string gia;
        public string ddd;
        public string siafi;



       
        //função para requisitar a API
        public async Task<string> requisitaAsync()
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri("https://viacep.com.br") };
            var reader = $"ws/{cep}/json/";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync(reader);
            var content = await response.Content.ReadAsStringAsync();


            var jo = content;


            return jo;
        }

        //função para inserir no banco de dados
       // public void Inserir()
      //  {
         //   conect = new Conexao();
        //    string sql = "INSERT INTO endereco ("
      //          + "cep, logradouro, complemento, bairro, localidade, uf, ibge, gia, ddd,siafi "
        //           + ") VALUES("
          //        + " '" + cep + "', '" + logradouro + "', '" + complemento + "', '" + bairro + "', '" + localidade + "', '" + uf + "', '" + ibge + "', '" + gia + "', '" + ddd + "', '" + siafi + "'"
            //            + ")";

       //     conect.Insert(sql);
            //}


        //função percorrer a resposta da api
        public void Percorrer(string response)
        {

            var resposta = JObject.Parse(response);

           
                cep = (string)resposta["cep"];
                logradouro = (string)resposta["logradouro"];
                complemento = (string)resposta["complemento"];
                bairro = (string)resposta["bairro"];
                localidade = (string)resposta["localidade"];
                uf = (string)resposta["uf"];
                ibge = (string)resposta["ibge"];
                gia = (string)resposta["gia"];
                ddd = (string)resposta["ddd"];
                siafi = (string)resposta["siafi"];
            
        }

        public override string ToString()
        {
            return "cep: " + cep + " \r\nlogradouro: " + logradouro
            + "\r\n"
            + "complemento: " + complemento
            + "\r\n"
            + "bairro: " + bairro
            + "\r\n"
            + "localidade: " + localidade + "\r\n"
            + "uf: " + uf
            + "\r\n"
            + "ibge: " + ibge
            + "\r\n"
            + "gia: " + gia
            + "\r\n"
            + "ddd: " + ddd
            + "\r\n"
            + "siafi: " + siafi;
   
        }


    }
}
