using GestaoOcorrencias.Web.Models;
using GestaoOcorrencias.Web.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace GestaoOcorrencias.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly string ENDPOINT = "http://localhost:5215/api/cliente";
        private readonly HttpClient httpclient = null;
        private static List<ClienteDto> _clientes = new List<ClienteDto>() { };
       
        public ClienteController()
        {
            httpclient = new HttpClient();
            httpclient.BaseAddress = new Uri(ENDPOINT);
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Clientes(string SearchString)
        {
            HttpResponseMessage response = await httpclient.GetAsync(ENDPOINT);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var lista = JsonConvert.DeserializeObject<List<ClienteDto>>(content);
                if (!String.IsNullOrEmpty(SearchString))
                {
                    double clienteID;
                    if(Double.TryParse(SearchString, out clienteID))
                    {
                        lista = lista.Where(whe => whe.ClienteId == clienteID).ToList();
                    }
                    else
                    {
                        lista = lista.Where(whe => whe.Name.Contains(SearchString)).ToList();
                    }
                }
                return View(lista);
            }
            else
            {
                ModelState.AddModelError(null, "Error");
            }
            return View(_clientes);
        }
        public async Task<IActionResult> Create(ClienteDto cliente)
        {
            try
            {
                if (cliente.ClienteId != 0)
                {
                    cliente.Id = Guid.NewGuid();
                    string json = JsonConvert.SerializeObject(cliente);
                    byte[] buffer = Encoding.UTF8.GetBytes(json);
                    ByteArrayContent byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                    string url = $"{ENDPOINT}/Salvar";
                    HttpResponseMessage response = await httpclient.PostAsync(url, byteContent);
                    if (response.IsSuccessStatusCode)
                    {

                    }
                    return RedirectToAction("Clientes");
                }
                return View();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<IActionResult> Read(string Id)
        {
            try
            {
                if (Id != null)
                {
                    ClienteDto cliente = null;
                    string url = $"{ENDPOINT}/Pesquisar/?id={Id}";
                    HttpResponseMessage response = await httpclient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        cliente = JsonConvert.DeserializeObject<ClienteDto>(content);
                    }
                    return View(cliente);
                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<IActionResult> Update(double Id, ClienteDto clienteUpdate, bool Update)
        {
            try
            {
                if (Id != null)
                {
                    ClienteDto cliente = null;
                    string url = $"{ENDPOINT}/Pesquisar/?id={Id}";
                    HttpResponseMessage response = await httpclient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        cliente = JsonConvert.DeserializeObject<ClienteDto>(content);
                    }
                    if (Update)
                    {
                        url = $"{ENDPOINT}/Atualizar/?id={Id}";
                        string json = JsonConvert.SerializeObject(clienteUpdate);
                        byte[] buffer = Encoding.UTF8.GetBytes(json);
                        ByteArrayContent byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        response = await httpclient.PostAsync(url, byteContent);
                        if (response.IsSuccessStatusCode)
                        {

                        }
                        return RedirectToAction("Clientes");
                    }

                    return View(cliente);
                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<IActionResult> Delete(string Id, bool Delete)
        {
            try
            {
                if (Id != null)
                {
                    ClienteDto cliente = null;
                    string url = $"{ENDPOINT}/Pesquisar/?id={Id}";
                    HttpResponseMessage response = await httpclient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        cliente = JsonConvert.DeserializeObject<ClienteDto>(content);
                    }
                    if (Delete)
                    {
                        url = $"{ENDPOINT}/Delete/?id={Id}";
                        HttpRequestMessage request = new HttpRequestMessage
                        {
                            Method = HttpMethod.Delete,
                            RequestUri = new Uri(url)
                        };
                        await httpclient.SendAsync(request);
                        return RedirectToAction("Clientes");
                    }

                    return View(cliente);
                }
                return View();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
