using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBuscaCep.Models;
using Newtonsoft;
using Newtonsoft.Json;
using Org.Apache.Http.Protocol;
namespace AppBuscaCep.Services
{
    public class DataService
    {
        public static async Task<Endereco> GetEnderecoByCEP(string cep)
        {
            Endereco end;
            
            using(HttpClient client  = new HttpClient())
            {
                string url = "https://cep.metoda.com.br/endereco/bv-cep?cep" + cep;

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    end = JsonConvert.DeserializeObject<Endereco>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }
            return end;
        }
    }
}
